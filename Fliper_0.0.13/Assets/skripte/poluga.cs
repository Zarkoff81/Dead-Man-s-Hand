using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poluga : MonoBehaviour
{
    //public bool trigr;
    //public bool kuglaJeKodOpruge;
    Animator polugaAnim;

    private void Start()
    {
        polugaAnim = GetComponent<Animator>();
    }
    /*private void Update()
    {
        if (transform.position.z <= 21 && kuglaJeKodOpruge == false && trigr == true)
        {
            transform.position += new Vector3(0, 0, 1.5f);
        }

        if (transform.position.z >= 19 && kuglaJeKodOpruge == true && trigr == false)
        
        {
            transform.position -= new Vector3(0, 0, 1.5f);
        }

        if (transform.position.z >= 21)
        {
            trigr = false;
        }


    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            trigr = true;
            kuglaJeKodOpruge = false;
        }
    }*/

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            trigr = true;
            kuglaJeKodOpruge = false;
        }

    }*/

    private void OnTriggerExit(Collider other)
    {
        polugaAnim.Play("polugaClose");
        
    }

}
