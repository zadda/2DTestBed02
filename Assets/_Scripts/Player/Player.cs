using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

    public static float playerHealth = 500;
    

    private SpriteRenderer sprite;
    
    [SerializeField]
    private Gun gun;
    [SerializeField]
    private ShotGun shotgun;
    [SerializeField]
    private MachineGun machinegun;
    [SerializeField]
    private Sniper sniper;
    [SerializeField]
    private RPG rpg;

    [SerializeField]
    private FlashBang flashBang;
    [SerializeField]
    private Grenade grenade;
    [SerializeField]
    private SmokeGrenade smoke;

    
    //access for other scripts:
    public static float playerX = 0f;
    public static float playerY = 0f;
    public static float walkSpeed = 0.25f;


   
    void Start () 
	{
        sprite = GetComponent<SpriteRenderer>();

        gun.transform.position = new Vector3(11 - 1.5f, 3 + 4);
        
    }
	
	
	void Update () 
	{

        //updates the position
        playerX = transform.position.x;
        playerY = transform.position.y;
        Move();
    }

    void Move()
    {
        //movement

        if (Input.GetKey(KeyCode.Q))
        {
            //move player
            sprite.flipX = true;
            transform.position += Vector3.left * walkSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //move player right
            sprite.flipX = false;
            transform.position += Vector3.right * walkSpeed;
        }
    }
    
    

    // Enemy Projectile detection

     void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        //get amount of damage

        //check first if we are colliding by a Player Projectile 
        //if so, get Damage value from Player Projectile

        if (objectCollidedwith.GetComponent<EnemyProjectileDamage>())
        {
            float damage = objectCollidedwith.GetComponent<EnemyProjectileDamage>().damage;

            playerHealth -= damage;
            Destroy(objectCollidedwith);
        }

        //TODO player hit by bomb addForce
        //if collide with enemy bomb, move player axis -x

        //if (objectCollidedwith.tag == "Bomb")
        //{
        //    sprite.transform.position -= new Vector3(15, 0, 0);
        //}


        if (playerHealth <= 0)
        {
            //TODO game over or lose life
            //Destroy(gameObject);
        }
    }
}