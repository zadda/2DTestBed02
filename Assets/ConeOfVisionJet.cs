using UnityEngine;
using System.Collections;

public class ConeOfVisionJet : MonoBehaviour
{

    private float timeSinceDetected = 0f;
    private bool playerDetected = false;

    private SpriteRenderer sprite;
    [SerializeField]
    private Color colour;

    private Color defaultColour;
    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defaultColour = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timeSinceDetected);

        if (playerDetected)
        {
            timeSinceDetected += Time.deltaTime;
        }


        if (timeSinceDetected >= 5f)
        {
            //EnemyJet.Fire()
            Attack();
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        //get amount of damage

        //check first if we are colliding by a Player Projectile 
        //if so, get Damage value from Player Projectile

        if (objectCollidedwith.transform.name.Equals("ConeHitArea"))
        {
            sprite.color = colour;
            
            playerDetected = true;
           // Debug.Log("cone hit detected!!");
        }

    }

    void Attack()
    {
        timeSinceDetected = 0f;
        Debug.Log("Attack iniated!!");
        //sprite.color.r = 55f;
        //GetComponent<SpriteRenderer>().color = 

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        if (objectCollidedwith.transform.name.Equals("ConeHitArea"))
        {
            playerDetected = true;
        }

       
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;
        if (objectCollidedwith.transform.name.Equals("ConeHitArea"))
        {
            playerDetected = false;
            timeSinceDetected = 0f;
            sprite.color = defaultColour;
        }
       
    }
}