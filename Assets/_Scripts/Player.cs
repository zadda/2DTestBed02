using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

    
    private float runSpeed = 10f;
    private SpriteRenderer sprite;
    
    [SerializeField]
    private GameObject crosshair;
   

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


    private float maxDistanceCrossGunX = 25;
    private float maxDistanceCrossGunY = 25;





    //access for other scripts:
    public static float playerX = 0f;
    public static float playerY = 0f;

    public static string selectedWeapon = "Gun";
    public static float walkSpeed = 0.25f;


    // Use this for initialization
    void Start () 
	{
        sprite = GetComponent<SpriteRenderer>();

        //start positie CrossHair
        //crosshair.transform.position = new Vector3(10, 10);
    }
	
	// Update is called once per frame
	void Update () 
	{

        //updates the position
        playerX = transform.position.x;
        playerY = transform.position.y;
        Move();

        if (selectedWeapon == "Gun")
        {
            MoveCrossHairGun();
        }

        if (selectedWeapon == "ShotGun")
        {
            ShotGunFire();
        }

        if (selectedWeapon == "MachineGun")
        {
            MachineGunFire();
        }

        if (selectedWeapon == "Sniper")
        {
            SniperFire();
        }
        if (selectedWeapon == "RPG")
        {
            RPGFire();
        }
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

    void MoveCrossHairGun()
    {

        //Move Gun Z rotation
        //TODO maxDistance gebruiken
        // CrossHair with HandGun
        Vector3 crossPosition = new Vector3(Input.mousePosition.x / 16, Input.mousePosition.y / 16);

        if (crossPosition.x <= transform.position.x + maxDistanceCrossGunX && crossPosition.y <= maxDistanceCrossGunY)
        {
            crosshair.transform.position = crossPosition;

            // rotate Z of gun
            //Debug.Log(crossPosition.y);
            
         //gun.transform.rotation = new Quaternion(0f, 0f, crossPosition.y/60,0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            //GameObject kogel = Instantiate(bullet, crossPosition, Quaternion.identity) as GameObject;
            //kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(2, 0, 0);
            gun.Shoot(crossPosition);
        }
    }

    void ShotGunFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shotgun.Shoot();
        }
    }

    void MachineGunFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            machinegun.Shoot();
        }
    }

    void SniperFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sniper.Shoot();
        }
    }

    void RPGFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rpg.Shoot();
        }
    }
}