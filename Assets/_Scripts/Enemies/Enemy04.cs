using UnityEngine;
using System.Collections;

public class Enemy04 : MonoBehaviour
{
    [SerializeField]
    private Transform lineStart;
    [SerializeField]
    private Transform lineEnd;

    [SerializeField]
    private GameObject grenade;

    [SerializeField]
    private Transform barrel;

    [SerializeField]
    private GameObject flares;

    [SerializeField]
    private Transform launchPosition;

    public static Vector3 enemyPosition;

    [SerializeField]
    private GameObject gas;
    
    public float health = 200;
    [SerializeField]
    private GameObject healthBar;

    public static bool stopAttacking = false;
    
  
    int launchSpeed = -85;
    

    private float timerCountdown = 2f;


	// Update is called once per frame
	void Update () 
	{

        RaycastHit2D hit = Physics2D.Raycast(lineStart.position, Vector3.left, 65); //45

        //is er een hit, en is er genoeg tijd tussen het vorige schot?
        //controleer of er een hit met de player is


        if (hit.collider != null && hit.transform.tag.Equals("Player") && timerCountdown <= 0) //"Player" hit.transform.name.Equals("Player")) MainPlayer
        {
            Fire();
        }

        timerCountdown -= Time.deltaTime;


        healthBar.transform.localScale = new Vector3(health / 200, 1, 1);

        CheckHealth();

    }

    void CheckHealth()
    {


        if (health <= 50 && EnemyHeli.heliCalled == false)
        {
            // launch Flare and call HeliSupport
            EnemyHeli.heliCalled = true;

            enemyPosition = transform.position;

            //ceaseFire = true;
            //sprite.flipX = true;

            GameObject flare = Instantiate(flares, barrel.position, Quaternion.identity) as GameObject;
            //transform.Translate(Vector3.up * 220.5f * Time.deltaTime);
            flare.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 30, 0); // bullet speed in -X position

            Destroy(flare, 5f);

            //move enemy
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(40, 0, 0);
        }
        
    }

    
    void Fire()
    {

        timerCountdown = 2;
      
        
        GameObject granaat = Instantiate(grenade, launchPosition.position, Quaternion.identity) as GameObject;
        //granaat.transform.rotation = Quaternion.Euler(0, 0, 351);
        granaat.GetComponent<Rigidbody2D>().velocity = new Vector3(launchSpeed, launchPosition.rotation.z * 100 + 2, 0);

        if (launchSpeed >= -140)
        {
            launchSpeed -= 20;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //zorgt ervoor dat de rook hoog genoeg zichtbaar is, anders deels onder de grond
        Vector3 positie = GetComponent<GasGrenade>().transform.position;
        //positie -= new Vector3(52, 8, 0);

        //Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject explosie = Instantiate(gas,positie, Quaternion.identity) as GameObject;

       
        Destroy(explosie, 10f);
        //Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        //get amount of damage

        //check first if we are colliding with a Player Projectile 
        //if so, get Damage value from Player Projectile

        if (objectCollidedwith.GetComponent<PlayerProjectileDamage>())
        {
            float damage = objectCollidedwith.GetComponent<PlayerProjectileDamage>().damage;

            health -= damage;
            Destroy(objectCollidedwith); // destroy Player projectile
        }

        //kill the enemy
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        // Hit by FlashGrenade -> cease fire flip sprite

    }
}
