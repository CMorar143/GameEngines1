using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public static Transform Player;
    public float speed = 6.0f;
    private float interpolation;


    // Update is called once per frame
    void Update()
    {
        Player = player;
        interpolation = speed * Time.deltaTime;

        this.transform.position = Vector3.Lerp(this.transform.position, player.position, interpolation);
        transform.LookAt(player.parent);
    }
}