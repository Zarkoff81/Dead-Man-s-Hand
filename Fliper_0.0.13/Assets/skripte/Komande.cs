using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Komande : MonoBehaviour
{

    public float donjaPozicija;
    public float gornjaPozicija = 45f;
    public float snaga;
    public float ublazivach; 
    public string kontrole;
    HingeJoint zglob;
    Score poveznicaNaScore;


    private void Start()
    {
        zglob = GetComponent<HingeJoint>();
        zglob.useSpring = true;
        poveznicaNaScore = FindObjectOfType<Score>();

    }


    private void Update()
    {

        JointSpring opruga = new JointSpring();
        opruga.spring = snaga;
        opruga.damper = ublazivach;

        if (!poveznicaNaScore.IsTilted)
        {
            if (Input.GetAxis(kontrole) == 1) opruga.targetPosition = gornjaPozicija;
            else opruga.targetPosition = donjaPozicija;
        }

        zglob.spring = opruga;
        zglob.useLimits = true;

    }

}
