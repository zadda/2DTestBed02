﻿using UnityEngine;
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

    private int ammo = 18;


    // Use this for initialization
    void Start()
    {
        spriteGun = GetComponent<SpriteRenderer>();
        barrel = GameObject.FindGameObjectWithTag("Barrel");
        startPosition = transform.position;
    }

    // Update is called once per frame
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

    void MoveLeftRight()
    {
        //move left
        if (Input.GetKey(KeyCode.Q))
        {

            // move sniper Rifle 
            spriteGun.flipX = true;
            transform.position = new Vector3(Player.playerX -1.5f, Player.playerY + 4);
            transform.position += Vector3.left * Player.walkSpeed;
        }

        // move right
        if (Input.GetKey(KeyCode.D))
        {

            spriteGun.flipX = false;
            transform.position = new Vector3(Player.playerX - 1f, Player.playerY + 4);
            transform.position += Vector3.left * Player.walkSpeed;
        }
    }

    void Shoot() //Vector3 crossPosition

    {
        //Kogel vertrekt van positie van CrossHair
        //GameObject kogel = Instantiate(bullet, crossPosition, Quaternion.identity) as GameObject;
        if (ammo > 0)
        {
            //ammo counter
            ammo--;
            //ammoLeft.text = ammo.ToString();

            if (ammo <= 0)
            {
                ammoLeft.color = Color.red;
            }

            //kogel vertrekt van positie van Barrel
            GameObject kogel = Instantiate(bullet, barrel.transform.position, Quaternion.identity) as GameObject;
            kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(20, 0, 0);

            //TODO check if eject shell on players location is correct
            //GameObject huls = Instantiate(shell, transform.position, Quaternion.identity) as GameObject;
            Instantiate(shell, transform.position, Quaternion.identity);
        }
        else
        {
            return;
        }
    }
}