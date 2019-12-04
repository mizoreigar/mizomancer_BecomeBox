/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class pausebuttonscript : MonoBehaviour {

	#region Variables
	public GameObject pauseMenu;
	public GameObject Stick;
	public GameObject Pause;
	#endregion

	#region Unity Methods

	public void Start()
	{
	}


	public void goMainMenu()
	{
		SceneManager.LoadScene("-1");
	}
	#endregion
}
