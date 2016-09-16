using UnityEngine;
using System.Collections;

public class CheckShieldPlayerCollision : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        //get amount of damage

        if (objectCollidedwith.tag == "Player" || objectCollidedwith.tag == "ConeHitArea")
        {
            Enemy03.stopAttacking = true;

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Enemy03.stopAttacking = false;
    }
}
