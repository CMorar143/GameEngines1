using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class AITankController : MonoBehaviour
{
    public int numWayPoints = 5;
    public float radius = 10;
    private int current = 0;
    public float speed = 10;
    public Transform player;
    private List<Vector3> wayPoints = new List<Vector3>();
    private static StringBuilder message = new StringBuilder();

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnDrawGizmos()
    {
        //Prevent the gizmos from moving with the AI tank
        if (!Application.isPlaying)
        {
            //gap is splitting the circumference into different segments
            float gap = (Mathf.PI * 2.0f) / (float)numWayPoints;
            for (int i = 0; i < numWayPoints; i++)
            {
                Vector3 pos = new Vector3(
                    Mathf.Sin(gap * i) * radius,
                    0,
                    Mathf.Cos(gap * i) * radius
                    );
                pos = transform.TransformPoint(pos);
                Gizmos.DrawWireSphere(pos, 2);
            }
        }
    }

    // Use this for initialization
    void Awake()
    {
        float thetaInc = (Mathf.PI * 2) / (float)numWayPoints;
        for (int i = 0; i < numWayPoints; i++)
        {
            float theta = i * thetaInc;
            Vector3 pos = new Vector3(Mathf.Sin(theta) * radius, 0, Mathf.Cos(theta) * radius);
            pos = transform.TransformPoint(pos);
            wayPoints.Add(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = wayPoints[current] - transform.position;

        if (target.magnitude < 1)
        {
            current = (current + 1) % wayPoints.Count;
        }

        target.Normalize();
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(target),
            Time.deltaTime * 5
            );
        transform.Translate(target * speed * Time.deltaTime, Space.World);

        Vector3 toPlayer = player.position - transform.position;

        if (Vector3.Dot(transform.forward, toPlayer) < 0)
        {
            Log("Player is behind");
        }

        else
        {
            Log("Player is in front");
        }

        float angle = Mathf.Acos(Vector3.Dot(transform.forward, toPlayer) / toPlayer.magnitude) * Mathf.Rad2Deg;
        Log("angle to player 1 is: " + angle);
        
        if (angle < 45)
        {
            Log("Player is in FOV");
        }

        else
        {
            Log("Player is out of FOV");
        }
    }

    public void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "" + message);
        if (Event.current.type == EventType.Repaint)
        {
            message.Length = 0;
        }
    }

    public static void Log(string text)
    {
        message.Append(text + "\n");
    }
}