using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip generalMusic;
    public AudioClip saloonMusic;
    public AudioClip deadManMusic;
    public AudioClip klondikeMusic;
    public AudioClip bankMusic;
    public AudioClip jailMusic;

    float musicLevel;

    BallAudio ballAudio;
    

    private void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat("musicLevel", 0.5f);
        musicSource.loop = true;
        musicSource.clip = generalMusic;
        musicSource.Play();
        ballAudio = FindObjectOfType<BallAudio>();
    }

    private void Update()
    {
        if (musicSource.isPlaying == false)
        {
            musicSource.clip = generalMusic;
            musicSource.Play();
            ballAudio.missionMusicIsPlaying = false;
        }
    }





}
