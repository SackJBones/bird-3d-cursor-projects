///PART OF SPHERE FIT BIRD
///Sphere Fit Bird is a collaboration between Dana Gretton (good at math) and
///Aubrey Simonson (his boyfriend, inventor) based on Aubrey's 2021 MIT Media Lab Thesis project, Bird.
///For more information on Bird, see: https://drive.google.com/file/d/1p6IUu9QIzWNBERz3IW_yVcojQjVz06rl/view?usp=sharing
///This project works with the OVR Toolkit, and once OpenXR is more stable, someone should probably make an OpenXR version.
/// 
/// Bird.cs handles all of the crazy linear algebra for converting the hand skeleton points to 
/// an individual point in space which moves smoothly in an easy to control way. 
/// 
/// It does so using sphere fit and Kalman filtering.
/// For how on Earth one does sphere fit code, we are grateful for this useful article:
/// https://jekel.me/2015/Least-Squares-Sphere-Fit/
/// 
/// Doesn't strictly require other scripts (that's on purpose!)
/// Remember to give it materials for birdSelectedMaterial and birdMaterial in the inspector
/// Put this script on the hand! Specifically, it should go an OVRHandPrefab with an OVRSkeleton component
/// 
///???---> asimonso@mit.edu/followspotfour@gmail.com // dgretton@mit.edu/dana.gretton@gmail.com
///Last edited February 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public GameObject targetUnitSphere;//visible sphere-- good for debugging
    public GameObject debugMarker;
    public GameObject birdMarker;
    public Vector3 birdPosition;
    public Ray birdRay;
    public float range;
    public bool selected;
    public bool down;
    public bool up;
    public Material birdSelectedMaterial, birdMaterial;
    public bool rayWasHit;
    public RaycastHit birdRayHit;
    public Quaternion rotation;
    public float twist;
    public bool twistReverse;
    public bool showDebug;//turn this on to see hand points and transparent sphere that represents fit. Can be turned off.
    GameObject[] debugMarkers;
    GameObject hitMarker;
    int numbones;
    Vector3[] pointPoss;
    float[] pointDists;
    float[] a2Xs;
    float[] a2Ys;
    float[] a2Zs;
    float[] aOnes;
    float[] aIntermediates;
    KalmanFilterVector3 filter;
    bool showingDebug;

    //Here we define some linear algebra things which... aren't? in Unity by default.
    //So we wrote them.
    private float Dot(float[] v1, float[] v2)
    {
        int len = v1.Length;
        if (v2.Length != len)
        {
            throw new System.ArgumentException("Cannot take dot product of vectors of unequal length");
        }
        float dot_product = 0.0f;
        for (int i = 0; i < len; i++)
        {
            dot_product += v1[i] * v2[i];
        }
        return dot_product;
    }

    private float Dot(Vector4 v1, float[] v2)
    {
        return Dot(new float[] { v1[0], v1[1], v1[2], v1[3] }, v2);
    }

    private float Dot(float[] v1, Vector4 v2)
    {
        return Dot(v2, v1);
    }
    //end linear algebra things.

    void Start () {

        var skeleton = GetComponent<OVRSkeleton>();
        numbones = skeleton.Bones.Count-8;//We subtract a number because we don't use all points. Unclear why it's 8. Document as you go, kids.
        pointPoss = new Vector3[numbones];//this is the set of points we fit a sphere to
        pointDists = new float[numbones];//the distance, for each point, from the average position of all points in pointPoss

        //arrays that get filled with intermediate results every frame
        a2Xs = new float[numbones];
        a2Ys = new float[numbones];
        a2Zs = new float[numbones];
        aOnes = new float[numbones];

        //makes debug markers
        debugMarkers = new GameObject[numbones];
        for (int i = 0; i < numbones; i++) {
            debugMarkers[i] = Instantiate(debugMarker);
            aOnes[i] = 1.0f;
        }
        hitMarker = Instantiate(debugMarker);
        aIntermediates = new float[4];

        //it's important that we change R based on bird distance from hand (in the update function) because jitter at the end of a 
        //raycast which is far away is more than the scale of intentional movements nearby
        filter = new KalmanFilterVector3(0.001f, .06f); // Q is process variance, R is measurement variance

        selected = false;//we are not selecting on the first frame
        rotation = Quaternion.identity;
        debugGeometryVisible(showDebug);
    }//end start

    void Update() {
        var skeleton = GetComponent<OVRSkeleton>();
        Vector3 handRoot = Vector3.zero;//middle of palm
        Vector3 indexTip = Vector3.zero;
        Vector3 indexRoot = Vector3.zero;
        //important that .4 .3 and .3 here add up to 1-- they are a weighted average
        //get position of bones
        foreach (OVRBone bone in skeleton.Bones)
        {
            if (bone.Id == OVRSkeleton.BoneId.Hand_Index1)
            {
                indexRoot = bone.Transform.position;
                handRoot += .4f*bone.Transform.position;
            }
            if (bone.Id == OVRSkeleton.BoneId.Hand_Pinky1)
            {
                handRoot += .3f * bone.Transform.position;
            }
            if (bone.Id == OVRSkeleton.BoneId.Hand_Thumb1)
            {
                handRoot += .3f * bone.Transform.position;
            }
            if (bone.Id == OVRSkeleton.BoneId.Hand_IndexTip)
            {
                indexTip = bone.Transform.position;
            }
            int i = (int)bone.Id;
            if (i < 4 || i == 15 || i == 7 || i == 8 || i == 20)
            {
                continue;
            }
            //pick out correct bones from bone list? Sorry this is horrible.
            //Look at OVRSkeleton.cs enum BoneId if you need to know more.
            pointPoss[i < 15 ? (i > 7 ? i - 6 : i - 4) : (i < 20 ? i - 7 : i - 8)] = bone.Transform.position;
            debugMarkers[i < 15 ? (i > 7 ? i - 6 : i - 4) : (i < 20 ? i - 7 : i - 8)].transform.position = bone.Transform.position;
        }
        //end getting position of bones
        Vector4 fitVector = LeastSqSphere(pointPoss);//calls linear algebra from later in this script
        float sphereCenterX = fitVector[0];
        float sphereCenterY = fitVector[1];
        float sphereCenterZ = fitVector[2];
        float sphereRadius = fitVector[3];

        Vector3 sphereCenter = new Vector3(sphereCenterX, sphereCenterY, sphereCenterZ);
        Vector3 pointing = sphereCenter - handRoot;//direction that the bird goes out from the hand-- the pointing vector
        float m = pointing.magnitude;//distance from hand root to center of sphere

        //this line determines the position of the bird based on pointing and bird range function--
        //bird range function can be whatever you want. We define it later in this script.
        //This smooths using a Kalman filter.
        birdPosition = filter.Update(pointing/m*birdRangeFunc(m) + handRoot, null, m*m*m*270f);//m*m*m*270f is R

        birdMarker.transform.position = birdPosition;

        Vector3 handUpVector = indexRoot - handRoot; // we will compare this "hand up" to "world up" to calculate a twist angle
        handUpVector = handUpVector - Vector3.Project(handUpVector, pointing); // a vector in the plane of {pointing, origin, index knuckle}, perpendicular to pointing
        Vector3 noTwistVector = Vector3.up - Vector3.Project(Vector3.up, pointing); // a vector in the plane of {pointing, origin, up}, perpendicular to pointing
        twist = Vector3.SignedAngle(handUpVector, noTwistVector, pointing);
        if (twistReverse)
        {
            twist *= -1;
        }

        //start clicking-related things

        //the following two lines prevent rapid clicking/unclicking
        float selectDepth = .007f;//distance in meters that the tip of the pointer finger must penetrate the sphere to enter a selected state
        float releaseDepth = .005f;//distance into the sphere that tip of pointer finger needs to be retracted to to exit selected state

        Vector3 selectCenter;

        //if the tip of the finger is closer to the center of the sphere than to the bird
        if ((indexTip - sphereCenter).magnitude < (indexTip - birdPosition).magnitude)
        {
            selectCenter = sphereCenter;
        }
        else
        {
            selectCenter = birdPosition;
        }

        float indexDepth = sphereRadius - (indexTip - selectCenter).magnitude;//depth into sphere centered at selectCenter that index tip is penetrating
        down = false;
        up = false;
        if(!selected && indexDepth > selectDepth)
        {
            selected = true;
            down = true;
            Material mat = birdSelectedMaterial;//will break if this material is null
            birdMarker.GetComponent<Renderer>().material = mat;
        }
        if (selected && indexDepth < releaseDepth)
        {
            selected = false;
            up = true;
            Material mat = birdMaterial;//will break if this material is null
            birdMarker.GetComponent<Renderer>().material = mat;
        }
        targetUnitSphere.transform.position = sphereCenter;
        float sphereDiam = sphereRadius * 2;
        targetUnitSphere.transform.localScale = new Vector3(sphereDiam, sphereDiam, sphereDiam);
        birdRay = new Ray(handRoot, birdPosition - handRoot);
        range = (birdPosition - handRoot).magnitude;//figure out far away bird is along birdRay
        rayWasHit = Physics.Raycast(birdRay, out birdRayHit, range);
        if (showingDebug && rayWasHit)
        {
            hitMarker.SetActive(true);
            hitMarker.transform.position = birdRayHit.point;
        }
        else
        {
            hitMarker.SetActive(false);
        }

        // TODO: this was empirical and it's terrible, but I don't know how to straighten it out yet
        //Note: did not do.
        rotation = transform.rotation * Quaternion.AngleAxis(90, Vector3.up) * Quaternion.AngleAxis(90, Vector3.forward) * Quaternion.AngleAxis(-90, Vector3.right) * Quaternion.AngleAxis(90, Vector3.up) * Quaternion.AngleAxis(30, Vector3.right);
    }// end update

    //if geometry, geometry
    void debugGeometryVisible(bool show)
    {
        showingDebug = show; for (int i = 0; i < numbones; i++)
        {
            debugMarkers[i].SetActive(show);
        }
        targetUnitSphere.SetActive(show);
    }

    //THIS IS THE BIRD RANGE FUNCTION!
    //This is the function called above which determines how far along the ray the bird should go--
    //You can replace it with your own if it seems like this should be different
    //movement is scaled up farther away
    //in the current implementation, movement scales up slowly first, then fast
    private float birdRangeFunc(float x) // should be equal to x near 0, where "near" is relative to characteristic distance
    {
        float characteristic1 = .03f;//more of this close
        float characteristic2 = .04f;//more of this far away
        float x_norm1 = x / characteristic1;
        float x_norm2 = x / characteristic2;
        return (x_norm1 + (x_norm1 * x_norm1) + (x_norm2 * x_norm2 * x_norm2 * x_norm2 * x_norm2)) * characteristic1;//x+x^2+y^5
    }

    //more linear algebra-- returns a vector 4 where the first 3 components are the center of the sphere and the last component is the radius
    private Vector4 LeastSqSphere(Vector3[] pointVectors) {
        // Return a Vector4([center x, center y, center z, radius])
        Vector3 meanPoint = Vector3.zero;
        for (int i = 0; i < pointVectors.Length; i++)
        {
            meanPoint += pointVectors[i];
        }
        meanPoint /= pointVectors.Length;
        for (int i = 0; i < pointVectors.Length; i++)
        {
            Vector3 pos = pointVectors[i] - meanPoint;
            pointDists[i] = pos.sqrMagnitude;
            a2Xs[i] = pos.x * 2.0f;
            a2Ys[i] = pos.y * 2.0f;
            a2Zs[i] = pos.z * 2.0f;
        }
        aIntermediates[0] = Dot(a2Xs, pointDists);
        aIntermediates[1] = Dot(a2Ys, pointDists);
        aIntermediates[2] = Dot(a2Zs, pointDists);
        aIntermediates[3] = Dot(aOnes, pointDists);
        float a4XYs = Dot(a2Xs, a2Ys);
        float a4XZs = Dot(a2Xs, a2Zs);
        float a4YZs = Dot(a2Ys, a2Zs);
        float aSum2Xs = Dot(a2Xs, aOnes);
        float aSum2Ys = Dot(a2Ys, aOnes);
        float aSum2Zs = Dot(a2Zs, aOnes);
        Matrix4x4 aTa = new Matrix4x4();
        aTa.SetRow(0, new Vector4(Dot(a2Xs, a2Xs), a4XYs, a4XZs, aSum2Xs));
        aTa.SetRow(1, new Vector4(a4XYs, Dot(a2Ys, a2Ys), a4YZs, aSum2Ys));
        aTa.SetRow(2, new Vector4(a4XZs, a4YZs, Dot(a2Zs, a2Zs), aSum2Zs));
        aTa.SetRow(3, new Vector4(aSum2Xs, aSum2Ys, aSum2Zs, pointDists.Length));
        Matrix4x4 aTaInv = aTa.inverse;
        float sphereCenterX = Dot(aTaInv.GetRow(0), aIntermediates);
        float sphereCenterY = Dot(aTaInv.GetRow(1), aIntermediates);
        float sphereCenterZ = Dot(aTaInv.GetRow(2), aIntermediates);
        float sphereSqRadDifference = Dot(aTaInv.GetRow(3), aIntermediates);
        Vector3 sphereCenter = new Vector3(sphereCenterX, sphereCenterY, sphereCenterZ);
        Vector3 sphereCorrectedCenter = sphereCenter + meanPoint;
        float sphereRadius = Mathf.Sqrt(sphereSqRadDifference + sphereCenter.sqrMagnitude);
        return new Vector4(sphereCorrectedCenter.x, sphereCorrectedCenter.y, sphereCorrectedCenter.z, sphereRadius);
    }
}//end of Bird class

