using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floatDamageTekst : MonoBehaviour
{

    Animator anim;
    public Text floatingTekst;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        Destroy(this.gameObject, 0.67f);
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }

    void CitanjeDamage_a()
    {
       // floatingTekst.text = poveznicaNaEnemyHealth.damageTaken.ToString();

    }

}
