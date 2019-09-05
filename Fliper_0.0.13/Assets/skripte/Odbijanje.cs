using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Odbijanje : MonoBehaviour
{

    public float silaOdbijanja;


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ball" && other.relativeVelocity.sqrMagnitude > 2f)
        {
           
            other.rigidbody.AddForce(new Vector3(1, 0, 1) * silaOdbijanja, ForceMode.Impulse);
        }
        
    }
}
