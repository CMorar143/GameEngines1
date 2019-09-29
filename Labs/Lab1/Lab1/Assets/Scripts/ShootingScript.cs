using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            float keytime = Time.time;

            Vector3 parent = transform.position;
            Vector3 pos = parent + new Vector3(0, 0, 2f);
            
            bullet = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bullet.transform.position = pos;

            bullet.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.value, 1, 1);
            bullet.AddComponent<Rigidbody>().mass = 0.1f;
        }

        Destroy(bullet, 5f);
        //while (bullet)
        //{
          //  bullet.transform.position = 
        //}
    }
}
