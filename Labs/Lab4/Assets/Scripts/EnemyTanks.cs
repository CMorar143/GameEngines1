using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTanks : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    void KillMe()
    {
        GameObject.Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Collided");
            ExplodeMyParts();
        }
    }

    private void ExplodeMyParts()
    {
        foreach (Transform t in this.GetComponentsInChildren<Transform>())
        {
            Rigidbody rb = t.gameObject.GetComponent<Rigidbody>();

            if (rb == null)
            {
                rb = t.gameObject.AddComponent<Rigidbody>();
            }

            rb.useGravity = true;
            rb.isKinematic = false;

            Vector3 v = new Vector3(
                Random.Range(-5, 5)
                , Random.Range(5, 10)
                , Random.Range(-5, 5)
                );

            rb.velocity = v;
        }

        Invoke("Sink", 4);
        Invoke("KillMe", 7);
    }

    void Sink()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().drag = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
