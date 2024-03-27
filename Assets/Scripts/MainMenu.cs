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
		Debug.Log(inputDiceType.captionText.text);
		_options.diceType = int.Parse(inputDiceType.captionText.text);
		Debug.Log(inputDiceCount.text);
		_options.diceCount = int.Parse(inputDiceCount.text);
		Debug.Log(_options);
		// reload whenever with: PlayerInfo loadedData = DataSaver.loadData<PlayerInfo>("players");
		DataSaver.saveData(_options, "options");
		Debug.Log(_options);
		Debug.Log("Load Level");
		SceneManager.LoadSceneAsync(1);
	}
	public void QuitGame()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}


}
