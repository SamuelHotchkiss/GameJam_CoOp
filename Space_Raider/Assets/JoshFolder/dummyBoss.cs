using UnityEngine;
using System.Collections;

public class dummyBoss : MonoBehaviour
{
    public int health = 5;

    public GameObject explosion;

    public GameObject enemyBullet;

    public Transform[] spawns = new Transform[6];

    public float rotateSpeed = 15.0f;
    public float fireSpeed = 0.5f;

    float duration = 0.0f;

	// Use this for initialization
	void Start () 
    {
        //int i = 0;
	    //foreach (Transform child in GetComponentInChildren<Transform>())
        //{
        //    spawns[i++] = child;
        //}
	}
	
	// Update is called once per frame
	void Update () 
    {
        duration += Time.deltaTime;
        if (duration >= fireSpeed)
        {
            duration -= fireSpeed;
            FireBullets();
        }

        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
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

    void FireBullets()
    {
        for (int i = 0; i < spawns.Length; ++i)
        {
            Transform t = spawns[i];
            GameObject obj = (GameObject)Instantiate(enemyBullet, t.position, t.rotation);
            obj.GetComponent<badBullet>().direction = t.forward;
        }
    }
}
