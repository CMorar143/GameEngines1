using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public int numWayPoints = 12;
    public float radius = 20;
    public List<Vector3> wayPoints = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        wayPoints.Clear();
        float gap = (Mathf.PI * 2.0f) / (float)numWayPoints;

        for (int i = 0; i < numWayPoints; i++)
        {
            Vector3 pos = new Vector3(
                Mathf.Sin(gap * i) * radius,
                -10,
                Mathf.Cos(gap * i) * radius
                );

            pos = transform.TransformPoint(pos);
            wayPoints.Add(pos);
        }
    }

    public void OnDrawGizmos()
    {
        foreach (Vector3 p in wayPoints)
        {
            Gizmos.DrawWireSphere(p, 2);
        }
    }

    // Use this for initialization
    void Awake()
    {
        float thetaInc = (Mathf.PI * 2) / (float)numWayPoints;
        for (int i = 0; i < numWayPoints; i++)
        {
            float theta = i * thetaInc;
            Vector3 pos = new Vector3(Mathf.Sin(theta) * radius, -10, Mathf.Cos(theta) * radius);
            pos = transform.TransformPoint(pos);
            wayPoints.Add(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
