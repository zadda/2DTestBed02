/*
 * the helicopter moves around
 * has a searchlight animation which is to check
 * if it's detecting the Player, if so
 * start firing
 * Fire alternate between two barrels
 */


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

    //TODO set definitive ammo limit
    private int ammo = 980;
    [SerializeField]
    private bool isFiring = false;

    [SerializeField]
    private float health = 500;

    private float timeDelay = 0f;

    public static bool heliCalled = false;



    void Update()
    {
        if (heliCalled == true && transform.position.x >= Enemy01.enemyPosition.x)
        {
            transform.Translate(Vector3.left * 30.5f * Time.deltaTime);
        }

        if (transform.position.x <= Enemy01.enemyPosition.x)
        {
            isFiring = true;
        }



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
        // time before firing from the second barrel
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