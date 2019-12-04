/*
  Copyright (c) Mizomancer
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	
	#region Variables
	public Text timerText;
	private float startTime;
	#endregion


	#region Unity Methods
	void Start () {
		startTime = Time.time*1.3f;
 	}
	
	
	void Update () {
		float t = Time.time*1.3f - startTime;
		string minutes = ((int)t / 60).ToString();
		string seconds = (t % 60).ToString();
		timerText.text = minutes + ":" + seconds;
	}

	#endregion	
}
