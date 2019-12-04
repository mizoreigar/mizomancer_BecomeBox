/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;

public class sawsoundvolme : MonoBehaviour {

	#region Variables
	AudioSource[] sounds;
	#endregion

	#region Unity Methods

	void Start () 
	{
		sounds = GetComponents<AudioSource>();

	}


	void Update () 
	{
		sounds[0].Play();
	}

	#endregion
}
