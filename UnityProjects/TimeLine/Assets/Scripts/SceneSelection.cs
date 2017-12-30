using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour {


	//load main menu
	public static void LoadMainMenu()
	{
		SceneManager.LoadScene ("menu", LoadSceneMode.Single);
	}

	//load main scene

	public void LoadMainScene()
	{
		SceneManager.LoadScene ("Main", LoadSceneMode.Single);
	} 

	//load win screen
	public static void LoadWinScreen()
	{
		SceneManager.LoadScene ("end", LoadSceneMode.Single);
	}
}
