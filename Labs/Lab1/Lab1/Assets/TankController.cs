using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private TankController Tank;
    public float speed = 5f;
    public float rotspeed = 45f;

    // Start is called before the first frame update
    void Start()
    {
        Tank = GetComponent<TankController>();
    }

    // Update is called once per frame
    void Update()
    {
        Tank.transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        Tank.transform.Rotate(0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotspeed, 0f);
    }
}
