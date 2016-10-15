using UnityEngine;
using System.Collections;



public class EnemyBehaviours : MonoBehaviour 
{

    //necessary for Raycast hit detection
    
    public Transform lineStart;
   
    public Transform lineEnd;

    //Ammo prefabs and start point

    public GameObject bullet;


    public GameObject shell;


    public Transform barrel;


    public GameObject flares;

    //health
    
    public float health = 120;
    
    public GameObject healthBar;

    // Use this for initialization
    void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    public void PrintDebugWarning()
    {
        Debug.Log("Test inheritance success!");
    }

    public void KillEnemy()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HitByFlash(Collider2D collider)
    {

    }

}
