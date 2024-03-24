using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		Debug.Log("Load Level");
		SceneManager.LoadSceneAsync(1);
	}
	public void QuitGame()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}


}
