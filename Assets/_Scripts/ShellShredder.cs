using UnityEngine;
using System.Collections;

public class ShellShredder : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
        }
        
    }
}