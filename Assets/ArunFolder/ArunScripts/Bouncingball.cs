using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncingball : MonoBehaviour
{
    public float bounceForce = 5f;

    void OnCollisionEnter(Collision collision)
    {
        var force = Vector3.up * bounceForce;
        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }
}
