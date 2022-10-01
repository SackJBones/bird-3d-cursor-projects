using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToBird : MonoBehaviour
{
    Bird bird;
    public GameObject birdHand;
    bool stuck;
    Collider thisCollider;
    Renderer thisRenderer;

    // Start is called before the first frame update
    void Start()
    {
        bird = birdHand.GetComponent<Bird>();

        if (bird == null)
        {
            return;
        }
        thisCollider = gameObject.GetComponent<Collider>();
        thisRenderer = gameObject.GetComponent<Renderer>();
        stuck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((thisCollider != null && thisCollider.bounds.Contains(bird.birdPosition))
           || (thisCollider == null && thisRenderer != null && thisRenderer.bounds.Contains(bird.birdPosition)))
        {
            stuck = true;
        }
        if (stuck)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                transform.position = bird.birdPosition;
            }
            else
            {
                rb.MovePosition(bird.birdPosition);
            }
        }
    }
}
