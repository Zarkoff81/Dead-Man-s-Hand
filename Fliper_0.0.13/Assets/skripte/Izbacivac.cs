using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Izbacivac : MonoBehaviour
{

    public float snaga;

        
    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddForce(Vector3.forward * snaga, ForceMode.Impulse);
    }
}
