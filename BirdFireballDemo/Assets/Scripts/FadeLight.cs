using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLight : MonoBehaviour
{
    Light light;
    public float fadeFactor = .98f;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity *= fadeFactor;
    }
}
