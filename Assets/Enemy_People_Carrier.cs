using UnityEngine;
using System.Collections;

public class Enemy_People_Carrier : MonoBehaviour 
{
    [SerializeField]
    private GameObject enemyToSpawn;

    [SerializeField]
    private Transform spawnPoint;


    // Use this for initialization
    void Start () 
	{
        GameObject enemy = Instantiate(enemyToSpawn, spawnPoint.transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
    }
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
