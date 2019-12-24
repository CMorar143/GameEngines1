using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    public Path path;
    private int currentWaypoint = 0;
    public List<Vector3> waypoints = new List<Vector3>();
    public float mass = 1.0f;
    public float maxSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<Path>();
        for (int i = 0; i < path.numWayPoints; i++)
        {
            waypoints[i] = path.wayPoints[i];
        }
        Debug.Log(path.numWayPoints);
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the path
        if (Vector3.Distance(waypoints[currentWaypoint], transform.position) < 1.0f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        }
        Vector3 desired = waypoints[currentWaypoint] - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        Vector3 force = desired - velocity;

        Vector3 acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        transform.Translate(velocity * Time.deltaTime, Space.World);
        transform.forward = velocity;
    }
}
