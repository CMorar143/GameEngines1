using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float speed = 5f;
    public float rotspeed = 65f;
    public int fireRate = 3;

    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    float ellapsed = float.MaxValue;

    System.Collections.IEnumerator Shooting()
    {
        float timer = 1.0f / fireRate;
        while (true)
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.transform.rotation = transform.rotation;
            yield return new WaitForSeconds(timer);
        }
    }

    private void OnEnable()
    {
        //Generally start Coroutines in here
    }

    Coroutine cr;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        transform.Rotate(0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotspeed, 0f);
        float timer = 1.0f / fireRate;
        ellapsed += Time.deltaTime;

        if (Input.GetKey("space") && ellapsed > timer)
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.transform.rotation = transform.rotation;
            ellapsed = 0;
        }
    }
}
