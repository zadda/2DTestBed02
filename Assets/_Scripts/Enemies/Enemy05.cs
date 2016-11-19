using UnityEngine;
using System.Collections;

public class Enemy05 : EnemyBehaviours
{

    private float healthBarCountdown = 3.5f;

    // time befor shooting again
    private float countDowntime = 0.85f;

    private bool ceaseFire = false;

    private float flashGrenadeDuration = 5f;

    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private BoxCollider2D boxCol;

    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private Transform shellEjection;

    

    // Update is called once per frame
    void Update()
    {

        //disable Trigger on Enemy when StealthBomber is called for *Maximum Effect*

        //if (SmokeGrenade.jetCalled)
        //{
        //    boxCol.isTrigger = false;
        //}

        healthBarCountdown -= Time.deltaTime;

        if (healthBarCountdown <= 0)
        {
            healthBar.SetActive(true);
        }

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
            //Fire();

            // TODO RayCast Example
            Debug.DrawRay(lineStart.position, Vector3.left * 45f, Color.green);

            //Debug.DrawLine(lineStart.position, lineEnd.position, Color.red);
        }

        healthBar.transform.localScale = new Vector3(health / 140, 1, 1);

        CheckHealth();
    }

    void CheckHealth()
    {
        if (health <= 50)// && flaresFired == 0)
        {
        }
    }

    void Fire()
    {

        if (ceaseFire)
        {
            return;
        }
        countDowntime = 0.85f;

        GameObject kogel = Instantiate(bullet, barrel.position, Quaternion.identity) as GameObject;
        kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(-40, 0, 0); // bullet speed in -X position

        //beweeg enemy naar Player toe

        transform.position += new Vector3(-4f, 0f);


        //GameObject huls = Instantiate(shell, transform.position, Quaternion.identity) as GameObject;
        // geen as GameObject want we doen er niets mee in code, wordt vernietigd door shredder
        Instantiate(shell, shellEjection.position, Quaternion.identity);
    }



    //##################################
    //TEST
    //###################################

    void OnCollisionEnter2D(Collision2D collision)
    {

        
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        Vector2 addedForce = new Vector2(30, 15);

        if (collision.gameObject.tag.Equals("Bomb"))
        {
            rigid.AddForce(addedForce, ForceMode2D.Force);
        }

        //get amount of damage

        //check first if we are colliding with a Player Projectile 
        //if so, get Damage value from Player Projectile

        if (objectCollidedwith.GetComponent<PlayerProjectileDamage>())
        {
            float damage = objectCollidedwith.GetComponent<PlayerProjectileDamage>().damage;

            health -= damage;
            //Debug.Log("health of Enemy01 " + health);
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
            Destroy(gameObject, 1.5f);

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
