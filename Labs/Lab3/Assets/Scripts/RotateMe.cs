using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    Vector3 axis, axis2;
    public float speed = 1.0f;
    float lerpSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        axis = Vector3.up;
        axis2 = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        lerpSpeed = Mathf.Lerp(lerpSpeed, speed, Time.deltaTime);
        transform.Rotate(axis, lerpSpeed * Time.deltaTime * 360);
        transform.Rotate(axis2, lerpSpeed * Time.deltaTime * 360);
    }
}
