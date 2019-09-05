using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource mainAudioSource;
    
    public AudioClip plungerWind;
    public AudioClip plungerRelease;
    public AudioClip paddles;
    public AudioClip bumper;
    public AudioClip odbijac;
    public AudioClip [] ballSounds;
    public AudioClip [] speech;
    public AudioClip izbacivac;

    private void Start()
    {
        mainAudioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))

        {
            mainAudioSource.PlayOneShot(paddles);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainAudioSource.PlayOneShot(plungerWind);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            mainAudioSource.Stop();
            mainAudioSource.PlayOneShot(plungerRelease);
        }
       

    }
}
