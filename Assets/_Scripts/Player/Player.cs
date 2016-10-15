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

    [SerializeField]
    private SpriteRenderer spriteColour;

    [SerializeField]
    private Color colour;

    [SerializeField]
    private SpriteRenderer gasMask;

    //access for other scripts:
    public static float playerX = 0f;
    public static float playerY = 0f;
    public static float walkSpeed = 0.25f;

    private Color startKleur;
    private bool hitByGas = false;

    private float gasEffectDuration = 2.5f;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        gun.transform.position = new Vector3(11 - 1.5f, 3 + 4);
        startKleur = spriteColour.color;

    }


    void Update()
    {
        if (Input.GetButton("GasMask"))
        {
           gasMask.enabled = true;
        }

        if(Input.GetButton("GasMaskOff"))
        {
            gasMask.enabled = false;
        }


        

        GasEffectCheck();

        //updates the position
        playerX = transform.position.x;
        playerY = transform.position.y;
        Move();
    }

    void Move()
    {
        //movement
        

        if (hitByGas)
        {
            if (Input.GetButton("Right"))
            {
                //move player
                sprite.flipX = true;
                transform.position += Vector3.left * walkSpeed;
            }
            if (Input.GetButton("Left"))
            {
                //move player right
                sprite.flipX = false;
                transform.position += Vector3.right * walkSpeed;
            }
        }
        
        if (!hitByGas)
        {
            if (Input.GetButton("Left"))
            {
                //move player
                sprite.flipX = true;
                transform.position += Vector3.left * walkSpeed;
            }


            //if (Input.GetButton("Left"))


            if (Input.GetButton("Right"))
            {
                //move player right
                sprite.flipX = false;
                transform.position += Vector3.right * walkSpeed;
            }
        }

       
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    GameObject objectCollidedwith = collision.gameObject;
        

    //}

    //gas grenade detection
    //TODO add effect of grenade, invert movement keys, give player green colour:




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

        if (objectCollidedwith.tag == "GasGrenade" && gasMask.enabled == false)
        {

            hitByGas = true;
            Debug.Log("Geraakt door gasgranaat");
            spriteColour.color = colour;

        }


        // #######################################################
        //TODO player hit by bomb addForce
        //if collide with enemy bomb, move player axis -x
        // /!\ probleem camera volgt speler, tijdelijk uitschakelen?
        // #######################################################
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

    void GasEffectCheck()
    {
        if (hitByGas)
        {
            gasEffectDuration -= Time.deltaTime;
        }

        if (gasEffectDuration <= 0)
        {
            hitByGas = false;
            spriteColour.color = startKleur;
            gasEffectDuration = 2.5f;
        }
       
    }
}