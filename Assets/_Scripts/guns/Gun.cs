using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour 
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject shell;
    [SerializeField]
    private Text ammoLeft;
    [SerializeField]
    private GameObject barrel;
    
    //!!\\ RigidBody toevoegen!! 
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteGun;
    private Vector3 startPosition;

    //TODO set to infinite or really high, but keep an ammount for 'reloading' of gun
    private int ammo = 1500;
    

    void Start()
    {
        spriteGun = GetComponent<SpriteRenderer>();
        barrel = GameObject.FindGameObjectWithTag("Barrel");
        startPosition = transform.position;
    }
    
    void Update()
    {

        if ( SelectedWeapon.selectedWeapon == "Gun" && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }


        if (SelectedWeapon.selectedWeapon == "Gun")
        {
            transform.position = new Vector3(Player.playerX -1.5f, Player.playerY + 4);
            
        }

        if (SelectedWeapon.selectedWeapon == "Gun")
        {
            MoveLeftRight();
        }

        if (SelectedWeapon.selectedWeapon != "Gun")
        {
            transform.position = startPosition;
        }
    }

    //TODO update movement

    void MoveLeftRight()
    {
        //move left
        if (Input.GetButton("Left"))
        {

            // move Gun
            spriteGun.flipX = true;
            transform.position = new Vector3(Player.playerX -1.5f, Player.playerY + 4);
            transform.position += Vector3.left * Player.walkSpeed;
        }

        // move right
        if (Input.GetButton("Right"))
        {

            spriteGun.flipX = false;
            transform.position = new Vector3(Player.playerX - 1f, Player.playerY + 4);
            transform.position += Vector3.left * Player.walkSpeed;
        }
    }

    void Shoot() 

    {
        //Kogel vertrekt van positie van CrossHair
        //GameObject kogel = Instantiate(bullet, crossPosition, Quaternion.identity) as GameObject;
        if (ammo > 0)
        {
            //ammo counter
            ammo--;

            if (ammo <= 0)
            {
                ammoLeft.color = Color.red;
            }

            //kogel vertrekt van positie van Barrel
            GameObject kogel = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
            //kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(40, 0, 0);
            kogel.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z * 100);
            kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(40, transform.rotation.z * 100, 0);

            //alternatively: only when we need to do something with the shell afterwards
            //GameObject huls = Instantiate(shell, transform.position, Quaternion.identity) as GameObject;
            Instantiate(shell, transform.position, Quaternion.identity);
        }
        else
        {
            return;
        }
    }
}