using UnityEngine;
using System.Collections;

public class SmokeGrenade : MonoBehaviour 
{
    [SerializeField]
    private GameObject grenade;

    [SerializeField]
    private Transform grenadeStartPosition;

    [SerializeField]
    private GameObject explosion;



    public void Throw()
    {
        GameObject granaat = Instantiate(grenade, grenadeStartPosition.transform.position, Quaternion.identity) as GameObject;
        granaat.GetComponent<Rigidbody2D>().velocity = new Vector3(180, -15, 0);
        granaat.GetComponent<Rigidbody2D>().rotation = -25;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}