using UnityEngine;
using System.Collections;
using System;

public class Enemy01 : MonoBehaviour
{

    //necessary for Raycast hit detection
    [SerializeField]
    private Transform lineStart;
    [SerializeField]
    private Transform lineEnd;

    //Ammo prefabs and start point
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject shell;

    [SerializeField]
    private Transform barrel;

    [SerializeField]
    private GameObject flares;

    //for dealing with Grenade explosions
    [SerializeField]
    private SpriteRenderer sprite;

    // time befor shooting again
    private float countDowntime = 1.15f;

    [SerializeField]
    private float health = 120;

    private bool ceaseFire = false;

    private float flashGrenadeDuration = 5;

    public static Vector3 enemyPosition;

    // Update is called once per frame
    void Update()
    {
        // ceaseFire true means enemy is hit by Flash grenade
        if (ceaseFire)
        {
            HitByFlashEffect();
        }
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
            Fire();

            // TODO RayCast Example
            Debug.DrawRay(lineStart.position, Vector3.left * 45f, Color.green);
            
            //Debug.DrawLine(lineStart.position, lineEnd.position, Color.red);
        }

        CheckHealth();

    }

    void CheckHealth()
    {
        

        if (health <= 50 && EnemyHeli.heliCalled == false)
        {
            // launch Flare and call HeliSupport
           EnemyHeli.heliCalled = true;

            enemyPosition = transform.position;

            ceaseFire = true;
            sprite.flipX = true;

            GameObject flare = Instantiate(flares, barrel.position, Quaternion.identity) as GameObject;
            //transform.Translate(Vector3.up * 220.5f * Time.deltaTime);
             flare.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 30, 0); // bullet speed in -X position

            //move player
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(40, 0, 0);
        }
    }

    void Fire()
    {

        if (ceaseFire)
        {
            return;
        }
        countDowntime = 1.15f;

        GameObject kogel = Instantiate(bullet, barrel.position, Quaternion.identity) as GameObject;
        kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(-40, 0, 0); // bullet speed in -X position

        //beweeg enemy naar Player toe

        transform.position += new Vector3(-3f, 0f);

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
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        // Hit by FlashGrenade -> cease fire flip sprite

        if (objectCollidedwith.tag == "Flash")
        {
            ceaseFire = true;
            HitByFlashEffect();
        }

        // Hit by Grenade
        //TODO rigidbody AddForce ?
        if (objectCollidedwith.tag == "Grenade")
        {

            Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();

            // player komt ondersteboven
            sprite.flipY = true;
            rigid.velocity = new Vector3(50, 25, 0);
            
            //this.GetComponent<Rigidbody2D>().velocity = new Vector3(30, 15, 0);
        }
    }

    //decide what to do when hit by Flash grenade, for x amount of " flip the enemy sprite to create
    // confused behaviour

    void HitByFlashEffect()
    {
        flashGrenadeDuration -= Time.deltaTime;

        //keep flipping the enemy
        if (flashGrenadeDuration >= 0)
        {
            sprite.flipX = true;
            Invoke("FlipXFalse", 1f);
        }
        else
        {
            ceaseFire = false;
            flashGrenadeDuration = 5;
        }
    }

    void FlipXFalse()
    {
        sprite.flipX = false;
    }

}