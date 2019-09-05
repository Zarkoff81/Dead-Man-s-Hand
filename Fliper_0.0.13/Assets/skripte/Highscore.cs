using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Highscore : MonoBehaviour
{
    //WEB: http://dreamlo.com/lb/Xvd-nKJCcUy31fyEPmF4tgv0oxemytIki7CAEIy6_UZQ

    //podatke za stringove se nađu na vašoj dreamlo.com stranici

    const string privateCode = "Xvd-nKJCcUy31fyEPmF4tgv0oxemytIki7CAEIy6_UZQ";

    const string publicCode = "5d63a4d4e6a81b07f003b9d9";

    const string webURL = "http://dreamlo.com/lb/"; //uvijek isto



    public InputField playerName;

    public string charName;



    public highscore[] highscoresList;

    static Highscore instance; //pristup highsocure od kud očeš

    public DisplayHighscore highscoreDisplay;



    void Awake()

    {

        instance = GetComponent<Highscore>();

        charName = PlayerPrefs.GetString("PlayerName"); //izvuće iz playerprefa ime igrača

        highscoreDisplay = GetComponent<DisplayHighscore>();

    }



    void Start()

    {

        //Ako je player prefs za ime prazan, dajemo ime igraču "Player"

        if (charName == string.Empty)

        {

            charName = "Player"/* + Random.Range(0, 100000000).ToString()*/;

        }

        //DOLJNI DIO NE TREBA JER SMO TO NAPRAVILI U AWAKEU

        //else

        //{

        //    charName = PlayerPrefs.GetString("PlayerName");

        //}

    }



    public void ChangeDataByMe()

    {

        charName = playerName.text;

        PlayerPrefs.SetString("PlayerName", charName);

        int scorerer = PlayerPrefs.GetInt("PlayerHighestScore");

        AddNewHighscore(charName, scorerer);

        Debug.Log(scorerer);
    }



    public static void AddNewHighscore(string username, int score)

    {

        instance.StartCoroutine(instance.UploadNewHighscore(username, score));

    }



    IEnumerator UploadNewHighscore(string username, int score)

    {

        UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);

        yield return www.SendWebRequest();



        if (string.IsNullOrEmpty(www.error))

        {

            Debug.Log("Upload successful!");

            DownloadHighscores();

        }

        else

        {

            Debug.Log("Error uploading: " + www.error);

        }

    }



    public void DownloadHighscores()

    {

        StartCoroutine(DownloadHighscoreFromDatabase());

    }



    public IEnumerator DownloadHighscoreFromDatabase()

    {

        UnityWebRequest www = new UnityWebRequest(webURL + publicCode + "/pipe/");

        DownloadHandlerBuffer dh = new DownloadHandlerBuffer();



        www.downloadHandler = dh;



        yield return www.SendWebRequest();



        if (string.IsNullOrEmpty(www.error))

        {

            Debug.Log("Download successful!");

            Debug.Log(www.downloadHandler.text);

            FormatHighScores(www.downloadHandler.text);

            highscoreDisplay.OnHighscoreDownload(highscoresList);

        }

        else

        {

            Debug.Log("Error downloading: " + www.error);

        }



    }



    void FormatHighScores(string textStream)

    {

        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        highscoresList = new highscore[entries.Length];



        for (int i = 0; i < entries.Length; i++)

        {

            string[] entryInfo = entries[i].Split(new char[] { '|' });

            string username = entryInfo[0];

            int score = int.Parse(entryInfo[1]);

            highscoresList[i] = new highscore(username, score);

        }

    }

}



public struct highscore

{

    public string username;

    public int score;



    public highscore(string username, int score)

    {

        this.username = username;

        this.score = score;



        score = PlayerPrefs.GetInt("PlayerHighestScore");

    }
}
