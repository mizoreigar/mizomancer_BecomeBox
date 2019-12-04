/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class gameManagement : MonoBehaviour
{

	#region Variables

	bool gameHasEnded = false;
	public float restartDelay = 1.2f;
	public GameObject CompleteLevelUI;
	public GameObject FailedLevelUI;
	public GameObject End;
	public int sayac = 0;
	public int sayac2 = 0;
	public int sayac3 = 0;

	#endregion


	#region Unity Methods


	public void Start()
	{
		PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));


	}

	public void EndGame()

	{
		if (gameHasEnded == false && sayac == 0)
		{
			gameHasEnded = true;
			FailedLevelUI.SetActive(true);
			sayac2 = +1;
			if (sayac2 > 1)
			{
				sayac2 = 0;
			}

		}
	}
	public void CompleteLevel()

	{
		if (sayac2 == 0)
		{
			CompleteLevelUI.SetActive(true);
		}
		sayac = +1;
		if (sayac > 1)
		{
			sayac = 0;
		}


	}




	#endregion
}
