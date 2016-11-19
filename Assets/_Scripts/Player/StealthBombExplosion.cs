using UnityEngine;
using System.Collections;

public class StealthBombExplosion : MonoBehaviour 
{

    [SerializeField]
    private GameObject explosion;

    //show explosion when colliding with the floor
    void OnCollisionEnter2D(Collision2D collision)
    {
        //show explosion animation when an enemy bomb hits the player
        GameObject explosie = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosie, 1.5f); // explosie is the animation
        Destroy(gameObject); //gameObject is the bomb
    }



    //show explosion when trigger is an object tagged with "Enemy"
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            //show explosion animation when a player bomb hits the enemy
            GameObject explosie = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            // destroy faster than when hitting environment
            Destroy(explosie, 0.5f); // explosie is the animation
            Destroy(gameObject); //gameObject is the bomb
        }
    }
}