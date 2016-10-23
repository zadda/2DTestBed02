using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Sniper : MonoBehaviour 
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject shell;

    [SerializeField]
    private GameObject barrel;
    [SerializeField]
    private Text ammoLeft;


    private int ammo = 20;
    private Rigidbody2D rigidBody;

    private SpriteRenderer spriteSniper;
    private Vector3 startPosition;

    Vector3 mousePOS;
    
    void Start () 
	{
        spriteSniper = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }
	
	void Update () 
	{

        mousePOS = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.LeftShift) && SelectedWeapon.selectedWeapon == "Sniper")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, mousePOS.y / 10);
        }

        if (SelectedWeapon.selectedWeapon == "Sniper" && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (SelectedWeapon.selectedWeapon == "Sniper")
        {
            transform.position = new Vector3(Player.playerX + 5, Player.playerY + 5);
        }

        if (SelectedWeapon.selectedWeapon == "Sniper")
        {
            MoveLeftRight();
        }

        if (SelectedWeapon.selectedWeapon != "Sniper")
        {
            transform.position = startPosition;
        }

    }

    void MoveLeftRight()
    {
        //move left
        if (Input.GetButton("Left"))
        {

            // move sniper Rifle 
            spriteSniper.flipX = true;
            transform.position = new Vector3(Player.playerX - 5, Player.playerY + 5);
            transform.position += Vector3.left * Player.walkSpeed;
        }

        // move right
        if (Input.GetButton("Right"))
        {

            spriteSniper.flipX = false;
            transform.position = new Vector3(Player.playerX + 5, Player.playerY + 5);
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
            //kogel vertrekt van positie van Barrel
            GameObject kogel = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
            kogel.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z * 100);
            kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(55, transform.rotation.z * 100, 0);

            //kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(55, 0, 0);

            Instantiate(shell, transform.position, Quaternion.identity);
        }
        else
        {
            return;
        }
    }
}