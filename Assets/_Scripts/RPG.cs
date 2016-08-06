using UnityEngine;
using System.Collections;

public class RPG : MonoBehaviour 
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject shell;

    private SpriteRenderer spriteGun;
    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        spriteGun = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha5))
        {
            transform.position = new Vector3(Player.playerX -1, Player.playerY + 4);
            Player.selectedWeapon = "RPG";
        }

        if (Player.selectedWeapon == "RPG")
        {
            MoveLeftRight();
        }

        if (Player.selectedWeapon != "RPG")
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
}