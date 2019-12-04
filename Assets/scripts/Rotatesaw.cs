/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;

public class Rotatesaw : MonoBehaviour
{

	#region Variables

	#endregion

	#region Unity Methods
	

	void Start () 
	{
		
	}


	void FixedUpdate()
	{
		transform.Rotate(new Vector3(0, 0, 3f));
		
		
	}


		
	
	#endregion
}
