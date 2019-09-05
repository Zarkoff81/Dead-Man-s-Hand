using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTesting : MonoBehaviour
{
    public GameObject kugla;
    public Transform spawnPoint;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) == true)
        {
            GameObject kuglaKlon;
            Vector3 pozicija = spawnPoint.transform.position + new Vector3(Random.Range(0, 2), 0, Random.Range(0, 2));
            kuglaKlon = Instantiate(kugla, pozicija, Quaternion.identity);
        }
    }

    //private void OnDestroy()
    //{
    //    GameObject kuglaKlon;
    //    Vector3 pozicija = spawnPoint.transform.position + new Vector3(Random.Range(0, 2), 0, Random.Range(0, 2));
    //    kuglaKlon = Instantiate(kugla, pozicija, Quaternion.identity);

    //}

}
