using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScore : MonoBehaviour
{
    public GameObject scoreDisplayText;
    Score poveznicaNaScore;
    int iznosBodova = 1;
    public GameObject gljiva;
    public Animator anim;
    //AudioSource zvuk;

    private void Start()
    {
        poveznicaNaScore = FindObjectOfType<Score>();
        //zvuk = GetComponent<AudioSource>();
    }

    void Pauza()
    {
        anim.SetBool("igraj", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            gljiva.transform.parent.transform.Rotate(0, Random.Range(-360, 360), 0);
            poveznicaNaScore.skor += iznosBodova;
            GameObject klon = Instantiate(scoreDisplayText, (transform.position + new Vector3(0, 1.5f, 0)), Quaternion.identity);
            klon.gameObject.GetComponent<floatDamageTekst>().floatingTekst.text = iznosBodova.ToString("0");
            anim.SetBool("igraj", true);
            Invoke("Pauza", 0.2f);
            //zvuk.Play();
        }
    }


}
