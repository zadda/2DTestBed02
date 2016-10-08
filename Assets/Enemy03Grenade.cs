using UnityEngine;
using System.Collections;

public class Enemy03Grenade : MonoBehaviour
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

    private Vector3 enemyPosition;

    [SerializeField]
    private GameObject gas;
    
    public float health = 200;
    [SerializeField]
    private GameObject healthBar;

    public static bool stopAttacking = false;
    
    [SerializeField]
    private bool grenadeFired = true;

    int launchSpeed = -70;
    int grenadesFired = 0;

    private float timerCountdown = 2f;


    // Use this for initialization
    void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        timerCountdown -= Time.deltaTime;


        if (!grenadeFired && timerCountdown <= 0)
        {
           Fire();
        }
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

            //move enemy
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(40, 0, 0);
        }

        DefensivePositionReached();
    }

    void DefensivePositionReached()
    {

        Rigidbody2D rBody = GetComponent<Rigidbody2D>();



        //if (defensivePositionReached == true && transform.position.x >= defensiveObstacle.position.x + 10)
        //{
        //    rBody.velocity = new Vector3(0, 0, 0);
        //    // rBody.constraints = RigidbodyConstraints2D.FreezePositionX;

        //    sprite.flipX = false;
        //    ceaseFire = false;
        //    defensivePositionReached = false;
        //    stopMoving = true;
        //}
    }


    void Fire()
    {

        timerCountdown = 2;
        grenadesFired++;
        if (grenadesFired == 5)
        {
            grenadeFired = true;
        }
        
        GameObject granaat = Instantiate(grenade, launchPosition.position, Quaternion.identity) as GameObject;
        //granaat.transform.rotation = Quaternion.Euler(0, 0, 351);
        granaat.GetComponent<Rigidbody2D>().velocity = new Vector3(launchSpeed, launchPosition.rotation.z * 100 + 2, 0);
        launchSpeed -= 20;


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
