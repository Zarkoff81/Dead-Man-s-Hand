using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXAudioManager : MonoBehaviour
{
    public AudioSource FXaudioSource;

    public AudioClip choochoo;
    public AudioClip gunCock;
    public AudioClip tiltSound;
    public AudioClip tilHit;

    public AudioClip[] gunShots;

    private void Start()
    {
        FXaudioSource = GetComponent<AudioSource>();

    }


}
