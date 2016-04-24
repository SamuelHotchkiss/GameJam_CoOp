using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour 
{
	public GameObject target;
	public GameObject healthBar;

	Vector3 ogScale;
	bool player;

	public float xOffset, yOffset, zOffset;
	Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		offset = new Vector3(xOffset, yOffset, zOffset);
		if (target.GetComponent<PlayerShip>() != null)
			player = true;
		else
			player = false;

		ogScale = healthBar.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		transform.position = target.transform.position + offset;

		if(player)
		{
			healthBar.transform.localScale = new Vector3(ogScale.x * (target.GetComponent<PlayerShip>().currHP / target.GetComponent<PlayerShip>().maxHP), ogScale.y, ogScale.z);
		}
		else
		{
			healthBar.transform.localScale = new Vector3(ogScale.x * (target.GetComponent<bossBehavior>().health / target.GetComponent<bossBehavior>().maxHealth), ogScale.y, ogScale.z);
		}
	}
}
