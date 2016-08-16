using UnityEngine;
using System.Collections;

public class SelectedWeapon : MonoBehaviour 
{
    public static string selectedWeapon = "Gun";
    public static string selectedGrenade = "Grenade";

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

        //Guns
        if (Input.GetKey(KeyCode.Alpha1))
        {
            selectedWeapon = "Gun";
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            selectedWeapon = "ShotGun";
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            selectedWeapon = "MachineGun";
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            selectedWeapon = "Sniper";
        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            selectedWeapon = "RPG";
        }
        

        //Grenades

        if (Input.GetKey(KeyCode.Alpha6))
        {
            selectedGrenade = "Grenade";
        }

        if (Input.GetKey(KeyCode.Alpha7))
        {
            selectedGrenade = "Flash";
        }

        if (Input.GetKey(KeyCode.Alpha8))
        {
            selectedGrenade = "Smoke";
        }
    }
}