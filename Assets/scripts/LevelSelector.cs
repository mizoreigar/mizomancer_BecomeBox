/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelector : MonoBehaviour {

	#region Variables
	public Button[] Buttons;
	#endregion

	#region Unity Methods


	#region Buttons

	public void button1()
	{
		SceneManager.LoadScene("1");
	}

	public void button2()
	{
		SceneManager.LoadScene("2");
	}

	public void button3()
	{
		SceneManager.LoadScene("3");
	}
	public void button4()
	{
		SceneManager.LoadScene("4");
	}
	public void button5()
	{
		SceneManager.LoadScene("5");
	}
	public void button6()
	{
		SceneManager.LoadScene("6");
	}
	public void button7()
	{
		SceneManager.LoadScene("7");
	}

	public void button8()
	{
		SceneManager.LoadScene("8");
	}

	public void button9()
	{
		SceneManager.LoadScene("9");
	}

	public void button10()
	{
		SceneManager.LoadScene("10");
	}
	public void button11()
	{
		SceneManager.LoadScene("11");
	}
	public void button12()
	{
		SceneManager.LoadScene("12");
	}
	public void button13()
	{
		SceneManager.LoadScene("13");
	}
	public void button14()
	{
		SceneManager.LoadScene("14");
	}
	public void button15()
	{
		SceneManager.LoadScene("15");
	}
	public void button16()
	{
		SceneManager.LoadScene("16");
	}
	public void button17()
	{
		SceneManager.LoadScene("17");
	}
	public void button18()
	{
		SceneManager.LoadScene("18");
	}
	public void button19()
	{
		SceneManager.LoadScene("19");
	}
	public void button20()
	{
		SceneManager.LoadScene("20");
	}
	public void button21()
	{
		SceneManager.LoadScene("21");
	}
	public void button22()
	{
		SceneManager.LoadScene("22");
	}
	public void button23()
	{
		SceneManager.LoadScene("23");
	}
	public void button24()
	{
		SceneManager.LoadScene("24");
	}
	public void button25()
	{
		SceneManager.LoadScene("25");
	}
	public void button26()
	{
		SceneManager.LoadScene("26");
	}
	public void button27()
	{
		SceneManager.LoadScene("27");
	}
	public void button28()
	{
		SceneManager.LoadScene("28");
	}
	public void button29()
	{
		SceneManager.LoadScene("29");
	}
	public void button30()
	{
		SceneManager.LoadScene("30");
	}
	#endregion


	public void Start () 
	{
		//PlayerPrefs.DeleteAll();
		int levelReached = PlayerPrefs.GetInt("levelReached",1);
		for (int i = 0; i < Buttons.Length; i++)
		{
			if (i + 1 > levelReached)
			{
				Buttons[i].interactable = false;
			}
			else Buttons[i].interactable = true;
		}
	}
	
	

	

	#endregion
}
