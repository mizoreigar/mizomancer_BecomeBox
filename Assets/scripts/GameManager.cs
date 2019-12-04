/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	#region Variables

	public int targetFrameRate = 60;
	public float restartDelay = 1.5f;
	public float leveldelay = 1.7f;
	public int levelToUnlock;
	public int levelReached;
	
	#endregion

	#region Unity Methods


	public void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = targetFrameRate;

		//PlayerPrefs.DeleteAll()

		int currentUnlock = PlayerPrefs.GetInt("levelReached");

		if (currentUnlock < levelToUnlock)
		{
			//PlayerPrefs.SetInt("levelReached", levelToUnlock);
			PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));

		}
	}

	public void update()
	{
		
	}

	public void EndGame()
	{

		Invoke("Restart",restartDelay);
		
	}
	public void LevelPass()
	{

		Invoke("LoadNextLevel",leveldelay);
		
	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void LoadNextLevel()
	{
		//PlayerPrefs.DeleteAll();
		int currentUnlock = PlayerPrefs.GetInt("levelReached");

		if (currentUnlock < levelToUnlock)
		{
			PlayerPrefs.SetInt("levelReached", levelToUnlock);
			//PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));
		}
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	/*public void winLevel()
	{
		if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
		{
			PlayerPrefs.SetInt("levelReached", levelToUnlock);
		}
		scenefader.FadeTo(nextLevel);
		}*/
	#endregion
}
