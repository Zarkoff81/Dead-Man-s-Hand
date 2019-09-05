using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [HideInInspector] public int skor;
    [HideInInspector] public float highskor;
    public Text scoreText;

    PlungerNospring poveznicaNaplungerNoSpring;

    public Text welcometext;
    public Text welcometextZoom;
    [HideInInspector] public bool IsTilted;

    public List<GameObject> karteUSpilu; // spil broj 1, u njemu je sve i ne mijenja se
    public List<GameObject> lokacijeKarata; // spil broj 1, u njemu je sve i ne mijenja se
    [Header("Buffer liste")]
    public List<GameObject> trenutniSpil; // spil broj 2, iz njega vadi elemente za stol
    public List<GameObject> spawnPozicijaZaKarte; // spil broj 2, iz njega vadi elemente za stol
    [Header("Dump liste")]
    public List<GameObject> karteDump; // spil broj 3, na stolu
    public List<GameObject> spawnPozicijaZaKarteDump; // spil broj 3, na stolu




    private void Start()
    {
        poveznicaNaplungerNoSpring = FindObjectOfType<PlungerNospring>();
        welcometextZoom.enabled = false;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        PostavljanjeKarataNaStol();

    }

    /*private void Update()
    {
            if (Input.GetKeyDown("escape")) Cursor.lockState = CursorLockMode.None;
            if (Input.anyKeyDown) Cursor.lockState = CursorLockMode.Locked;
    }*/

    void BiranjeKarata()
    {
        for (int i = 0; i < karteUSpilu.Count; i++)
        {
            trenutniSpil.Add(karteUSpilu[i]);
        }
        for (int i = 0; i < lokacijeKarata.Count; i++)
        {
            spawnPozicijaZaKarte.Add(lokacijeKarata[i]);
        }
    }

    public void PostavljanjeKarataNaStol()
    {
        BiranjeKarata();

        for (int j = 0; j < spawnPozicijaZaKarte.Count; j++)
        {
            for (int i = 0; i < trenutniSpil.Count; i++)
            {
                int rdn = Random.Range(0, trenutniSpil.Count);
                GameObject kartaKlon = Instantiate(trenutniSpil[rdn], spawnPozicijaZaKarte[j].transform.position, spawnPozicijaZaKarte[j].transform.rotation);

                karteDump.Add(trenutniSpil[rdn]);
                trenutniSpil.Remove(trenutniSpil[rdn]);

                spawnPozicijaZaKarteDump.Add(spawnPozicijaZaKarte[j]);
                spawnPozicijaZaKarte.Remove(spawnPozicijaZaKarte[j]);

            }
        }


    }

    public void ResetiranjeKarata()
    {
        karteDump.Clear();
        spawnPozicijaZaKarteDump.Clear();
        trenutniSpil.Clear();

       
    }

    private void LateUpdate()
    {
        scoreText.text = "Score: " + skor.ToString();
        PlayerPrefs.SetInt("PlayerHighestScore", skor);

        if (IsTilted) skor = 0;
        if (highskor < skor) highskor = skor;

        //if (highskor > 4)
        //{
        //    highskortekst.enabled = true;
        //    highskortekst.text = "Best score this game: " + highskor.ToString();
        //}

        welcometext.text = "Press 'LEFT CONTROL' or 'RIGHT CONTROL' for flippers, 'RETURN' to spawn more balls and hold 'SPACE' to launch the ball. If you lose the ball score resets. 'C' changes camera, try it out.";
        welcometextZoom.text = "Press 'C' to change camera.";
    }

}
