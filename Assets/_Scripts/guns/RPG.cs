using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RPG : MonoBehaviour 
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject shell;

    [SerializeField]
    private GameObject barrel;

    [SerializeField]
    private Text ammoLeft;


    private int ammo = 6;
    private Rigidbody2D rigidBody;

    private SpriteRenderer spriteGun;
    private Vector3 startPosition;

    Vector3 mousePOS;

    // Use this for initialization
    void Start()
    {
        spriteGun = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //beweeg geweer Z-axis afhankelijk van positie Y
        //transform.rotation = Quaternion.Euler(0f,0f, crossPosition.y);

        mousePOS = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.LeftShift) && SelectedWeapon.selectedWeapon == "RPG")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, mousePOS.y / 10);
        }


        if (SelectedWeapon.selectedWeapon == "RPG" && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (SelectedWeapon.selectedWeapon == "RPG")
        {
            transform.position = new Vector3(Player.playerX - 1, Player.playerY + 4);
        }

        if (SelectedWeapon.selectedWeapon == "RPG")
        {
            MoveLeftRight();
        }

        if (SelectedWeapon.selectedWeapon != "RPG")
        {
            transform.position = startPosition;
        }

    }

    void MoveLeftRight()
    {
        //move left
        if (Input.GetKey(KeyCode.Q))
        {
            spriteGun.flipX = true;
            transform.position = new Vector3(Player.playerX , Player.playerY + 4);
            transform.position += Vector3.left * Player.walkSpeed;
        }

        // move right
        if (Input.GetKey(KeyCode.D))
        {

            spriteGun.flipX = false;
            transform.position = new Vector3(Player.playerX + 1, Player.playerY + 4);
            transform.position += Vector3.left * Player.walkSpeed;
        }
    }

    void Shoot()

    {
        if (ammo > 0)
        {
            //ammo counter
            ammo--;
            ammoLeft.text = ammo.ToString();

                if (ammo <= 0)
                {
                    ammoLeft.color = Color.red;
                }
            //rotation is RPG.Z axis rotation, 

            //De Z positie van de rotation moet geplaatst worden op de Y-positie van de velocity and Quaternion Rotation /!\
        
            GameObject kogel = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
            kogel.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z*100);
            kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(55, transform.rotation.z * 100, 0);
        }
        else
        {
            return;
        }
    }
}