using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimator : MonoBehaviour
{
    private List<Vector3> offsets = new List<Vector3>();
    private List<Transform> segments = new List<Transform>();
    public bool useSpineAnimatorSystem = false;
    private float damping = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Transform current = transform.parent.GetChild(i);

            if (i > 0)
            {
                Transform prev = transform.parent.GetChild(i - 1);
                offsets.Add(current.transform.position - prev.transform.position);
                segments.Add(current);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for  (int i = 0; i < segments.Count; i++)
        {
            Transform prev = (i == 0) ? this.transform : segments[i - 1];
            Transform current = segments[i];
            Vector3 wantedPosition = prev.TransformPoint(offsets[i]);
            Quaternion wantedRotation = prev.rotation;
            current.position = Vector3.Lerp(current.position, wantedPosition, Time.deltaTime * damping);
            current.rotation = Quaternion.Slerp(current.rotation, wantedRotation, Time.deltaTime * damping);
        }
    }
}
