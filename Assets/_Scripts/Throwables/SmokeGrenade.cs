using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SmokeGrenade : MonoBehaviour 
{
    [SerializeField]
    private GameObject grenade;

    [SerializeField]
    private Transform grenadeStartPosition;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private Text ammoLeft;

    private int ammo = 1;


    void Update()
    {
        if (SelectedWeapon.selectedGrenade == "Smoke" && Input.GetMouseButtonDown(1))
        {
            Throw();
        }
    }

    void Throw()
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
            granaat.GetComponent<Rigidbody2D>().velocity = new Vector3(120, -15, 0);
            granaat.GetComponent<Rigidbody2D>().rotation = -5;
        }
        else
        {
            return;
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 positie = transform.position;
        positie += new Vector3(0, 8, 0);

        //Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject explosie = Instantiate(explosion, positie, Quaternion.identity) as GameObject;
        Destroy(explosie, 10f);
        Destroy(gameObject);
    }
}