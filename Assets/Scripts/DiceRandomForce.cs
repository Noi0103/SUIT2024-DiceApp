using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRandomForce : MonoBehaviour
{
    public float minRandomForce;

    public float maxRandomForce;

    private float forceX, forceY, forceZ;
    private Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            m_Rigidbody.useGravity = true;
            RollDice();
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
