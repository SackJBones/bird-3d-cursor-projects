using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnChild : MonoBehaviour
{
    public GameObject child;
    Vector3 spawnPos;

    void Start()
    {
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            Instantiate(child, spawnPos, transform.rotation, transform);
        }
    }
}
