/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour {

	#region Variables
	public Image img;
	public AnimationCurve curve;
	public SceneFader sceneFader;
	#endregion

	#region Unity Methods

	public void FadeTo(string scene)
	{
		StartCoroutine(FadeOut(scene));
	}

	IEnumerator FadeIn()
	{
		float t = 1f;
		while (t > 0f)
		{
			t -= Time.deltaTime;
			float a=curve.Evaluate(t);
			img.color = new Color(0f, 0f, 0f, t);
			yield return 0;
		}
	}

	IEnumerator FadeOut(string scene)
	{
		float t = 0f;
		while (t < 1f)
		{
			t += Time.deltaTime;
			float a = curve.Evaluate(t);
			img.color = new Color(0f,0f,0f,a);
			yield return 0;
		}

		SceneManager.LoadScene(scene);
	}

	

	void Start () 
	{
		StartCoroutine(FadeIn());
	}
	
	
	void Update () 
	{
		
	}

	#endregion
}
