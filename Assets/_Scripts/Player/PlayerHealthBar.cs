using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour 
{

    private Slider slider;


	// Use this for initialization
	void Start () 
	{
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        slider.value = Player.playerHealth;
	}
}