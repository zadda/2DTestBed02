using UnityEngine;
using System.Collections;

public class StopBullets : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
