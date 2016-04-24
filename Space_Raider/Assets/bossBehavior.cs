using UnityEngine;
using System.Collections;

public class bossBehavior : MonoBehaviour
{
	public float health = 5;

	public GameObject explosion;
	public GameObject TurretExplosion;
	public GameObject enemyBullet;

	public Transform[] spawns = new Transform[6];
	public GameObject[] turrets = new GameObject[4];

	public float rotateSpeed = 45.0f;
	public float fireSpeed = 0.1f;
	public float switchDirTime = 2.0f;

	int rotateDir = 1;
	float switchTimer = 0.0f;
	float duration = 0.0f;
	bool phaseTwo = false;
	public float maxHealth;

	// Use this for initialization
	void Start()
	{
		maxHealth = health;
	}

	// Update is called once per frame
	void Update()
	{
		if (health <= 0.0f)
			Death();

		if (phaseTwo)
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
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "PlayerBullet")
		{
			DealDamage(other.gameObject.GetComponent<explodey>().damage);
			Destroy(other.gameObject);

		}
	}

	public void DealDamage(float damage)
	{
		health -= damage;
		if (health <= maxHealth / 2.0f && phaseTwo == false)
		{
			BeginPhaseTwo();
		}
	}

	void BeginPhaseTwo()
	{
		foreach (GameObject g in turrets)
		{
			Object o = Instantiate(TurretExplosion, g.transform.GetChild(0).position, Quaternion.identity);
			Destroy(o, 0.5f);
			Destroy(g);
		}
		phaseTwo = true;
	}

	void FireBullets()
	{
		Vector3 scale = enemyBullet.transform.localScale;
		scale *= 2.0f;
		float speed = enemyBullet.GetComponent<badBullet>().speed;
		speed *= 0.5f;
		foreach (Transform t in spawns)
		{
			GameObject obj = (GameObject)Instantiate(enemyBullet, t.position, Quaternion.identity);
			Vector3 dir = t.position - transform.position;
			obj.GetComponent<badBullet>().direction = dir;
			obj.GetComponent<badBullet>().speed = speed;
			obj.transform.localScale = scale;
		}
	}

	void Death()
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
