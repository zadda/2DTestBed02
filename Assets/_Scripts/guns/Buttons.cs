/*
 * This is the HUD which is implemented as a Quad
 * that contains the selectable WEAPONS
 * this listens in the background if a key (1-5) is pressed
 * that accounts for a specific weapon
 * it then changes the selected weapon in the quad
 */

using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour 
{
    [SerializeField]
    private Buttons[] buttonArray;

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject[] weapons;

    // Use this for initialization
    void Start () 
	{
        //set Gun as Default weapon

        buttonArray[0].GetComponent<SpriteRenderer>().color = Color.white;

    }
	
	// zorgt ervoor dat wapen dat in gebruik is, alpha channel zichtbaar in buttons Quad


	void Update () 
	{
        if (Input.GetKey(KeyCode.Alpha1) || SelectedWeapon.selectedWeapon == "Gun")
        {
            ResetButtonsAlphaToBlack();
            buttonArray[0].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetKey(KeyCode.Alpha2) || SelectedWeapon.selectedWeapon == "ShotGun")
        {
            ResetButtonsAlphaToBlack();
            buttonArray[1].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetKey(KeyCode.Alpha3) || SelectedWeapon.selectedWeapon == "MachineGun")
        {
            ResetButtonsAlphaToBlack();
            buttonArray[2].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetKey(KeyCode.Alpha4) || SelectedWeapon.selectedWeapon == "Sniper")
        {
            ResetButtonsAlphaToBlack();
            buttonArray[3].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetKey(KeyCode.Alpha5) || SelectedWeapon.selectedWeapon == "RPG")
        {
            ResetButtonsAlphaToBlack();
            buttonArray[4].GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void ResetButtonsAlphaToBlack()
    {
        foreach (Buttons thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}

