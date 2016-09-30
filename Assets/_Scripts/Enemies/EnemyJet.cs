/*
 * patrols the sky
 * has a cone which checks for player or enemy
 * changes color of spotlight appropriately
 * bombs the Player and the Shield
 */


using UnityEngine;
using System.Collections;

public class EnemyJet : MonoBehaviour 
{

    [SerializeField]
    private GameObject rocket;
    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private GameObject barrel;

    [SerializeField]
    private GameObject barrel2;

    private int ammo = 980;

    [SerializeField]
    private float health = 750;

    [SerializeField]
    private GameObject healthBar;

    [SerializeField]
    private bool isFiring = false;
    
    public static bool isBombing = false;

    private Vector3 target;

    private float timeDelay = 0f;

    void Update()
    {
        //move the jet
        transform.Translate(Vector3.left * 20.5f * Time.deltaTime);

        //check if is Firing is true + implement a time delay so no constant bombing
        if (isFiring)
        {
            if (timeDelay <= 0)
            {
                Shoot();
            }

            timeDelay -= Time.deltaTime;
        }
        if (isBombing)
        {
            DropBomb();
        }

        healthBar.transform.localScale = new Vector3(health / 500, 1, 1);

    }

    void Shoot()
    {

        timeDelay = 0.5f;

        //isFiring = false;
        if (ammo >= 1)
        {
            //ammo counter
            ammo -= 1;

            //kogel vertrekt van positie van Barrel
            GameObject raket = Instantiate(rocket, barrel.transform.position, Quaternion.Euler(0f, 0f, 17f)) as GameObject;
            raket.GetComponent<Rigidbody2D>().velocity = new Vector3(-70, -25, 0);
        }
        else
        {
            return;
        }
    }

    void DropBomb()
    {
        isBombing = false;
        //kogel vertrekt van positie van Barrel
        GameObject bom = Instantiate(bomb, barrel2.transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        //bom.GetComponent<Rigidbody2D>().velocity = new Vector3(-70, -25, 0);
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