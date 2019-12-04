/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour {

	#region 
	public float visionRadius;
	public float fireRate;
	public float rotatespeed;
	float enemy = 0;
	float time;
	public GameObject bullet;

	public GameObject target;
	#endregion

	#region Unity Methods

	void Start () 
	{
		CircleCollider2D collider = GetComponent<CircleCollider2D>();
		collider.radius = visionRadius;
		
	}
	
	
	void Update () 
	{
		time += Time.deltaTime;
		if (target!=null && enemy==1)
		{
			float targetAngle = Mathf.Atan2(transform.position.y - target.transform.position.y,
									  transform.position.x - target.transform.position.x) * Mathf.Rad2Deg;

			float nextAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime * rotatespeed);

			transform.eulerAngles = new Vector3(0f, 0f, nextAngle);
	
			if (IsNeartargetAngle(transform.eulerAngles.z, targetAngle, 50f))
			{
				if (time >= fireRate)
				{
					GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
					Bullet bulletScript = bulletClone.GetComponent<Bullet>();

					bulletScript.SetVelocityVectors(
						Mathf.Cos(targetAngle * Mathf.Deg2Rad) * -1f,
						Mathf.Sin(targetAngle * Mathf.Deg2Rad) * -1f, 50f);
					time = 0f;
				}
			}

		}
		
	}


	bool IsNeartargetAngle (float current, float target, float offset)
	{
		current = current % 360;
		target = target % 360;

		if (current < 0f)
			current += 360;
		if (target < 0f)
			target +=360;
		if (Mathf.Abs(target - current) <= offset)
			return true;
		else
		return false;
	}

	private void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.collider.tag == "Player")
		{
			enemy = 1;

		}
	}

	private void OnCollisionExit2D(Collision2D collisionInfo)
	{
		if (collisionInfo.collider.tag == "Player")
		{
			enemy = 0;

		}
	}

	//IEnumerator Shooting()
	//{
	//	while (true)
	//	{
	//		Instantiate(bullet, gunEnd.position, gunEnd.rotation);
	//		yield return new WaitForSeconds(5f);
	//	}
	//}

	#endregion
}
