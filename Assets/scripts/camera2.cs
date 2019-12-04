﻿using UnityEngine;
using System.Collections;
public class camera2 : MonoBehaviour
{
	public Transform target;
	private float trackSpeed = 35;
	// Set target
	public void SetTarget(Transform t)
	{
		target = t;
	}
	// Track target
	void LateUpdate()
	{
		if (target)
		{
			var v = transform.position;
			v.x = target.position.x;
			transform.position = Vector3.MoveTowards(transform.position, v, trackSpeed * Time.deltaTime);
		}
	}
}