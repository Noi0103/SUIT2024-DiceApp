using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareLevel : MonoBehaviour
{
    private GameOptions _options; 
    private void Awake()
    {
        _options = DataSaver.loadData<GameOptions>("options");
        Debug.Log(_options.diceCount);
        Debug.Log(_options.diceType);
        //TODO use options to spawn dices by type and count
        
    }

    private void SpawnDiceObjects(GameOptions option)
    {
        
    }
}
