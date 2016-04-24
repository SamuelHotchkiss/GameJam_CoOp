using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
	public int playerNum;
	public float moveSpeed, orbitDistance;
	Vector3 movement;

	[SerializeField]
	Vector3 aim;

	public GameObject satellite;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		float x, y, aimX, aimY;
		movement.x = Input.GetAxis("Joy" + playerNum + "_LeftX");
		movement.z = Input.GetAxis("Joy" + playerNum + "_LeftY");

		aimX = Input.GetAxis("Joy" + playerNum + "_RightX");
		aimY = Input.GetAxis("Joy" + playerNum + "_RightY");

		if (Mathf.Abs(aimX) >= 0.0f)
			aim.x = aimX;
		if (Mathf.Abs(aimY) >= 0.0f)
			aim.z = aimY;


		if (Input.GetButtonDown("Joy" + playerNum + "_A"))
		{
			Debug.Log("Player" + playerNum + " pushed A!");
		}
		else if (Input.GetButtonDown("Joy" + playerNum + "_B"))
		{
			Debug.Log("Player" + playerNum + " pushed B!");
		}
		else if (Input.GetButtonDown("Joy" + playerNum + "_X"))
		{
			Debug.Log("Player" + playerNum + " pushed X!");
		}
		else if (Input.GetButtonDown("Joy" + playerNum + "_Y"))
		{
			Debug.Log("Player" + playerNum + " pushed Y!");
		}
		else if (Input.GetButtonDown("Joy" + playerNum + "_LB"))
		{
			Debug.Log("Player" + playerNum + " pushed LB!");
		}
		else if (Input.GetButtonDown("Joy" + playerNum + "_RB"))
		{
			Debug.Log("Player" + playerNum + " pushed RB!");
		}
		else if (Input.GetAxis("Joy" + playerNum + "_LTrigger") > 0.0f)
		{
			Debug.Log("Player" + playerNum + " LTrigger held down!");
		}
		else if (Input.GetAxis("Joy" + playerNum + "_RTrigger") > 0.0f)
		{
			Debug.Log("Player" + playerNum + " RTrigger held down!");
		}
		if (Mathf.Abs(x = Input.GetAxis("Joy" + playerNum + "_DpadX")) > 0.0f)
		{
			if (x > 0.0f)
				Debug.Log("Player" + playerNum + " pressing right on Dpad!!");
			else
				Debug.Log("Player" + playerNum + " pressing left on Dpad!");
		}
		if (Mathf.Abs(y = Input.GetAxis("Joy" + playerNum + "_DpadY")) > 0.0f)
		{
			if (y > 0.0f)
				Debug.Log("Player" + playerNum + " pressing up on Dpad!");
			else
				Debug.Log("Player" + playerNum + " pressing down on Dpad!");
		}


		MakeMove(movement.x, -movement.z);
		Aim(aim.x, -aim.z);
	}

	void MakeMove(float _x, float _z)
	{
		if (Mathf.Abs(_x) >= 0.0f || Mathf.Abs(_z) > 0.0f)
		{
			//Vector3 old = transform.position;
			Vector3 dir = new Vector3(_x, 0.0f, _z) * moveSpeed * Time.deltaTime;
			transform.LookAt(transform.position + dir);
			transform.Translate(dir, Space.World);
		}
	}

	void Aim(float _x, float _z)
	{
		if (satellite)
		{
			float deg = 0.0f;
			Vector3 me;//, rot;
			me = transform.position;
			if (Mathf.Abs(_x) > 0.25f
				|| Mathf.Abs(_z) > 0.25f)
			{
				satellite.transform.position = (new Vector3((orbitDistance * _x) + me.x, 0, (orbitDistance * _z) + me.z));
				deg = Vector3.Angle(Vector3.forward, new Vector3(_x, 0.0f, _z));
			}
			else
			{
				satellite.transform.position = (new Vector3((orbitDistance * transform.forward.x) + me.x, 0, (orbitDistance * transform.forward.z) + me.z));
				deg = Vector3.Angle(Vector3.forward, new Vector3(transform.forward.x, 0.0f, transform.forward.z));
			}

			if (satellite.transform.position.x < me.x)
				deg = -deg;
			satellite.transform.localEulerAngles = new Vector3(270.0f, deg, 0.0f);
		}
	}
}
