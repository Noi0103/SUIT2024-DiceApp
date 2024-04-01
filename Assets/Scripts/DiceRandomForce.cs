using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// input in the main level to throw dice
/// </summary>
public class DiceRandomForce : MonoBehaviour
{
    public float minRandomForce;
    public float maxRandomForce;
    public int diceFaceNumber;

    private float _forceX, _forceY, _forceZ;
    private Rigidbody _Rigidbody;
    
    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {   
        // pc input
        if (Input.GetKey("up"))
        {
            _Rigidbody.useGravity = true;
            RollDice();
        }
        
        // android touch input
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                _Rigidbody.useGravity = true;
                RollDice();
            }
        }
    }
    
    /// <summary>
    /// adding a random force and torgue to the dice object
    /// </summary>
    /// <returns></returns>
    private void RollDice()
    {
        _forceX = Random.Range(minRandomForce, maxRandomForce);
        _forceY = Random.Range(0, 0.5f*maxRandomForce);
        _forceZ = Random.Range(minRandomForce, maxRandomForce);
        
        _Rigidbody.AddForce(_forceX, _forceY, _forceZ, ForceMode.Impulse);
        _Rigidbody.AddTorque(2*_forceX, 2*_forceY, 2*_forceZ, ForceMode.Impulse);
    }
}