//everything after this is Kalman filtering

/// <summary>A Kalman filter implementation for <c>Vector3</c> values.</summary>
/// https://gist.github.com/davidfoster/48acce6c13e5f7f247dc5d5909dce349

public class KalmanFilterVector3
{

    //-----------------------------------------------------------------------------------------
    // Constants:
    //-----------------------------------------------------------------------------------------

    public const float DEFAULT_Q = 0.000001f;
    public const float DEFAULT_R = 0.01f;

    public const float DEFAULT_P = 1;

    //-----------------------------------------------------------------------------------------
    // Private Fields:
    //-----------------------------------------------------------------------------------------

    private float q;
    private float r;
    private float p = DEFAULT_P;
    private Vector3 x;
    private float k;

    //-----------------------------------------------------------------------------------------
    // Constructors:
    //-----------------------------------------------------------------------------------------

    // N.B. passing in DEFAULT_Q is necessary, even though we have the same value (as an optional parameter), because this
    // defines a parameterless constructor, allowing us to be new()'d in generics contexts.
    public KalmanFilterVector3() : this(DEFAULT_Q) { }

    public KalmanFilterVector3(float aQ = DEFAULT_Q, float aR = DEFAULT_R)
    {
        q = aQ;
        r = aR;
    }

    //-----------------------------------------------------------------------------------------
    // Public Methods:
    //-----------------------------------------------------------------------------------------

    public Vector3 Update(Vector3 measurement, float? newQ = null, float? newR = null)
    {

        // update values if supplied.
        if (newQ != null && q != newQ)
        {
            q = (float)newQ;
        }
        if (newR != null && r != newR)
        {
            r = (float)newR;
        }

        // update measurement.
        {
            k = (p + q) / (p + q + r);
            p = r * (p + q) / (r + p + q);
        }

        // filter result back into calculation.
        Vector3 result = x + (measurement - x) * k;
        x = result;
        return result;
    }

    public Vector3 Update(List<Vector3> measurements, bool areMeasurementsNewestFirst = false, float? newQ = null, float? newR = null)
    {

        Vector3 result = Vector3.zero;
        int i = (areMeasurementsNewestFirst) ? measurements.Count - 1 : 0;

        while (i < measurements.Count && i >= 0)
        {

            // decrement or increment the counter.
            if (areMeasurementsNewestFirst)
            {
                --i;
            }
            else
            {
                ++i;
            }

            result = Update(measurements[i], newQ, newR);
        }

        return result;
    }

    public void Reset()
    {
        p = 1;
        x = Vector3.zero;
        k = 0;
    }
}
