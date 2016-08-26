using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour 
{

    [SerializeField]
    private GameObject explosion;


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject explosie = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosie, 5f);
        Destroy(gameObject);
    }
}