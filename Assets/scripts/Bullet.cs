/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{

	#region Variables
	Vector3 velocity;
	#endregion


	
	public void SetVelocityVectors(float x, float y, float magnitude)
	{
		velocity = new Vector3(x * (Time.deltaTime / 2f), y * (Time.deltaTime / 2f), 0f) * magnitude;
		Destroy(gameObject,5);
	}

	private void Update()
	{
		transform.Translate(velocity);
	}

	private void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.collider.tag == "Player")
		{
			Destroy(gameObject);

		}
	}
	private void OnCollisionStay2D(Collision2D collisionInfo)
	{
		if (collisionInfo.collider.tag == "Ground")
		{
			Destroy(gameObject);

		}
	
	}
}