using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerNospring : MonoBehaviour
{
    float sila;
    float povlacenje = 0.01f;
    float pocetniZ;
    public bool kuglaNaPlungeru = false;
    BallRespawn ballRespawn;
    
    Rigidbody ballRb;

    public Animator animacijaPoluge;

    private void Start()
    {
        ballRespawn = FindObjectOfType<BallRespawn>();
        pocetniZ = transform.position.z;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ball")
        {
           ballRb = other.attachedRigidbody;
            kuglaNaPlungeru = true;
            animacijaPoluge.Play("polugaOpen");
            ballRespawn.ballIsOut = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Ball")
        {
            
            kuglaNaPlungeru = false;

        }
    }


    private void Update()

    {

        if (Input.GetKey(KeyCode.Space) && kuglaNaPlungeru == true  && transform.position.z > pocetniZ - 0.4f)
        {
            sila += 0.1f;
            transform.position -= Vector3.forward * povlacenje;
            
        }
        if (Input.GetKeyUp(KeyCode.Space) && kuglaNaPlungeru == true)
        {
            StartCoroutine("Plunge");

        }

    }


       private IEnumerator Plunge()

        {
            while (transform.position.z < pocetniZ)
            {
                transform.position += Vector3.forward * sila;
                
        }
            if (transform.position.z >= pocetniZ)
            {
                ballRb.AddForce(Vector3.forward * sila, ForceMode.Impulse);
                transform.position = new Vector3(transform.position.x, transform.position.y, pocetniZ);
                sila = 0f;
            }
            yield return null;
        }
    }

