using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamper : MonoBehaviour
{
    Rigidbody rb;
    float fakeGrav;
    public float gravSila;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        fakeGrav = gravSila;
    }

    private void Update()
    {
        rb.AddForce(Vector3.down * fakeGrav);
    }

    private void OnCollisionEnter(Collision other)
    {
        fakeGrav = 0f;
    }

    private void OnCollisionExit(Collision other)
    {
        fakeGrav = gravSila;
    }
}
