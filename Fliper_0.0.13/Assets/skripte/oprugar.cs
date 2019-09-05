using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oprugar : MonoBehaviour
{
    SpringJoint opruga;
    Vector3 lokacija;
    poluga poveznicaNAPolugu;
    public Animator animacijaPoluge;

    public List<Rigidbody> popisKugli;


    private void Start()
    {
        popisKugli = new List<Rigidbody>();
        lokacija = transform.position;
        opruga = GetComponent<SpringJoint>();
        poveznicaNAPolugu = FindObjectOfType<poluga>();

    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            opruga.spring = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            opruga.spring = 10000;
        }
        else opruga.spring = 10000;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            //other.GetComponent<Rigidbody>().mass = 1f;
            //poveznicaNAPolugu.kuglaJeKodOpruge = true;
            //animacijaPoluge.Play("polugaOpen");

            
        }
            
    }
    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ball")) 
        {
            other.GetComponent<Rigidbody>().mass = 1f;
            poveznicaNAPolugu.kuglaJeKodOpruge = true;

        }

    }*/
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball")) 
        {
            //other.GetComponent<Rigidbody>().mass = 0.01f;
            //poveznicaNAPolugu.kuglaJeKodOpruge = false;

        }

    }
}
