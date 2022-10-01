using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject exp;
    public GameObject flash;
    public float radius;
    public float expForce;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 fromPoint = collision.GetContact(0).point;
        GameObject _exp = Instantiate(exp, fromPoint, transform.rotation);
        Destroy(_exp, 5);
        GameObject _flash = Instantiate(flash, fromPoint, transform.rotation);
        Destroy(_flash, .1f);
        knockBack(fromPoint);
        Destroy(gameObject);
    }

    void knockBack(Vector3 fromPoint)
    {
        Collider[] colliders = Physics.OverlapSphere(fromPoint, radius);

        foreach (Collider nearby in colliders)
        {
            Rigidbody rig = nearby.GetComponent<Rigidbody>();
            if (rig != null)
            {
                rig.AddExplosionForce(expForce, fromPoint, radius);
            }
        }
    }
}
