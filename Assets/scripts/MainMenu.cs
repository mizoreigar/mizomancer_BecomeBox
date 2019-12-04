/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	#region Variables
	#endregion

	#region Unity Methods

	public void Start()
	{
		
	}

	public void GameStart()
	{
		//PlayerPrefs.DeleteAll();
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		int savedlevel = PlayerPrefs.GetInt("kayit");

		if (savedlevel == 0)
		{
			SceneManager.LoadScene(savedlevel + 2);
		}
		else
		{
			SceneManager.LoadScene(savedlevel+1);
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

		}
	}

	public void LevelSelector()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void GameQuit()
	{
		Application.Quit();
	}
	#endregion
}
