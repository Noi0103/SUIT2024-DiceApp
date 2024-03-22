using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyRepellLocalY : MonoBehaviour
{
    public float repelForce = 10f;

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
            Vector3 repelDirection = transform.up; // Use the local y axis as the repel direction
            otherRigidbody.AddForce(repelDirection * repelForce, ForceMode.Impulse);
        }
    }
}
