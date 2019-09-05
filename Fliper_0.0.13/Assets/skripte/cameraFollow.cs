using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject kugla;
    public GameObject shadow;
    float brzinaPracenja = 20f;
    float trenutnaBrzinaPracenja;
    [HideInInspector] public bool GlavnaKamera = true;
    Score poveznicaNaSkor;
    float yDimenzija;
    float zDimenzija;

    private void Start()
    {
        poveznicaNaSkor = FindObjectOfType<Score>();
        yDimenzija = transform.position.y;
        zDimenzija = transform.position.z;

    }

    private void Update()
    {
        trenutnaBrzinaPracenja = Mathf.Lerp(0, brzinaPracenja, Vector3.Distance(kugla.transform.position, shadow.transform.position));
        shadow.transform.LookAt(kugla.transform.position);
        shadow.transform.Translate(transform.TransformDirection(Vector3.forward * trenutnaBrzinaPracenja * Time.deltaTime));
        shadow.transform.position = new Vector3(shadow.transform.position.x, 0.25f, shadow.transform.position.z);

        if (Input.GetKeyDown(KeyCode.C)) GlavnaKamera = !GlavnaKamera;
    }


   private void LateUpdate()
    {
        if (GlavnaKamera)
        {
            transform.position = new Vector3(transform.position.x, yDimenzija, -2.7f);
            poveznicaNaSkor.welcometextZoom.enabled = false;
            poveznicaNaSkor.welcometext.enabled = true;
        }
        if (!GlavnaKamera)
        {
            transform.position = new Vector3(transform.position.x, yDimenzija - 5f, (shadow.transform.position.z - 5f));
            poveznicaNaSkor.welcometextZoom.enabled = true;
            poveznicaNaSkor.welcometext.enabled = false;
        }
                
    }

    

}
