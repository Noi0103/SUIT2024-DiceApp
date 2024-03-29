using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// input in the main level to throw dice
/// </summary>
public class DiceRandomForce : MonoBehaviour
{
    public float minRandomForce = -1f;
    public float maxRandomForce = 1f;
    public int diceFaceNumber;

    private float forceX, forceY, forceZ;
    private Rigidbody m_Rigidbody;
    
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {   
        // pc input
        if (Input.GetKey("up"))
        {
            m_Rigidbody.useGravity = true;
            RollDice();
        }
        
        // android touch input
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                m_Rigidbody.useGravity = true;
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
        forceX = Random.Range(minRandomForce, maxRandomForce);
        forceY = Random.Range(minRandomForce, maxRandomForce);
        forceZ = Random.Range(minRandomForce, maxRandomForce);
        
        m_Rigidbody.AddForce(forceX, forceY, forceZ, ForceMode.Impulse);
        m_Rigidbody.AddTorque(forceX, forceY, forceZ, ForceMode.Impulse);
    }
}
