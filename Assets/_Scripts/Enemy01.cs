using UnityEngine;
using System.Collections;

public class Enemy01 : MonoBehaviour
{
    [SerializeField]
    private Transform lineStart;
    [SerializeField]
    private Transform lineEnd;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject shell;

    [SerializeField]
    private Transform barrel;

    private float repeatFireRate = 10;
    private float countDowntime = 2.35f;

    public float health = 120;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        countDowntime -= Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(lineStart.position, Vector3.left, 45);

        if (hit.collider != null && countDowntime <= 0)
        {
            Fire();

            // TODO RayCast Example
            Debug.DrawRay(lineStart.position, Vector3.left * 45f, Color.green);
            
            //Debug.DrawLine(lineStart.position, lineEnd.position, Color.red);
        }
    }

    void Fire()
    {
        countDowntime = 2.35f;

        GameObject kogel = Instantiate(bullet, barrel.position, Quaternion.identity) as GameObject;
        kogel.GetComponent<Rigidbody2D>().velocity = new Vector3(-40, 0, 0);

        //beweeg enemy naar Player toe

        transform.position += new Vector3(-3f, 0f);

        //GameObject huls = Instantiate(shell, transform.position, Quaternion.identity) as GameObject;
        Instantiate(shell, transform.position, Quaternion.identity);
    }

   

    public void OnTriggerEnter2D(Collider2D collision)
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

       

        //if (objectCollidedwith.GetComponent<GunBullet>())
        //{
        //    Destroy(objectCollidedwith);
        //    health -= 10;
        //}
        //else if(objectCollidedwith.GetComponent<ShotGunBullets>())
        //{
        //    health -= 20;
        //}
    }
}