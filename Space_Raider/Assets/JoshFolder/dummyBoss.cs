using UnityEngine;
using System.Collections;

public class dummyBoss : MonoBehaviour
{
    public int health = 5;

    public GameObject explosion;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerBullet" )
        {
            --health;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Object obj = Instantiate(explosion, this.transform.position, this.transform.rotation);
                Destroy(obj, 1);
                Destroy(gameObject);
            }
        }
    }
}
