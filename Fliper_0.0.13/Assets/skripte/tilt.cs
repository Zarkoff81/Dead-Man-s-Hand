using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tilt : MonoBehaviour
{
    Rigidbody rb;
    public float silaTilt = 150f;
    float brojTilta;
    public Text tekstTilt;
    Score poveznicaNaScore;
    PlungerNospring plungerNoSpring;
    //poluga poveznicaNAPolugu;
    FXAudioManager FXaudioManager;
    Camera cam;
    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tekstTilt.enabled = false;
        poveznicaNaScore = FindObjectOfType<Score>();
        //poveznicaNAPolugu = FindObjectOfType<poluga>();
        plungerNoSpring = FindObjectOfType<PlungerNospring>();
        FXaudioManager = FindObjectOfType<FXAudioManager>();
        cam = FindObjectOfType<Camera>();
        
    }

    private void Update()
    {
        //print(brojTilta);
        if (brojTilta > 0) brojTilta -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.H) && !plungerNoSpring.kuglaNaPlungeru)
        {
            Vector3 origcamPos = cam.transform.position;
            brojTilta++;
            rb.AddForce(Random.Range(-silaTilt, silaTilt) * Time.deltaTime, 0, silaTilt * 2 * Time.deltaTime, ForceMode.Impulse);
            FXaudioManager.FXaudioSource.pitch = Random.Range(0.7f, 1.3f);
            FXaudioManager.FXaudioSource.PlayOneShot(FXaudioManager.tilHit);
            
            StartCoroutine("CamShake");

            
        }

        if ((brojTilta + Random.Range(0, 1)) > 5)
        {
            tekstTilt.enabled = true;
            tekstTilt.text = "TILT!";
            poveznicaNaScore.IsTilted = true;
            brojTilta = 0;
            FXaudioManager.FXaudioSource.pitch = 1;
            FXaudioManager.FXaudioSource.PlayOneShot(FXaudioManager.tiltSound);

        }
    }

    private IEnumerator CamShake()
    {
        float shakeDuration = 0.2f;
        Vector3 origcamPos = cam.transform.position;
        
        while (shakeDuration > 0)
        {
            cam.transform.position = origcamPos + Random.insideUnitSphere * 0.3f;
            shakeDuration -= Time.deltaTime;
            
            yield return null;
        }
        
        
       
              
        
    }
       

    }


