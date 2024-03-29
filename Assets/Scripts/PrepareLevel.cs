using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrepareLevel : MonoBehaviour
{
    private GameOptions _options;
    private GameObject _dicePrefab;
    public GameObject dicePrefab_d6;
    public GameObject dicePrefab_d10;
    public GameObject dicePrefab_d20;
    public GameObject spawnAreaPlane;
    public float spawnHeight = 3.5f;
    private void Awake()
    {
        _options = DataSaver.loadData<GameOptions>("options");
        Debug.Log(_options.diceCount);
        Debug.Log(_options.diceType);
        
        switch (_options.diceType)
        {
            case 6:
                _dicePrefab = dicePrefab_d6;
                break;
            case 10:
                _dicePrefab = dicePrefab_d10;
                break;
            case 20:
                _dicePrefab = dicePrefab_d20;
                break;
        }

        // get spawn plane edge coordinates
        Vector3 planeSize = spawnAreaPlane.GetComponent<Renderer>().bounds.size;
        Vector3 planePosition = spawnAreaPlane.transform.position;
        Vector3 pointPositive = new Vector3(planePosition.x + planeSize.x / 2, 0, planePosition.z + planeSize.z / 2);
        Vector3 pointNegative = new Vector3(planePosition.x - planeSize.x / 2, 0, planePosition.z - planeSize.z / 2);
        Debug.Log("pointPositive"+pointPositive);
        Debug.Log("pointNegative"+pointNegative);
        Debug.Log(Vector3.Distance(new Vector3(pointPositive.x,0,0), new Vector3(pointNegative.x,0,0)));
        
        // calculate the spacing between points
        float xSpacing = Vector3.Distance(new Vector3(pointPositive.x,0,0), new Vector3(pointNegative.x,0,0)) / (_options.diceCount);
        float zSpacing = Vector3.Distance(new Vector3(0,0,pointPositive.z), new Vector3(0,0,pointNegative.z)) / (_options.diceCount);
        Debug.Log("yspacing"+xSpacing);
        Debug.Log("zspacing:"+zSpacing);
        
        // create the grid of points
        List<Vector3> spawnLocations = new List<Vector3>();
        for (int i = 0; i < _options.diceCount; i++)
        {
            for (int j = 0; j < _options.diceCount; j++)
            {
                // TODO this does not work as intended (its a spaced line and not a grid since i run out of diceCount)
                float xCoord = pointNegative.x + i * xSpacing;
                float zCoord = pointNegative.z + j * zSpacing;
                Vector3 point = new Vector3(xCoord, spawnHeight, zCoord);
                Debug.Log(point);
                spawnLocations.Add(point);
            }
        }
        
        List<GameObject> allDices = new List<GameObject>();
        for (int i = 0; i < _options.diceCount; i++)
        {
            // spawn and put dices in list
            Debug.Log(spawnLocations[i]);
            allDices.Add(Instantiate(_dicePrefab, spawnLocations[i], Quaternion.identity));
            Rigidbody rb = allDices[i].AddComponent<Rigidbody>();
            rb.useGravity = false;
            
            // make dice thowable
            DiceRandomForce forceScript = allDices[i].AddComponent<DiceRandomForce>();
            forceScript.maxRandomForce = 1f;
            forceScript.minRandomForce = -1f;

        }
        
    }
}
