/*
 * called by Enemy03 when certain amount of damage is achieved
 * has a cone which checks for player or enemy
 * changes color of spotlight appropriately
 * bombs the Player and/or the Shield
 */


using UnityEngine;
using System.Collections;

public class EnemyJet : MonoBehaviour 
{

    //expose GameObjects
    [SerializeField]
    private GameObject rocket;
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private GameObject barrel;
    [SerializeField]
    private GameObject barrel2;
    [SerializeField]
    private GameObject healthBar;

    private int ammo = 980;

    //Health
    [SerializeField]
    private float health = 750;

    [SerializeField]
    private bool isFiring = false;

    private Vector3 target;

    private float timeDelay = 0f;

    public static bool isBombing = false;

    public static bool jetCalled = false;

    private int counter = 0;
    Vector3 moveJet = new Vector3(10, 0, 0);

    void Update()
    {
        //move the jet

        // move until detect Player

        if (jetCalled && ConeOfVisionJet.playerDetected == false)
        {
            transform.Translate(Vector3.left * 80.5f * Time.deltaTime); //20.5f
            
        }

        if (ConeOfVisionJet.playerDetected == true && counter == 0)
        {
            transform.position -= moveJet;
            counter++;
        }

        if (counter == 3)
        {
            ConeOfVisionJet.playerDetected = false;
        }

        //check if is Firing is true + implement a time delay so no constant bombing
        if (isFiring)
        {
            if (timeDelay <= 0)
            {
                Shoot();
            }

            timeDelay -= Time.deltaTime;
        }
        if (isBombing && counter < 3)
        {
            DropBomb();
        }

        healthBar.transform.localScale = new Vector3(health / 750, 1, 1);

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
        counter++;
        isBombing = false;
        //kogel vertrekt van positie van Barrel
        //GameObject bom = Instantiate(bomb, barrel2.transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        Instantiate(bomb, barrel2.transform.position, Quaternion.Euler(0f, 0f, 0f)); //TODO check of correct werkt
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