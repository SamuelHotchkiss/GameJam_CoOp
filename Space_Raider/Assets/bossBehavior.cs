using UnityEngine;
using System.Collections;

public class bossBehavior : MonoBehaviour 
{
    public int health = 5;

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
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            health -= (int)other.gameObject.GetComponent<explodey>().damage;
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

}
