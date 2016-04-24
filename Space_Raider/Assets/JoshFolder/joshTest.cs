using UnityEngine;
using System.Collections;

public class joshTest : MonoBehaviour 
{
    public float speed = 2.0f;
    public int health = 5;

    public GameObject bullet;
    public Transform bulletSpawn;

	// Use this for initialization
	void Start () 
    {
        djScript.sounds = GameObject.FindGameObjectWithTag("dj").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetKey(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.x += Time.deltaTime * speed;
            transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = (GameObject)Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            b.GetComponent<explodey>().direction = this.transform.forward;
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "EnemyBullet")
        {
            health--;
            Destroy(other.gameObject);

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
