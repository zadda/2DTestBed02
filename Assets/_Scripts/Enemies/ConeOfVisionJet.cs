using UnityEngine;
using System.Collections;

public class ConeOfVisionJet : MonoBehaviour
{

    private float timeSinceDetected = 0f;
    public static bool playerDetected = false;

    private SpriteRenderer sprite;
    [SerializeField]
    private Color playerDetectedColour;

    [SerializeField]
    private Color enemyDetected;

    private Color defaultColour;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defaultColour = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerDetected)
        {
            timeSinceDetected += Time.deltaTime;
        }


        if (timeSinceDetected >= 0.5f)
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
            sprite.color = playerDetectedColour;
            
            playerDetected = true;
           // Debug.Log("cone hit detected!!");
        }

        if (objectCollidedwith.tag.Equals("Enemy"))
        {
            sprite.color = enemyDetected;
            playerDetected = false;
        }

    }

    void Attack()
    {
        timeSinceDetected = 0f;
        EnemyJet.isBombing = true;
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