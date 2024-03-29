using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
	[SerializeField] private TMP_Dropdown inputDiceType;
	[SerializeField] private TMP_InputField inputDiceCount;
	private GameOptions _options; 

	public void PlayGame()
	{
		Debug.Log(int.Parse(inputDiceType.captionText.text));
		Debug.Log(inputDiceCount.text);
		Debug.Log(_options);
		_options = new GameOptions
		{
			diceType = int.Parse(inputDiceType.captionText.text),
			diceCount = int.Parse(inputDiceCount.text)
		};

		// reload whenever with: DataSaver.loadData<GameOptions>("options");
		DataSaver.saveData(_options, "options");
		
		Debug.Log("Load Level");
		SceneManager.LoadSceneAsync(1);
	}
	public void QuitGame()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}


}
