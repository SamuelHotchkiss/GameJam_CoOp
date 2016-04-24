﻿using UnityEngine;
using System.Collections;

public class HeavyHitter : PlayerShip
{
	float charge;
	bool first;
	LineRenderer line;
	//int mask;

	public float chargeLimit, superBaseDamage;
	public LayerMask laserMask;

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
			RaycastHit hit;

			if (aimVec.magnitude > 0.1f)
				ray = new Ray(transform.position, aimVec);

			line.SetPosition(0, ray.origin);

			if (Physics.Raycast(ray, out hit, 100, laserMask))
			{
				line.SetPosition(1, hit.point);
				hit.collider.gameObject.GetComponent<dummyBoss>().health -= superBaseDamage;
			}
			else
				line.SetPosition(1, ray.GetPoint(100));

			yield return null;
		}

		line.enabled = false;
		first = false;
	}
}
