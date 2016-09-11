using UnityEngine;
using System.Collections;

public class SelectedWeapon : MonoBehaviour 
{
    public static string selectedWeapon = "Gun";
    public static string selectedGrenade = "Grenade";

    private int numberOfSelectedWeapon = 1;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // TODO update weapon buttons, call when mousewheel up or down??
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

    private void MouseWheelDown()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (numberOfSelectedWeapon >= 1)
            {
                numberOfSelectedWeapon -= 1;
            }
            else if(numberOfSelectedWeapon <= 0)
            {
                numberOfSelectedWeapon = 5;
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