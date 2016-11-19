using UnityEngine;
using System.Collections;

public class StealthBomber : MonoBehaviour 
{

    [SerializeField]
    private GameObject bombDropPosition;

    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private bool isBombing = false;

    private float timeDelay = 0f;
    private Vector3 startPositie;

    private int bombsDroppedCounter = 0;

	// Use this for initialization
	void Start () 
	{
        startPositie = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (bombsDroppedCounter == 5)
        {
            ResetBomber();
        }
        //move the jet when called
        if (SmokeGrenade.jetCalled)
        {
            transform.Translate(Vector3.right * 155f * Time.deltaTime);
        }
        
        //ofset so bomb dropping starts soon enough
        if (transform.position.x > SmokeGrenade.teBombarderenPositie.x -30)
        {
            isBombing = true;
        }

        if (isBombing)
        {
            if (timeDelay <= 0)
            {
                Bomb();
            }
            timeDelay -= Time.deltaTime;
        }
	}

    void Bomb()
    {
        bombsDroppedCounter += 1;
        timeDelay = 0.1f;
        //GameObject bom = Instantiate(bomb, bombDropPosition.transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        Instantiate(bomb, bombDropPosition.transform.position, Quaternion.Euler(0f, 0f, 0f));
    }

    //Put the bomber back to its start position
    void ResetBomber()
    {
        isBombing = false;
        SmokeGrenade.jetCalled = false;
        transform.position = startPositie;
        bombsDroppedCounter = 0;
    }

}
