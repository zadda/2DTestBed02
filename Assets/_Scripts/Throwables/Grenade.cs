using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Grenade : MonoBehaviour 
{
    [SerializeField]
    private GameObject grenade;

    [SerializeField]
    private Transform grenadeStartPosition;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private Text ammoLeft;

    private int ammo = 4;


    void Update()
    {
        if (SelectedWeapon.selectedGrenade == "Grenade" && Input.GetMouseButtonDown(1))
        {
            Throw();
        }
    }



    public void Throw()
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
           

            GameObject granaat = Instantiate(grenade, grenadeStartPosition.transform.position, Quaternion.identity) as GameObject;
            granaat.GetComponent<Rigidbody2D>().velocity = new Vector3(120, -20, 0); // 120,-30,0
            granaat.GetComponent<Rigidbody2D>().rotation = -25; // -25
        }         
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        // instantiate as GameObject anders kunnen we het niet verwijderen omdat het een prefab is
        GameObject explosie = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;

        Destroy(explosie, 1f); // destroy explosie

        Destroy(gameObject); // destroy Grenade
    }

    //added so that grenade explodes when hitting enemy
    void OnTriggerEnter2D(Collider2D collision)
    {
        //stops explodion when hitting Player or Shield
        if (collision.gameObject.tag.Equals("Player"))
        {
            return;
        }
        // instantiate as GameObject anders kunnen we het niet verwijderen omdat het een prefab is
        GameObject explosie = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;

        Destroy(explosie, 1f); // destroy explosie

        Destroy(gameObject); // destroy Grenade
    }
}