/*
 * disabled on the start
 * enabled by player walking on Trigger
 * spawns 3 enemies, then flies along
 * 
 */

using UnityEngine;
using System.Collections;
using System;

public class Enemy_People_Carrier : MonoBehaviour 
{
    [SerializeField]
    private GameObject enemyToSpawn;

    [SerializeField]
    private Transform spawnPoint;

    private float countDownTime = 2.5f;

    private int maxNumberToSpawn = 2;

    private int enemiesSpawned = 0;

    // Use this for initialization
    void Start()
    {
        GameObject enemy = Instantiate(enemyToSpawn, spawnPoint.transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
    }

    // Update is called once per frame
    void Update () 
	{
        transform.Translate(Vector3.left * 10.5f * Time.deltaTime);
        countDownTime -= Time.deltaTime;

        SpawnEnemy();

	}

    private void SpawnEnemy()
    {

        if (countDownTime <= 0 && enemiesSpawned < maxNumberToSpawn)
        {
            // increase limits
            enemiesSpawned++;
            countDownTime = 2.5f;
            GameObject enemy = Instantiate(enemyToSpawn, spawnPoint.transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        }


    }
}
