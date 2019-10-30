using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    GameObject Tank;

    // Start is called before the first frame update
    void Start()
    {
        Tank = this.transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerController>().enabled = false;
            this.transform.gameObject.GetComponent<RotateMe>().enabled = false;
            Tank.GetComponent<TankController>().enabled = true;
            Tank.GetComponent<AITankController>().enabled = false;
            Follow.Player = Tank.transform.GetChild(2);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Follow.Player = Tank.transform.GetChild(2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
