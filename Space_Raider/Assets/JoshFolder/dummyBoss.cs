using UnityEngine;
using System.Collections;

public class dummyBoss : MonoBehaviour
{
    public float health = 5;

    public GameObject explosion;

    public GameObject enemyBullet;

    public Transform[] spawns = new Transform[6];

    public float rotateSpeed = 15.0f;
    public float fireSpeed = 0.5f;
    public float switchDirTime = 1.0f;

    int rotateDir = 1;
    float switchTimer = 0.0f;
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
        switchTimer += Time.deltaTime;
        if (switchTimer >= switchDirTime)
        {
            switchTimer -= switchDirTime;
            rotateDir *= -1;
        }

        transform.Rotate(Vector3.up, rotateDir * rotateSpeed * Time.deltaTime);
        //spawns[0].position = 
        //float deg = Vector3.Angle(Vector3.forward, new Vector3(transform.forward.x, 0.0f, transform.forward.z));
        //spawns[0].transform.localEulerAngles = new Vector3(0.0f, deg, 0.0f);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerBullet" )
        {
            health -= other.gameObject.GetComponent<explodey>().damage;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Object obj = Instantiate(explosion, this.transform.position, this.transform.rotation);
                Destroy(obj, 1);
                GameObject gm = GameObject.FindWithTag("gm");
                if (gm)
                    gm.GetComponent<GameManager>().BossDied();
                else
                    Debug.Log("Unable to find gm tag", gameObject);
                Destroy(gameObject);
            }
        }
    }

    void FireBullets()
    {
        for (int i = 0; i < spawns.Length; ++i)
        {
            Transform t = spawns[i];
            GameObject obj = (GameObject)Instantiate(enemyBullet, t.position, Quaternion.identity);
            obj.GetComponent<badBullet>().direction = Vector3.Normalize(t.position - transform.position);
        }
    }
}
