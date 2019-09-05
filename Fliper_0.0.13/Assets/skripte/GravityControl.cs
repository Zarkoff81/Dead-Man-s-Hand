using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour

   
{

    public float faktorUbrzanja;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ball")
        {
            other.attachedRigidbody.useGravity = false;
           // other.attachedRigidbody.velocity.normalized * faktorUbrzanja;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Ball")
        {
            other.attachedRigidbody.useGravity = true;
        }
    }

}
