using UnityEngine;
using System.Collections;

public class Enemy05 : EnemyBehaviours 
{

    private float countDownTime = 3.5f;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

        countDownTime -= Time.deltaTime;

        if (countDownTime <= 0)
        {
            healthBar.SetActive(true);
        }

	}
}
