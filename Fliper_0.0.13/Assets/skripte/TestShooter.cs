using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShooter : MonoBehaviour
{

    public float snaga;

    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddForce(new Vector3(0.4f,0,1) * snaga, ForceMode.Impulse);
    }
}
