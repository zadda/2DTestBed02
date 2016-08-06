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
       
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ResetButtonsAlphaToBlack();
            buttonArray[0].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            ResetButtonsAlphaToBlack();
            buttonArray[1].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            ResetButtonsAlphaToBlack();
            buttonArray[2].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            ResetButtonsAlphaToBlack();
            buttonArray[3].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
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

