using UnityEngine;
using System.Collections;
using System;


public class Enemy02 : EnemyBehaviours
{
    
    //for dealing with Grenade explosions
    [SerializeField]
    private SpriteRenderer sprite;

    // time befor shooting again
    private float countDowntime = 1.15f;

   

    int flaresFired = 0;

    int countHits = 0;

    // Update is called once per frame
    void Update()
    {
       
        countDowntime -= Time.deltaTime;

        /*
         * RayCasting - draw invisible line of sight, to determine if player is in sight
         * and shoot him
         */

        // check of Player in sight is
        RaycastHit2D hit = Physics2D.Raycast(lineStart.position, Vector3.left, 90); //45

        //is er een hit, en is er genoeg tijd tussen het vorige schot?
        //controleer of er een hit met de player is



        if (hit.collider != null && countDowntime <= 0 && hit.transform.tag.Equals("Player")) //"Player" hit.transform.name.Equals("Player")) MainPlayer
        {

            countHits++;
            Player.showLaserDot = true;

            Fire();

            // TODO RayCast Example
            Debug.DrawRay(lineStart.position, Vector3.left * 45f, Color.green);

            //Debug.DrawLine(lineStart.position, lineEnd.position, Color.red);
        }
        else if (hit.collider == null && countHits > 0)
        {
            Player.showLaserDot = false;
        }

        healthBar.transform.localScale = new Vector3(health / 100, 1, 1);

        CheckHealth();

    }

    void CheckHealth()
    {
        
        if (health <= 50 && flaresFired == 0)
        {
           
        }
    }

    void Fire()
    {
        
        countDowntime = 1.15f;

        GameObject kogel = Instantiate(bullet, barrel.position, Quaternion.identity) as GameObject;
        kogel.transform.rotation = Quaternion.Euler(0, 0, 5);
        kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(-80, -20, 0); // bullet speed in -X position

      
        //GameObject huls = Instantiate(shell, transform.position, Quaternion.identity) as GameObject;
        // geen as GameObject want we doen er niets mee in code, wordt vernietigd door shredder
        Instantiate(shell, transform.position, Quaternion.identity);
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        //get amount of damage

        //check first if we are colliding with a Player Projectile 
        //if so, get Damage value from Player Projectile

        if (objectCollidedwith.GetComponent<PlayerProjectileDamage>())
        {
            float damage = objectCollidedwith.GetComponent<PlayerProjectileDamage>().damage;

            health -= damage;
            Destroy(objectCollidedwith); // destroy Player projectile
        }

        //kill the enemy
        KillEnemy();

       

        // Hit by Grenade
        //TODO rigidbody AddForce ?
        if (objectCollidedwith.tag == "Grenade")
        {

            Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();

            // player komt ondersteboven
            sprite.flipY = true;
            rigid.velocity = new Vector3(50, 25, 0);
            Destroy(gameObject, 1.5f);

            //this.GetComponent<Rigidbody2D>().velocity = new Vector3(30, 15, 0);
        }
    }   
}