﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShotGun : MonoBehaviour 
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
        if (Input.GetKey(KeyCode.Alpha2))
        {
            transform.position = new Vector3(Player.playerX + 7, Player.playerY + 4);
            Player.selectedWeapon = "ShotGun";
        }

        if (Player.selectedWeapon == "ShotGun")
        {
            MoveLeftRight();
        }

        if (Player.selectedWeapon != "ShotGun")
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
            transform.position = new Vector3(Player.playerX - 7f, Player.playerY + 4);
            transform.position += Vector3.left * Player.walkSpeed;
        }

        // move right
        if (Input.GetKey(KeyCode.D))
        {

            spriteGun.flipX = false;
            transform.position = new Vector3(Player.playerX + 7, Player.playerY + 4);
            transform.position += Vector3.left * Player.walkSpeed;
        }
    }

    public void Shoot()

    {
        //
        //ammo counter
        ammo -= 2;
        ammoLeft.text = ammo.ToString();

        //kogel vertrekt van positie van Barrel
        GameObject kogel = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
        kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(30, 0, 0);

        //TODO check if eject shell on players location is correct
        GameObject huls = Instantiate(shell, transform.position, Quaternion.identity) as GameObject;
    }
}