using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayOptions : MonoBehaviour
{
    private GameOptions _options;
    
    private TMP_Text _diceOptions;
    private TMP_Text _result;

    private PrepareLevel _prepareLevel;
    private DiceRandomForce[] _diceScript;
    private int[] _resultValues;
    private string _resultText;
    
    private void Awake()
    {
        _diceOptions = transform.GetChild(2).GetComponent<TMP_Text>();
        _result = transform.GetChild(3).GetComponent<TMP_Text>();
        _prepareLevel = FindFirstObjectByType<PrepareLevel>();
    }

    void Start()
    {
        _options = DataSaver.loadData<GameOptions>("options");
        _diceOptions.text = "d" + _options.diceType + "\t" + _options.diceCount + " pcs";
        _resultValues = new int[_options.diceType];
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("done throwing? "+_prepareLevel.isThrown);
        if (_prepareLevel.isThrown)
        {
            if (_diceScript == null)
            {
                _diceScript = FindObjectsByType<DiceRandomForce>(FindObjectsSortMode.None);
                Debug.Log("found number of dices: " + _diceScript.Length);
            }
            else
            {
                _resultText = string.Empty;

                for (int i = 0; i < _resultValues.Length; i++)
                {
                    _resultValues[i] = 0;
                }
                for (int n = 0; n < _options.diceCount; n++)
                {
                    for (int i = 0; i < _options.diceType; i++)
                    {
                        //Debug.Log("DEBUG " + _diceScript[i].diceFaceNumber);
                        if (_diceScript[n].diceFaceNumber-1 == i)
                        {
                            _resultValues[i]++;
                        }
                    }
                }

                int sum = 0;
                for (int i = 0; i < _options.diceType; i++)
                {
                    sum += _resultValues[i];
                    if (_resultValues[i] != 0)
                    {
                        _resultText = _resultText + " " + (i + 1) + "*" + _resultValues[i];
                    }
                }
                //Debug.Log(_resultText);
                _result.text = _resultText + "\tsum(" + sum + ")";
            }
        }
    }

    public void LoadMenu()
    {
        Debug.Log("Load Level");
        SceneManager.LoadSceneAsync(0);
    }
}
