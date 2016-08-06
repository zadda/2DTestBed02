using UnityEngine;
using System.Collections;

public class Sniper : MonoBehaviour 
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject shell;
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
}