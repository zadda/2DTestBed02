using UnityEngine;
using System.Collections;

public class Enemy03Grenade : MonoBehaviour
{
    [SerializeField]
    private Transform lineStart;
    [SerializeField]
    private Transform lineEnd;

    [SerializeField]
    private GameObject grenade;


    [SerializeField]
    private Transform launchPosition;

    [SerializeField]
    private GameObject gas;
    
    public float health = 200;

    public static bool stopAttacking = false;
    
    private bool grenadeFired = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (!grenadeFired)
        {
            Fire();
        }
	}

    void Fire()
    {
        grenadeFired = true;
        GameObject granaat = Instantiate(grenade, launchPosition.position, Quaternion.identity) as GameObject;
        //granaat.transform.rotation = Quaternion.Euler(0, 0, 351);
        granaat.GetComponent<Rigidbody2D>().velocity = new Vector3(-70, launchPosition.rotation.z * 100 + 2, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //zorgt ervoor dat de rook hoog genoeg zichtbaar is, anders deels onder de grond
        Vector3 positie = GetComponent<GasGrenade>().transform.position;
        //positie -= new Vector3(52, 8, 0);

        //Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject explosie = Instantiate(gas,positie, Quaternion.identity) as GameObject;

       
        Destroy(explosie, 10f);
        //Destroy(gameObject);
    }
}
