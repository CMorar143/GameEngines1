using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float speed = 10f;
    public float rotspeed = 65f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        transform.Rotate(0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotspeed, 0f);
    }
}
