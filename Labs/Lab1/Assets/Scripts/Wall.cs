﻿using System.Collections;
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

        for (int j = 0; j < height; j++)
        {
            for (int i = -halfWidth; i < halfWidth; i++)
            {
                Vector3 pos = transform.TransformPoint(new Vector3(i, 0.5f + j, 0));

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = pos;

                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.value, 1, 1);
                cube.AddComponent<Rigidbody>().mass = 0.1f;
                cube.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
