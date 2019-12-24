using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleGenerator : MonoBehaviour
{
    public int segments = 10;
    public float gap = 0.01f;
    public GameObject segmentPrefab;
    public GameObject headPrefab;
    Vector3 offset;

    // Use this for initialization
    void Awake()
    {
        offset = -Vector3.forward * (gap);
        for (int i = 0; i < segments; i++)
        {
            Vector3 pos = offset * i;
            GameObject prefab = (i == 0) ? headPrefab : segmentPrefab;
            prefab = GameObject.Instantiate<GameObject>(prefab);
            prefab.transform.position = transform.TransformPoint(pos);
            prefab.transform.rotation = transform.rotation;
            prefab.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)segments, 1, 1);
            prefab.transform.parent = this.transform;

            //Vector3 lp = offset * i;
            //GameObject prefab = (i == 0) ? headPrefab : segmentPrefab;
            //GameObject segment = GameObject.Instantiate<GameObject>(prefab);
            //segment.transform.position = transform.TransformPoint(lp);
            //segment.transform.rotation = transform.rotation;
            //segment.transform.parent = this.transform;
            //segment.GetComponent<Renderer>().material.color =
            //Color.HSVToRGB(i / (float)segments, 1, 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
