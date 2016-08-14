using UnityEngine;
using System.Collections;

public class FlashBang : MonoBehaviour
{

    [SerializeField]
    private GameObject grenade;

    [SerializeField]
    private Transform grenadeStartPosition;

    [SerializeField]
    private GameObject flash;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Throw()
    {
        GameObject granaat = Instantiate(grenade, grenadeStartPosition.transform.position, Quaternion.identity) as GameObject;
        granaat.GetComponent<Rigidbody2D>().velocity = new Vector3(80, -15, 0);
        granaat.GetComponent<Rigidbody2D>().rotation = -25;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(flash, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    //public void OnCollisionStay(Collision collision)
    //{

    //}
}