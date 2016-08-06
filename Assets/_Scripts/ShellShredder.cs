using UnityEngine;
using System.Collections;

public class ShellShredder : MonoBehaviour
{

    //void OnCollisionEnter2D(Collider2D collision)
    //{
    //    Destroy(collision.gameObject);
    //}
    //TODO Triggers gebruiken
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}