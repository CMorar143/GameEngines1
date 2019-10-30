using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform CameraTarget;

    public float speed = 2.0f;
    private float interpolation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interpolation = speed * Time.deltaTime;
        transform.position = Vector3.Lerp(this.transform.position, CameraTarget.position, interpolation);
        transform.LookAt(CameraTarget.parent);
    }
}
