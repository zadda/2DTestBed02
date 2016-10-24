using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour 
{

    [SerializeField]
    private Transform obstackle;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        //if (objectCollidedwith.tag == "Enemy")
        //{
        //    //Debug.Log("Obstacle Reached");

        //    Enemy01.defensiveObstacle = transform;


        //    Enemy01.defensivePositionReached = true;
        //}

    }

}