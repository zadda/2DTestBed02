using UnityEngine;
using System.Collections;

public class EnemyHeli : MonoBehaviour 
{
    [SerializeField]
    private GameObject bullet;
    
    [SerializeField]
    private GameObject barrel;

    [SerializeField]
    private GameObject barrel2;

    private int ammo = 980;
    [SerializeField]
    private bool isFiring = false;

    [SerializeField]
    private float health = 500;

    private float timeDelay = 0f;

    void Update()
    {
        if (isFiring)
        {
            if (timeDelay <= 0)
            {
                Shoot();
            }

            timeDelay -= Time.deltaTime;
        }
    }

    void Shoot()
    {

        timeDelay = 0.5f;

        //isFiring = false;
        if (ammo >= 2)
        {
            //ammo counter
            ammo -= 2;

            //kogel vertrekt van positie van Barrel
            GameObject kogel = Instantiate(bullet, barrel.transform.position, Quaternion.Euler(0f,0f,17f)) as GameObject;
            kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(-70, -25, 0);

            Invoke("SecondShot", 0.3f);
        }
        else
        {
            return;
        }
    }

    void SecondShot()
    {
        //kogel vertrekt van positie van Barrel
        GameObject kogel2 = Instantiate(bullet, barrel2.transform.position, Quaternion.Euler(0f, 0f, 17f)) as GameObject;
        kogel2.GetComponent<Rigidbody2D>().velocity = new Vector3(-70, -25, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        //get amount of damage

        //check first if we are colliding by a Player Projectile 
        //if so, get Damage value from Player Projectile

        if (objectCollidedwith.GetComponent<PlayerProjectileDamage>())
        {
            float damage = objectCollidedwith.GetComponent<PlayerProjectileDamage>().damage;

            health -= damage;
            Destroy(objectCollidedwith);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}