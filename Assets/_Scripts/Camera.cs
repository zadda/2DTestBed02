/*
 * Camera follows the Player with OffSet
 * 
 */

using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour 
{
    [SerializeField]
    private Player player;

    public static Vector3 cameraPOS;

	// Use this for initialization
	void Start () 
	{
        cameraPOS = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
        transform.position = new Vector3(player.transform.position.x + 20,19.3f,-10f);
        //transform.position = new Vector3(player.transform.position.x + 20, 19.3f, player.transform.position.y);
    }
}