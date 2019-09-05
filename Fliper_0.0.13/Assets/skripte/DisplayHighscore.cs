using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    public Text[] highscoresTexts; //Prikazivanje u svakom tekstu jedan rezultat

    public Text myHighscore;

    Highscore highscoreManager;



    void Start()

    {

        for (int i = 0; i < highscoresTexts.Length; i++)

        {

            highscoresTexts[i].text = i + 1 + ". Loading...";

        }



        highscoreManager = GetComponent<Highscore>();



        StartCoroutine(RefreshHighscore());

    }



    public void OnHighscoreDownload(highscore[] highscoresList)

    {

        for (int i = 0; i < highscoresTexts.Length; i++)

        {

            highscoresTexts[i].text = i + 1 + ". ";

            if (highscoresList.Length > 1)

            {

                highscoresTexts[i].text += highscoresList[i].username + " - " + highscoresList[i].score + " km";

            }

        }

        myHighscore.text = highscoreManager.charName + " - " + PlayerPrefs.GetInt("PlayerHighestScore") + " km";

    }



    IEnumerator RefreshHighscore()

    {

        while (true)

        {

            highscoreManager.DownloadHighscores();

            yield return new WaitForSeconds(30);

        }

    }
}
