
/*
 * similar to Enemy01.cs
 * commented more in depth there
 */

using UnityEngine;
using System.Collections;

public class Enemy03 : MonoBehaviour
{
    [SerializeField]
    private Transform lineStart;
    [SerializeField]
    private Transform lineEnd;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject shell;

    [SerializeField]
    private Transform barrel;

    [SerializeField]
    private SpriteRenderer sprite;


    private float countDowntime = 1.15f;
    [SerializeField]
    private GameObject healthBar;

    //private SpriteRenderer healthSprite;
    public float health = 200;
    public static bool stopAttacking = false;

    private bool ceaseFire = false;

    private float flashGrenadeDuration = 5;

    private Animator animWave;

    void Start()
    {
        animWave = GetComponent<Animator>();
    }



    void Update()
    {
        // ceaseFire true means enemy is hit by Flash grenade
        if (ceaseFire)
        {
            HitByFlashEffect();
        }
        countDowntime -= Time.deltaTime;

        //if we are about to collide with player or Shield, stop moving and shooting
        // TODO switch to melee combat?
        if (stopAttacking)
        {
            return;
        }


        /*
         * RayCasting - draw invisible line of sight, to determine if player is in sight
         * and shoot him
         */

        // check of Player in sight is
        RaycastHit2D hit = Physics2D.Raycast(lineStart.position, Vector3.left, 90); //45



        //is er een hit, en is er genoeg tijd tussen het vorige schot?
        //controleer of er een hit met de player is

        //check if hitting player or Shield tag??
        if (hit.collider != null && countDowntime <= 0 && hit.transform.tag.Equals("Player"))
        {
            Fire();
        }

        CheckHealth();

        healthBar.transform.localScale = new Vector3(health / 150, 1, 1);
    }

    void CheckHealth()
    {
        if (health <= 70 && EnemyJet.jetCalled == false)
        {
            animWave.SetTrigger("SendWaveSignal");
            EnemyJet.jetCalled = true;
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
        kogel.transform.rotation = Quaternion.Euler(0, 0, 351);
        kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(-50, barrel.rotation.z * 100+2, 0);

        //beweeg enemy naar Player toe

        transform.position += new Vector3(-3f, 0f);

        //GameObject huls = Instantiate(shell, transform.position, Quaternion.identity) as GameObject;
        Instantiate(shell, transform.position, Quaternion.identity);
    }

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        if (objectCollidedwith.GetComponent<PlayerProjectileDamage>())
        {
            float damage = objectCollidedwith.GetComponent<PlayerProjectileDamage>().damage;

            health -= damage;
            Destroy(objectCollidedwith);
        }

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

        if (objectCollidedwith.tag == "Grenade")
        {

            Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();

            // player komt ondersteboven
            sprite.flipY = true;
            rigid.velocity = new Vector3(50, 25, 0);
            Destroy(gameObject, 1.5f);
        }
    }

    //decide what to do when hit by Flash grenade, for x amount of " flip the enemy sprite to create
    // confused behaviour

    void HitByFlashEffect()
    {
        flashGrenadeDuration -= Time.deltaTime;

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