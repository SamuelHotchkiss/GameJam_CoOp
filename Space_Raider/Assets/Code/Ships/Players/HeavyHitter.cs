using UnityEngine;
using System.Collections;

public class HeavyHitter : PlayerShip
{
	float charge;
	bool first;
	LineRenderer line;

	public float chargeLimit, superBaseDamage;

	// Use this for initialization
	//void Start () 
	//{
	//
	//}

	protected override void Init()
	{
		base.Init();

		first = false;
		line = GetComponent<LineRenderer>();
		line.enabled = false;
	}

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();

		if (Input.GetAxis(control + "LTrigger") > 0.0f
			&& !first)
		{
			first = true;
			StopCoroutine("Lazer");
			StartCoroutine("Lazer");
		}
	}

	IEnumerator Lazer()
	{
		line.enabled = true;

		while (Input.GetAxis(control + "LTrigger") > 0.0f)
		{
			Ray ray = new Ray(transform.position, transform.forward);
			if (aimVec.magnitude > 0.1f)
				ray = new Ray(transform.position, aimVec);

			line.SetPosition(0, ray.origin);
			line.SetPosition(1, ray.GetPoint(100));

			yield return null;
		}

		line.enabled = false;
		first = false;
	}
}
