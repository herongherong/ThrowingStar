using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateShuriken : MonoBehaviour
{
    public float turnSpeed = 5.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed);
    }
}
