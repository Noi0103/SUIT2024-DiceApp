using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PrepareLevel : MonoBehaviour
{
    private GameOptions _options;
    private GameObject _dicePrefab;
    [FormerlySerializedAs("dicePrefab_d4")] public GameObject dicePrefabD4;
    [FormerlySerializedAs("dicePrefab_d6")] public GameObject dicePrefabD6;
    [FormerlySerializedAs("dicePrefab_d10")] public GameObject dicePrefabD10;
    [FormerlySerializedAs("dicePrefab_d20")] public GameObject dicePrefabD20;
    public GameObject spawnAreaPlane;
    public List<GameObject> allDices;
    public float minForce = -2.5f;
    public float maxForce = 2.5f;
    public bool isThrown = false;
    private void Awake()
    {
        _options = DataSaver.loadData<GameOptions>("options");
        Debug.Log("loaded count: "+_options.diceCount);
        Debug.Log("loaded type: "+_options.diceType);
        
        switch (_options.diceType)
        {
            case 4:
                _dicePrefab = dicePrefabD4;
                break;
            case 6:
                _dicePrefab = dicePrefabD6;
                break;
            case 10:
                _dicePrefab = dicePrefabD10;
                break;
            case 20:
                _dicePrefab = dicePrefabD20;
                break;
        }

        // get spawn plane edge coordinates
        Vector3 planeSize = spawnAreaPlane.GetComponent<Renderer>().bounds.size;
        Vector3 planePosition = spawnAreaPlane.transform.position;
        Vector3 pointPositive = new Vector3(planePosition.x + planeSize.x / 2, 0, planePosition.z + planeSize.z / 2);
        Vector3 pointNegative = new Vector3(planePosition.x - planeSize.x / 2, 0, planePosition.z - planeSize.z / 2);
        Debug.Log("pointPositive"+pointPositive);
        Debug.Log("pointNegative"+pointNegative);
        
        // calculate the spacing between points
        float xSpacing = Vector3.Distance(new Vector3(pointPositive.x,0,0), new Vector3(pointNegative.x,0,0)) / (_options.diceCount);
        float zSpacing = Vector3.Distance(new Vector3(0,0,pointPositive.z), new Vector3(0,0,pointNegative.z)) / (_options.diceCount);
        Debug.Log("yspacing"+xSpacing);
        Debug.Log("zspacing:"+zSpacing);
        
        // create points to spawn
        List<Vector3> spawnLocations = new List<Vector3>();
        for (int i = 0; i < _options.diceCount; i++)
        {
            float xCoord = Random.Range(pointNegative.x, pointPositive.x);
            float zCoord = Random.Range(pointNegative.z, pointPositive.z);
            Vector3 point = new Vector3(xCoord, spawnAreaPlane.transform.position.y, zCoord);
            //Debug.Log(point);
            spawnLocations.Add(point);
            
        }
        
        
        for (int i = 0; i < _options.diceCount; i++)
        {
            // spawn and put dices in list
            //Debug.Log("Location: "+spawnLocations[i]);
            allDices.Add(Instantiate(_dicePrefab, spawnLocations[i], Quaternion.identity));
            
            Rigidbody rb = allDices[i].AddComponent<Rigidbody>();
            rb.useGravity = false;
            
            // make dice thowable
            DiceRandomForce forceScript = allDices[i].AddComponent<DiceRandomForce>();
            forceScript.minRandomForce = minForce;
            forceScript.maxRandomForce = maxForce;
            
        }
        
    }
}
