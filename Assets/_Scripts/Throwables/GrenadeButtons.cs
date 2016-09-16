/*
 * the HUD for the Grenade Quad
 * 
 */

using UnityEngine;
using System.Collections;

public class GrenadeButtons : MonoBehaviour 
{

    [SerializeField]
    private GrenadeButtons[] buttonArray;

  
    [SerializeField]
    private GameObject[] weapons;

    // Use this for initialization
    void Start()
    {
        //zet granaat standaard zichtbaar
        buttonArray[0].GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha6))
        {
            ResetButtonsAlphaToBlack();
            buttonArray[0].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            ResetButtonsAlphaToBlack();
            buttonArray[1].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            ResetButtonsAlphaToBlack();
            buttonArray[2].GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void ResetButtonsAlphaToBlack()
    {
        foreach (GrenadeButtons thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}