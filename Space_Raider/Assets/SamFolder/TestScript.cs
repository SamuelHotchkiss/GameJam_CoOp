using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour 
{
	public int playerNum;
	public float moveSpeed;
	Vector3 movement;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		movement.x = Input.GetAxis("Joy" + playerNum + "_LeftX");
		movement.y = Input.GetAxis("Joy" + playerNum + "_LeftY");

		if(Input.GetButtonDown("Joy" + playerNum + "_A"))
		{
			Debug.Log("Player" + playerNum + " pushed A!");
		}

		MakeMove(movement.x, -movement.y);
	}

	void MakeMove(float _x, float _y)
	{
		if(Mathf.Abs(_x) > 0.0f || Mathf.Abs(_y) > 0.0f)
		{
			transform.Translate(new Vector3(_x, _y, 0.0f) * moveSpeed * Time.deltaTime);
		}
	}
}
