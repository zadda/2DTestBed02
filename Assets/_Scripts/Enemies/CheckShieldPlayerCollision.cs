/*
 * used for stopping the enemy from attacking
 * when colliding with the Players' shield or the player
 * 
 */

using UnityEngine;
using System.Collections;

public class CheckShieldPlayerCollision : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;
        
        if (objectCollidedwith.tag == "Player" || objectCollidedwith.tag == "ConeHitArea") // ConeHitArea is the collider on the Player's feet
 
                                                                                                      // which is also used for the enemy cone detection
        //stop attacking and moving of enemy towards Player
        {
            Enemy03.stopAttacking = true;

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Enemy03.stopAttacking = false;
    }
}
