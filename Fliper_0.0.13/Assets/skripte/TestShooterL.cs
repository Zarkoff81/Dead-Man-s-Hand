using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShooterL : MonoBehaviour
{
    public float snaga;

    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddForce(new Vector3(-0.9f, 0, 0.2f) * snaga, ForceMode.Impulse);
    }
}
