using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float rotSpeed = 180.0f;
    public float fireRate = 5.0f;
    public Transform bulletSpawnPoint;
    public Transform Tank;
    public GameObject bulletPrefab;
    private bool hasCoroutineStarted = false;
    private float timeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (hasCoroutineStarted)
            {
                GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            }

            yield return new WaitForSeconds(1.0f / fireRate);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tank" && !hasCoroutineStarted)
        {
            hasCoroutineStarted = true;
            StartCoroutine(Shoot());
            Debug.Log("onTriggerEnter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tank")
        {
            hasCoroutineStarted = false;
            Debug.Log("onTriggerExit");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tank" && hasCoroutineStarted)
        {
            Debug.Log("onTriggerStay");

            Vector3 toPlayer = other.transform.position - transform.position;

            transform.rotation = Quaternion.RotateTowards
                (
                    transform.rotation,
                    Quaternion.LookRotation(-toPlayer), 
                    rotSpeed * Time.deltaTime
                );
        }
    }
}
