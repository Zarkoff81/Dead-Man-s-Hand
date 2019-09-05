using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperExplosionF : MonoBehaviour
{
    public float silaOdbijanja;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ball")
        {
            Debug.Log("bump");
            other.attachedRigidbody.AddExplosionForce(silaOdbijanja, transform.position, 3f);
        }
    }
}
