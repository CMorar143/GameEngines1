using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8.0f;
    public float rotSpeed = 80.0f;

    // Start is called before the first frame update
    void Start()
    {
        Follow.Player = this.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        transform.Rotate(0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed, 0f);
    }
}
