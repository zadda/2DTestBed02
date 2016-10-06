using UnityEngine;
using System.Collections;


public class GasGrenade : MonoBehaviour
{
    [SerializeField]
    private GameObject grenade;

    [SerializeField]
    private Transform grenadeStartPosition;

    [SerializeField]
    private GameObject explosion;
    
    

    void Update()
    {
        if (SelectedWeapon.selectedGrenade == "Smoke" && Input.GetMouseButtonDown(1))
        {
            Throw();
        }
    }

    void Throw()
    {
       

            GameObject granaat = Instantiate(grenade, grenadeStartPosition.transform.position, Quaternion.identity) as GameObject;
            granaat.GetComponent<Rigidbody2D>().velocity = new Vector3(-120, -15, 0);
            granaat.GetComponent<Rigidbody2D>().rotation = -5;
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //zorgt ervoor dat de rook hoog genoeg zichtbaar is, anders deels onder de grond
        Vector3 positie = transform.position;
        positie += new Vector3(0, 8, 0);

        //Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject explosie = Instantiate(explosion, positie, Quaternion.identity) as GameObject;

     


        Destroy(explosie, 10f);
        Destroy(gameObject);
    }
}