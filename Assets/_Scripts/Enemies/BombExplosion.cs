using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour 
{

    [SerializeField]
    private GameObject explosion;


    //ontploffing bij raken omgeving
    void OnCollisionEnter2D(Collision2D collision)
    {
        //show explosion animation when an enemy bomb hits the player
        GameObject explosie = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosie, 1.5f); // explosie is the animation
        Destroy(gameObject); //gameObject is the bomb
    }

    //ontploft wanneer Player geraakt wordt
    void OnTriggerEnter2D(Collider2D collision)
    {
        //show explosion animation when an enemy bomb hits the player
        GameObject explosie = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        // destroy faster than when hitting environment
        Destroy(explosie, 0.5f); // explosie is the animation
        Destroy(gameObject); //gameObject is the bomb
    }
}