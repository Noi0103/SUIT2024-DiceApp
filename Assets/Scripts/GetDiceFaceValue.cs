using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetDiceFaceValue : MonoBehaviour
{
    // Start is called before the first frame update
    private DiceRandomForce _randomForceScript;
    private Camera _mainCamera;
    private GameObject _cameraReference;
    private PrepareLevel _prepareLevel;
    
    void Start()
    {
        _prepareLevel = FindFirstObjectByType<PrepareLevel>();
    }
    
    /// <summary>
    /// get colliding dice components rigidbody and parse the name according to the up 
	/// facing side into a int value
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private void OnTriggerStay(Collider other)
    {
        var parent = other.transform.parent;
        if (parent.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            Debug.Log("object stationary: "+parent.name);
            parent.GetComponent<DiceRandomForce>().diceFaceNumber = int.Parse(other.name);
            
            _prepareLevel.isThrown = true;
        }
    }
    
}
