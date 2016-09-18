using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour 
{

    [SerializeField]
    private float health = 250;
    [SerializeField]
    private Sprite[] shieldSprites;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    Vector3 mousePOS;
    
	void Update () 
	{
        ShieldDamageSprite();


        //rotate SHIELD when pressing L Shift
        mousePOS = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.LeftShift) && SelectedWeapon.selectedWeapon == "Shield")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, mousePOS.y / 10);
            
        }
        // follow the Player's movement
        if (SelectedWeapon.selectedWeapon == "Shield")
        {
            transform.position = new Vector3(Player.playerX + 3, Player.playerY + 3);
        }

    }


    //change the sprite or Appearance of the shield depending on damage taken
    void ShieldDamageSprite()
    {
        if (health <= 200 && health > 150)
        {
            spriteRenderer.sprite = shieldSprites[0];
            //this.GetComponent<SpriteRenderer>().sprite = shieldSprites[0];
        }
        else if (health <= 150 && health > 100)
        {
            spriteRenderer.sprite = shieldSprites[1];
        }
        else if (health <= 100 && health > 50)
        {
            spriteRenderer.sprite = shieldSprites[2];
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedwith = collision.gameObject;

        //get amount of damage

        //check first if we are colliding with Enemy Projectile
        //if so, get Damage value from EnemyProjectile

        if (objectCollidedwith.GetComponent<EnemyProjectileDamage>())
        {
            float damage = objectCollidedwith.GetComponent<EnemyProjectileDamage>().damage;

            health -= damage;
            Destroy(objectCollidedwith);
        }

        if (health <= 0)
        {
            //TODO destroy SHIELD when max damage taken?
            //Destroy(gameObject);
        }
    }
}