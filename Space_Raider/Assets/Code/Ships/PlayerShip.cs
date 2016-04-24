using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour
{
	public int playerNum;

	public float maxHP, currHP, damage, fireCoolMax;

	float fireCool;

	public float moveSpeed, orbitDistance;
	public GameObject aimReticule, bullet;

	string control;
	Vector3 moveVec;
	Vector3 aimVec;

	// Use this for initialization
	void Start()
	{
		djScript.sounds = GameObject.FindGameObjectWithTag("dj").GetComponent<AudioSource>();

		control = "Joy" + playerNum + "_";
		if (moveSpeed == 0.0f)
			moveSpeed = 5.0f;
		if (maxHP == 0.0f)
			maxHP = 10.0f;
		if (damage == 0.0f)
			damage = 1.0f;
		if (fireCoolMax == 0.0f)
			fireCoolMax = 1.0f;

		fireCool = 0.0f;
		currHP = maxHP;
		moveVec = Vector3.zero;
		aimVec = Vector3.zero;
	}

	// Update is called once per frame
	void Update()
	{
		if (fireCool > 0.0f)
			fireCool -= Time.deltaTime;

		moveVec.x = Input.GetAxis(control + "LeftX");
		moveVec.z = Input.GetAxis(control + "LeftY");
		aimVec.x = Input.GetAxis(control + "RightX");
		aimVec.z = Input.GetAxis(control + "RightY");

		HandleMoveInput(moveVec.x, -moveVec.z);
		HandleAimInput(aimVec.x, -aimVec.z);

		if (Input.GetAxis(control + "RTrigger") < 0.0f
			&& fireCool <= 0.0f)
			Fire();
	}

	void HandleMoveInput(float _x, float _z)
	{
		if (Mathf.Abs(_x) > 0.0f
			|| Mathf.Abs(_z) > 0.0f)
		{
			Vector3 move = new Vector3(_x, 0.0f, _z) * moveSpeed * Time.deltaTime;
			transform.LookAt(transform.position + move);
			transform.Translate(move, Space.World);
		}
	}

	void HandleAimInput(float _x, float _z)
	{
		if (aimReticule != null)
		{
			float deg = 0.0f;
			Vector3 me = transform.position;
			if (Mathf.Abs(_x) > 0.25f
				|| Mathf.Abs(_z) > 0.25f)
			{
				aimReticule.transform.position = (new Vector3((orbitDistance * _x) + me.x, me.y, (orbitDistance * _z) + me.z));
				deg = Vector3.Angle(Vector3.forward, new Vector3(_x, 0.0f, _z));
			}
			else
			{
				aimReticule.transform.position = (new Vector3((orbitDistance * transform.forward.x) + me.x, me.y, (orbitDistance * transform.forward.z) + me.z));
				deg = Vector3.Angle(Vector3.forward, new Vector3(transform.forward.x, 0.0f, transform.forward.z));
			}

			if (aimReticule.transform.position.x < me.x)
				deg = -deg;
			aimReticule.transform.localEulerAngles = new Vector3(270.0f, deg, 0.0f);
		}
	}

	void Fire()
	{
		if (bullet)
		{
			fireCool = fireCoolMax;
			GameObject b = (GameObject)Instantiate(bullet, aimReticule.transform.position, Quaternion.identity);
			b.GetComponent<explodey>().damage = damage;
			b.GetComponent<explodey>().direction = aimReticule.transform.position - transform.position;
		}
		else
		{
			Debug.Log("Player_" + playerNum + " has no bullets to fire!");
		}
	}
}
