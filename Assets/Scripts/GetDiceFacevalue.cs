using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetDiceFacevalue : MonoBehaviour
{
    // Start is called before the first frame update
    private DiceRandomForce dice;
    private Camera mainCamera;
    private GameObject cameraReference;
    void Start()
    {
        dice = FindObjectOfType<DiceRandomForce>();
    }
    
    /// <summary>
    /// get colliding dice components rigidbody and parse the name according to the up 
	/// facing side into a int value
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private void OnTriggerStay(Collider other)
    {
        if (dice != null)
        {
            if (dice.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                dice.diceFaceNumber=int.Parse(other.name);
                Debug.Log(dice.diceFaceNumber);
            }
        }
    }
    
}
