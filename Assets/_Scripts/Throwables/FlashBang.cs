using UnityEngine;
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
        if (SelectedWeapon.selectedGrenade == "Flash" && Input.GetMouseButtonDown(1)) // right mouse button
        {
            Throw();
        }
    }


    void Throw()
    {

        //only throw grenade when enough ammo

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
            granaat.GetComponent<Rigidbody2D>().velocity = new Vector3(120, -11, 0);
            granaat.GetComponent<Rigidbody2D>().rotation = -25;
        }
        //TODO check if redundant
        //else
        //{
        //    return;
        //}

       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosie = Instantiate(flash, transform.position, Quaternion.identity) as GameObject;

        Destroy(explosie, 1f); // destroy explosie animatie

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            return;
        }

        GameObject explosie = Instantiate(flash, transform.position, Quaternion.identity) as GameObject;

        Destroy(explosie, 1f); // destroy explosie animatie

        Destroy(gameObject);
    }
}