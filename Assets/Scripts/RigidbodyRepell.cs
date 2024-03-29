using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RigidbodyRepellLocalY : MonoBehaviour
{
    [FormerlySerializedAs("repelForce")] public float repellForce = 5f;
    public bool negativeZAxis;

    private void Awake()
    {
        if (negativeZAxis)
        {
            repellForce = repellForce * -1;
        }
    }

    /// <summary>
    /// repell the incoming rigidbody object in the local y direction when collision occurs
    /// </summary>
    /// <param name="collision"></param>
    /// <returns></returns>
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidbody = collision.rigidbody;

        if (otherRigidbody != null)
        {
            Vector3 repelDirection = transform.right; // Use the local z axis as the repel direction
            otherRigidbody.AddForce(repelDirection * repellForce, ForceMode.Impulse);
        }
    }
}
