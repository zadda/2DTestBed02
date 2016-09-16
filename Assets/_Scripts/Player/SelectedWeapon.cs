/*
 * checks and sets the selected weapon 
 * 
 */

using UnityEngine;
using System.Collections;

public class SelectedWeapon : MonoBehaviour 
{
    public static string selectedWeapon = "Gun";
    public static string selectedGrenade = "Grenade";

    private int numberOfSelectedWeapon = 1;
    
	
	// Update is called once per frame
	void Update ()
    {
        
        MouseWheelUP();
        //Guns

        if (Input.GetKey(KeyCode.Alpha0))
        {
            selectedWeapon = "Shield";
        }

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

    private void MouseWheelUP()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            //account for amount of scrolling above  the max number of weapons
            if (numberOfSelectedWeapon < 5)
            {
                numberOfSelectedWeapon += 1;
            }
            else 
            {
                numberOfSelectedWeapon = 1;
            }

            switch (numberOfSelectedWeapon)
            {
                case 1:
                    selectedWeapon = "Gun";
                    break;
                case 2:
                    selectedWeapon = "ShotGun";
                    break;
                case 3:
                    selectedWeapon = "MachineGun";
                    break;
                case 4:
                    selectedWeapon = "Sniper";
                    break;
                case 5:
                    selectedWeapon = "RPG";
                    break;
            }
        }
    }
}