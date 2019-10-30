using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Tank;
    public float speed = 6.0f;
    private float interpolation;


    // Update is called once per frame
    void Update()
    {
        interpolation = speed * Time.deltaTime;

        this.transform.position = Vector3.Lerp(this.transform.position, Tank.position, interpolation);
        transform.LookAt(Tank.parent);
    }
}
