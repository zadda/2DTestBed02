using UnityEngine;
using System.Collections;

public class ShellShredder : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}