﻿using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour 
{
    [SerializeField]
    private GameObject grenade;

    [SerializeField]
    private Transform grenadeStartPosition;

    [SerializeField]
    private GameObject explosion;

    void Update()
    {
        if (SelectedWeapon.selectedGrenade == "Grenade" && Input.GetMouseButtonDown(1))
        {
            Throw();
        }
    }



    public void Throw()
    {
        GameObject granaat = Instantiate(grenade, grenadeStartPosition.transform.position, Quaternion.identity) as GameObject;
        granaat.GetComponent<Rigidbody2D>().velocity = new Vector3(180, -30, 0);
        granaat.GetComponent<Rigidbody2D>().rotation = -25;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // instantiate as GameObject anders kunnen we het niet verwijderen omdat het een prefab is
        GameObject explosie = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;

        Destroy(explosie, 1f); // destroy explosie

        Destroy(gameObject); // destroy Grenade
    }
}