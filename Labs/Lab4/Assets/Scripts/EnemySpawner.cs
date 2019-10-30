using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyTankPrefab;
    private bool isCoroutineExecuting = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator Create(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        GameObject enemy = GameObject.Instantiate<GameObject>(EnemyTankPrefab);

        Vector3 newPos = new Vector3(UnityEngine.Random.Range(-6.0f, 6.0f), 0.0f, UnityEngine.Random.Range(-6.0f, 6.0f));
        enemy.transform.position = transform.position + newPos;
        enemy.AddComponent<Rigidbody>();
        enemy.tag = "EnemyTank";

        isCoroutineExecuting = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] EnemyTanks = GameObject.FindGameObjectsWithTag("EnemyTank");
        int EnemyCount = EnemyTanks.Length;

        if (EnemyCount < 5)
        {
            StartCoroutine(Create(1));
        }
    }
}