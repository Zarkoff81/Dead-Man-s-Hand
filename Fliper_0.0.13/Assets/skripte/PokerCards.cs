using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerCards : MonoBehaviour
{
    public Animator anim;
    PlungerNospring povezncaNaPlungerNoSpring;
    Score poveznicaNaScore;
    int iznosBodovaKarta = 3;
    int rdn;
    public GameObject scoreDisplayText;
    int i;
    BallRespawn poveznicaNaBallRespawn;

    private void Start()
    {
       // anim = GetComponent<Animator>();
        poveznicaNaScore = FindObjectOfType<Score>();
        povezncaNaPlungerNoSpring = FindObjectOfType<PlungerNospring>();
        poveznicaNaBallRespawn = FindObjectOfType<BallRespawn>();
    }


    private void Update()
    {
        if (poveznicaNaBallRespawn.ballIsOut)
        {
            anim.SetBool("igraj", true);
            Destroy(gameObject.transform.parent.gameObject, 2f);
        }
        else if (povezncaNaPlungerNoSpring.kuglaNaPlungeru) anim.SetBool("igraj", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")/* && pomocni*/)
        {
            anim.SetBool("igraj", true);

            poveznicaNaScore.skor += iznosBodovaKarta;

            GameObject klon = Instantiate(scoreDisplayText, (transform.position + new Vector3(0, 1.5f, 0)), Quaternion.identity);
            klon.gameObject.GetComponent<floatDamageTekst>().floatingTekst.text = iznosBodovaKarta.ToString("0");
            Destroy(gameObject.transform.parent.gameObject, 1f);
        }
    }

}
