using UnityEngine;
using System.Collections;

public class LaserDotGreen : MonoBehaviour 
{

    [SerializeField]
    private SpriteRenderer sprite;

    public static bool laserEnabled = true;


	// Use this for initialization
	void Start () 
	{
        //transform.position = new Vector3(-46.9f, 3.9f);
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (laserEnabled)
        {
            DrawLaser();
        }
	}

    void DrawLaser()
    {
        sprite.enabled = true;

        transform.position = new Vector3(Player.playerX-7, Player.playerY+5);

    }
}
