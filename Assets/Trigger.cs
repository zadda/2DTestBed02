using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{

    [SerializeField]
    GameObject heliPeopleCarrier;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            heliPeopleCarrier.SetActive(true);
        }
        
    }
}
