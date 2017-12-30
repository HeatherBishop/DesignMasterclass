using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour {

	//Possibly the laziest code you have ever seen.
	//Dont judge me.
	//PS thanks for commenting your code :P 


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//load main menu
	public void LoadMainMenu()
	{
		SceneManager.LoadScene ("menu", LoadSceneMode.Single);
	}

	//load main scene

	public void LoadMainScene()
	{
		SceneManager.LoadScene ("scene", LoadSceneMode.Single);
	} 

	//load win screen
	public void LoadWinScreen()
	{
		SceneManager.LoadScene ("end", LoadSceneMode.Single);
	}

}
