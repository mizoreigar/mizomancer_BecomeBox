/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;

public class obstaclefinder : MonoBehaviour {

	#region Variables
	#endregion

	#region Unity Methods

	void Start () 
	{
		
	}
	
	
	void Update () 
	{
		
	}

	public void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Player")
		{
			Debug.Log("we hit obj");
		}
	}
	#endregion
}
