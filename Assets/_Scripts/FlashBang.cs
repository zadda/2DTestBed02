﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashBang : MonoBehaviour
{

    [SerializeField]
    private GameObject grenade;

    [SerializeField]
    private Transform grenadeStartPosition;

    [SerializeField]
    private GameObject flash;

    [SerializeField]
    private Text ammoLeft;

    private int ammo = 5;

    void Update()
    {
        if (SelectedWeapon.selectedGrenade == "Flash" && Input.GetMouseButtonDown(1))
        {
            Throw();
        }
    }


    public void Throw()
    {
        //ammo counter
        ammo--;
        ammoLeft.text = ammo.ToString();

        GameObject granaat = Instantiate(grenade, grenadeStartPosition.transform.position, Quaternion.identity) as GameObject;
        granaat.GetComponent<Rigidbody2D>().velocity = new Vector3(180, -15, 0);
        granaat.GetComponent<Rigidbody2D>().rotation = -25;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosie = Instantiate(flash, transform.position, Quaternion.identity) as GameObject;

        Destroy(explosie, 1f); // destroy explosie

        Destroy(gameObject);
    }
}