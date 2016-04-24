using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{
    public Transform[] spawns;
    public GameObject bullet;

    public float fireRate = 0.5f;

    public float rotateSpeed = 45.0f;
    public float rotateChange = 1.0f;

    float fireTimer = 0.0f;
    float rotateTimer = 0.0f;
    int rotateDir = 1;


	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            fireTimer -= fireRate;
            FireBullets();
        }

        rotateTimer += Time.deltaTime;
        if (rotateTimer >= rotateChange)
        {
            rotateTimer -= rotateChange;
            rotateDir *= -1;
        }

        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * rotateDir);
	}

    void FireBullets()
    {
        foreach (Transform t in spawns)
        {
            Vector3 dir = t.position - transform.position;
            Vector3 pos = new Vector3(t.position.x, 0.0f, t.position.z);
            GameObject obj = (GameObject)Instantiate(bullet, pos, Quaternion.identity);
            obj.GetComponent<badBullet>().direction = dir.normalized;
        }
    }
}
