using UnityEngine;
using UnityEngine.UI;

public class BallRespawn : MonoBehaviour
{

    public Transform spawnPoint;
    Score poveznicaNaScore;
    public Text tekstTilt;
    int brojKugli = 1;
    public GameObject scorePanel;
    public bool ballIsOut;


    private void Start()
    {
        poveznicaNaScore = FindObjectOfType<Score>();
        scorePanel.gameObject.SetActive(false);
  
    }

    private void Update()
    {
        /*if (brojKugli > 4)
        {
            //Tekst izgubio si ili nova scena ili nesto
            //Upisivanje scora na tablu score, pokrece online spremanje skora
            Time.timeScale = 0f;
            scorePanel.gameObject.SetActive(true);
            Cursor.visible = true;
        }  */  
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            ballIsOut = true;
            other.attachedRigidbody.velocity = new Vector3(0,0,0);
            other.gameObject.transform.position = spawnPoint.transform.position;
            brojKugli++;
            poveznicaNaScore.IsTilted = false;
            tekstTilt.enabled = false;
            poveznicaNaScore.ResetiranjeKarata();
        }
    }
}
