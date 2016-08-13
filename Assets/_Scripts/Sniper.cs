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


    private int ammo = 24;
    private Rigidbody2D rigidBody;

    private SpriteRenderer spriteSniper;
    private Vector3 startPosition;


    // Use this for initialization
    void Start () 
	{
        spriteSniper = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKey(KeyCode.Alpha4))
        {
            transform.position = new Vector3(Player.playerX + 5, Player.playerY + 5);
            Player.selectedWeapon = "Sniper";
        }

        if (Player.selectedWeapon == "Sniper")
        {
            MoveLeftRight();
        }

        //reset weapon to start position when not selected

        if (Player.selectedWeapon != "Sniper")
        {
            transform.position = startPosition;
        }

        
    }

    void MoveLeftRight()
    {
        //move left
        if (Input.GetKey(KeyCode.Q))
        {

            // move sniper Rifle 
            spriteSniper.flipX = true;
            transform.position = new Vector3(Player.playerX - 5, Player.playerY + 5);
            transform.position += Vector3.left * Player.walkSpeed;
        }

        // move right
        if (Input.GetKey(KeyCode.D))
        {

            spriteSniper.flipX = false;
            transform.position = new Vector3(Player.playerX + 5, Player.playerY + 5);
            transform.position += Vector3.left * Player.walkSpeed;
        }
    }

    public void Shoot()

    {
        //TODO switch between single shot and multiple Shots
        //ammo counter
        ammo -= 1;
        ammoLeft.text = ammo.ToString();

        //kogel vertrekt van positie van Barrel
        GameObject kogel = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
        kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(55, 0, 0);

        //TODO check if eject shell on players location is correct
        Instantiate(shell, transform.position, Quaternion.identity);
        
    }

}