using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int width = 20;
    public int height = 10;
    //public int height;

    // Start is called before the first frame update
    void Start()
    {
        int halfWidth = width / 2;

        for (int i = 0; i < height; i++)
        {
            for (int j = -halfWidth; j < halfWidth; j++)
            {
            	// Get position
                Vector3 pos = transform.TransformPoint(new Vector3(j, 0.5f + i, 0));

                // Create cube
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = pos;

                // Change colour & add mass
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.value, 1, 1);
                cube.AddComponent<Rigidbody>().mass = 0.1f;

                // Make the cube a child of the parent object
                cube.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
