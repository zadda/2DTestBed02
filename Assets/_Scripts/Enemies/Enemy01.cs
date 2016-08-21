using UnityEngine;
using System.Collections;

public class Enemy01 : MonoBehaviour
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


    private float countDowntime = 2.35f;

    public float health = 120;

    private bool ceaseFire = false;

    private float flashGrenadeDuration = 5;

    private int layer = 10;

    private int mask;

    // Use this for initialization
    void Start()
    {
        int mask = 1 << layer;
    }

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
        RaycastHit2D hit = Physics2D.Raycast(lineStart.position, Vector3.left, 45);



        //is er een hit, en is er genoeg tijd tussen het vorige schot?
        //controleer of er een hit met de player is

        //TODO clean up function, check if hitting player or Shield tag??
        if (hit.collider != null && countDowntime <= 0 && hit.transform.name.Equals("Shield")) //"Player"
        {
            Fire();

            // TODO RayCast Example
            Debug.DrawRay(lineStart.position, Vector3.left * 45f, Color.green);
            
            //Debug.DrawLine(lineStart.position, lineEnd.position, Color.red);
        }
    }

    void Fire()
    {

        if (ceaseFire)
        {
            return;
        }
        countDowntime = 2.35f;

        GameObject kogel = Instantiate(bullet, barrel.position, Quaternion.identity) as GameObject;
        kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(-40, 0, 0);

        //beweeg enemy naar Player toe

        transform.position += new Vector3(-3f, 0f);

        //GameObject huls = Instantiate(shell, transform.position, Quaternion.identity) as GameObject;
        Instantiate(shell, transform.position, Quaternion.identity);
    }

   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        //get amount of damage

        //check first if we are colliding by a Player Projectile 
        //if so, get Damage value from Player Projectile

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
            
            //this.GetComponent<Rigidbody2D>().velocity = new Vector3(30, 15, 0);
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