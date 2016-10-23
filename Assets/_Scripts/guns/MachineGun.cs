using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MachineGun : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject shell;

    [SerializeField]
    private GameObject barrel;
    [SerializeField]
    private Text ammoLeft;


    private int ammo = 180;
    private Rigidbody2D rigidBody;


    private SpriteRenderer spriteGun;
    private Vector3 startPosition;

    Vector3 mousePOS;
    
    void Start()
    {
        spriteGun = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }

    
    void Update()
    {

        mousePOS = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.LeftShift) && SelectedWeapon.selectedWeapon == "MachineGun")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, mousePOS.y / 10);
        }
        //////////

        if (SelectedWeapon.selectedWeapon == "MachineGun" && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (SelectedWeapon.selectedWeapon == "MachineGun")
        {
            transform.position = new Vector3(Player.playerX, Player.playerY + 5);
        }

        if (SelectedWeapon.selectedWeapon == "MachineGun")
        {
            MoveLeftRight();
        }

        if (SelectedWeapon.selectedWeapon != "MachineGun")
        {
            transform.position = startPosition;
        }
    }

    void MoveLeftRight()
    {
        //move left
        if (Input.GetButton("Left"))
        {
            spriteGun.flipX = true;
            transform.position = new Vector3(Player.playerX - 1, Player.playerY + 5);
            transform.position += Vector3.left * Player.walkSpeed;
        }

        // move right
        if (Input.GetButton("Right"))
        {

            spriteGun.flipX = false;
            transform.position = new Vector3(Player.playerX +1, Player.playerY + 5);
            transform.position += Vector3.left * Player.walkSpeed;
        }
    }

    void Shoot()

    {

        if (ammo >= 2)
        {
            //ammo counter
            ammo-= 2;
            ammoLeft.text = ammo.ToString();

                if (ammo <= 0)
                {
                    ammoLeft.color = Color.red;
                }

            
            //kogel vertrekt van positie van Barrel
            GameObject kogel = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
            kogel.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z * 100);
            kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(30, transform.rotation.z * 100, 0);

//            kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(30, 0, 0);

            //TODO check if eject shell on players location is correct
            Instantiate(shell, transform.position, Quaternion.identity);

            Invoke("SecondShot", 0.3f);
        }
        else
        {
            return;
        }
        //TODO switch between single shot and multiple Shots
       
        
    }

    void SecondShot()
    {
        //kogel vertrekt van positie van Barrel
        GameObject kogel2 = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
        kogel2.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z * 100);
        kogel2.GetComponent<Rigidbody2D>().velocity = new Vector3(30, transform.rotation.z * 100, 0);

        //kogel2.GetComponent<Rigidbody2D>().velocity = new Vector3(30, 0, 0);


        Instantiate(shell, transform.position, Quaternion.identity);

    }

}