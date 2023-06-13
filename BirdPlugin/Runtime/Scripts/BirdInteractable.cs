///PART OF SPHERE FIT BIRD
///Sphere Fit Bird is a collaboration between Dana Gretton (good at math) and
///Aubrey Simonson (his boyfriend, inventor) based on Aubrey's 2021 MIT Media Lab Thesis project, Bird.
///For more information on Bird, see: https://drive.google.com/file/d/1p6IUu9QIzWNBERz3IW_yVcojQjVz06rl/view?usp=sharing
///This project works with the OVR Toolkit, and once OpenXR is more stable, someone should probably make an OpenXR version.
/// 
/// BirdInteractable.cs goes on an object that bird can interact with.
/// This code is full of options for exactly how the object behaves, which is why it is so long.
/// No linear algebra was harmed in the creation of this script.
/// 
/// It requires Bird.cs on at least one hand.
/// 
/// //note here later for anything that needs connected
/// 
///???---> asimonso@mit.edu/followspotfour@gmail.com // dgretton@mit.edu/dana.gretton@gmail.com
///Last edited February 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BirdInteractable : MonoBehaviour
{
    public Bird bird;
    KalmanFilterVector3 filter;
    bool selectingMe;

    //Activate Types are about when to select objects
    //Drag is like get key-- it's true while the pointer finger is inside of the selection zone
    //Straightening finger will deselect.
    //Toggle is like get key down-- the thing is selected until you click again
    //Touch selects instantly, with no clicking required. Best used with offset motion type
    public enum ActivateType
    {
        Drag = 0,
        Toggle = 1,
        Touch = 2
    }
    public ActivateType activateType;

    public bool selectBehind = true;//if true, select first collider the raycast intersects-- good for flat stuff, safe to set to false

    //Motion Type is how the selected object moves
    //Seek is "normal." Objects go where the bird goes.
    //Offset stops objects at a distance from the hand which is set by offset (below). Good for large objects.
    //SnapToCollider causes objects to stop when they hit colliders in SnapObjects. Good for putting things on surfaces.
    public enum MotionType
    {
        None = 0,
        Seek = 1,
        Offset = 2,
        SnapToCollider = 3
    }
    public MotionType motionType;

    public float offset;//goes with offset motion type

    //Tracking Speed is how fast object goes to target position.
    //This could have been a number, but the enum felt clearer.
    //Quoth Dana, "What the hell does a number mean?"
    public enum TrackingSpeed
    {
        Slow = 0,
        Medium = 1,
        Fast = 2,
        VeryFast = 3,
        None = 4
    }
    public TrackingSpeed trackingSpeed;

    //Orientation Mode controls how the object's rotation changes
    //Keep Heading: Object does not rotate
    //Horizontal: Object only rotates on vertical axis (like a revolving door)
    //Two axis: Object rotates like your head. Uses LookRotation.
    //Free: Object rotates freely with Bird. You think you want this, but you don't.
    //Everything else: free, but changes which way is considered front.
    public enum OrientationMode
    {
        KeepHeading = 0,
        Horizontal = 1,
        TwoAxis = 2,
        Free = 3,
        Free90Left = 4,
        Free90Right = 5,
        FreeTwist90Right = 6,
        FreeTwist90Left = 7,
        Free90Up = 8,
        Free90Down = 9
    }
    public OrientationMode orientationMode;

    //Ususally Bird is the right choice, but if you are using snap to collider motion type,
    //And you want to orient the object to the surface, that's when you would use collider normal.
    //Is compatable with all orientation modes.
    public enum OrientationSource
    {
        Bird = 0,
        ColliderNormal = 1
    }
    public OrientationSource orientationSource;

    bool following;//is the object actively on its way to a point
    Collider thisCollider;//collider component of the object this script is on
    Renderer thisRenderer;//same but renderer

    //these are the objects that we snap to if we are using snap to collider motion type
    //Note: they must have colliders
    public GameObject[] snapObjects;
    private List<Collider> snapColliders;

    [SerializeField] UnityEvent OnSelect;
    [SerializeField] UnityEvent OnDeselect;

    private Vector3 previousTargetPos;//where the object currently is. Used for staying in the same place if there is no ray hit.

    // Start is called before the first frame update
    void Start()
    {
        //start Kalman filtering related things
        float Q;
        float R;
        // Q is process variance, R is measurement variance
        if (trackingSpeed == TrackingSpeed.Slow)
        {
            Q = 0.001f;
            R = .6f;
        }
        else if (trackingSpeed == TrackingSpeed.Medium)
        {
            Q = 0.001f;
            R = .06f;

        }
        else if (trackingSpeed == TrackingSpeed.Fast)
        {
            Q = 0.001f;
            R = .005f;
        }
        else
        {
            Q = .001f;
            R = .00001f;
        }
        filter = new KalmanFilterVector3(Q, R);
        filter.Update(transform.position);
        //end Kalman filter related stuff

        following = false;//when we start the scene, we are not yet going to a target position
        thisCollider = GetComponent<Collider>();
        thisRenderer = GetComponent<Renderer>();
        previousTargetPos = transform.position;
        snapColliders = new List<Collider>();
        foreach (GameObject snapObject in snapObjects)
        {
            snapColliders.Add(snapObject.GetComponent<Collider>());
        }
        selectingMe = false;
    }//end start

    void Update()
    {
        //this bit is ugly and was not written for human eyes
        //it implements the set of behaviors from the first 100 lines of code
        bool alreadySelectingMe = selectingMe; // remember the state of selectingMe to detect selection start and stop
        selectingMe = (motionType != MotionType.Offset || bird.range > offset)
            && (( selectBehind && bird.birdRayHit.collider != null && bird.birdRayHit.collider == thisCollider)
                || (thisCollider != null && thisCollider.bounds.Contains(bird.birdPosition))
                || (thisCollider == null && thisRenderer != null && thisRenderer.bounds.Contains(bird.birdPosition))
                );
        if (activateType == ActivateType.Drag)
        {
            if (bird.down && selectingMe)
            {
                following = true;
                OnSelect.Invoke();
            }
            if (!bird.selected)
            {
                following = false;
                OnDeselect.Invoke();
            }
        }
        else if (activateType == ActivateType.Toggle)
        {
            if (following)
            {
                if (bird.down)
                {
                    following = false;
                    OnDeselect.Invoke();
                }
            }
            else
            {
                if (bird.down && selectingMe)
                {
                    OnSelect.Invoke();
                    following = true;
                }
            }
        }
        else if (activateType == ActivateType.Touch)
        {
            following = selectingMe;
            if (selectingMe)
            {
                following = true;
                if (!alreadySelectingMe)
                    OnSelect.Invoke();
            }
            else
            {
                following = false;
                if (alreadySelectingMe)
                    OnDeselect.Invoke();
            }
        }
        Vector3 targetPos;
        if (motionType == MotionType.Seek)
        {
            targetPos = bird.birdPosition;
        }
        else if (motionType == MotionType.Offset)
        {
            targetPos = bird.birdRay.direction * offset + bird.birdRay.origin;
        }
        else if (motionType == MotionType.SnapToCollider)
        {
            targetPos = previousTargetPos; // default if there is no ray hit is to stay put
            if (bird.rayWasHit)
            {
                if (snapColliders.Count == 0) // no specific colliders provided: snap to all colliders
                {
                    targetPos = bird.birdRayHit.point;
                }
                else
                {
                    foreach (Collider collider in snapColliders)
                    {
                        if (collider == bird.birdRayHit.collider)
                        {
                            targetPos = bird.birdRayHit.point;
                            break;
                        }
                    }
                }
            } else
            {
                targetPos = bird.birdPosition;
            }
        }
        else
        {
            //if motion type is none, this should happen.
            following = false;
            return;
        }
        if (following)
        {
            transform.position = filter.Update(targetPos); // actually move the object. Uses Kalman filter defined above.
            //start figuring out rotation
            Vector3 directionVector;
            Quaternion sourceRotation;
            if (orientationSource == OrientationSource.Bird)
            {
                directionVector = bird.birdRay.origin - bird.birdPosition;
                sourceRotation = bird.rotation;
            }
            else if (orientationSource == OrientationSource.ColliderNormal)
            {
                directionVector = bird.birdRayHit.normal;
                sourceRotation = Quaternion.AngleAxis(bird.twist, directionVector) * Quaternion.LookRotation(directionVector);
            }
            else
            {
                directionVector = bird.birdRay.origin - bird.birdPosition;
                sourceRotation = bird.rotation;
            }

            if (orientationMode == OrientationMode.KeepHeading)
            {
                // do not change the rotation
            }
            else if (orientationMode == OrientationMode.Horizontal)
            {
                Vector3 lookAtRotation = Quaternion.LookRotation(directionVector).eulerAngles;
                transform.rotation = Quaternion.Euler(Vector3.Scale(lookAtRotation, Vector3.up));
            }
            else if (orientationMode == OrientationMode.TwoAxis)
            {
                transform.rotation = Quaternion.LookRotation(directionVector);
            }
            else if (orientationMode == OrientationMode.Free)
            {
                transform.rotation = sourceRotation;
            }
            else if (orientationMode == OrientationMode.Free90Left)
            {
                transform.rotation = sourceRotation * Quaternion.AngleAxis(90, Vector3.up);
            }
            else if (orientationMode == OrientationMode.Free90Right)
            {
                transform.rotation = sourceRotation * Quaternion.AngleAxis(-90, Vector3.up);
            }
            else if (orientationMode == OrientationMode.FreeTwist90Right)
            {
                transform.rotation = sourceRotation * Quaternion.AngleAxis(90, Vector3.forward);
            }
            else if (orientationMode == OrientationMode.FreeTwist90Left)
            {
                transform.rotation = sourceRotation * Quaternion.AngleAxis(-90, Vector3.forward);
            }
            else if (orientationMode == OrientationMode.Free90Up)
            {
                transform.rotation = sourceRotation * Quaternion.AngleAxis(90, Vector3.right);
            }
            else if (orientationMode == OrientationMode.Free90Down)
            {
                transform.rotation = sourceRotation * Quaternion.AngleAxis(-90, Vector3.right);
            }
            else
            {
                //Don't change the rotation by default
            }
        }
        previousTargetPos = targetPos;
        if (motionType == MotionType.SnapToCollider)
        {
            if (following)
            {
                thisCollider.enabled = false;
            }
            else
            {
                thisCollider.enabled = true;
            }
            // yes I suppose I know it could just be thisCollider.enabled = !following, but this is more clear
        }
    }//end update
}
