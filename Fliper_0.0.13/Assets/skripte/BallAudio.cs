using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour
{
    AudioManager audioManager;
    MusicManager musicManager;
    FXAudioManager fxaudioManager;
    Rigidbody rb;
    //public AudioClip[] rollClips;
    AudioSource ballAudioSource;
    public bool missionMusicIsPlaying = false;
    

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        musicManager = FindObjectOfType<MusicManager>();
        fxaudioManager = FindObjectOfType<FXAudioManager>();
        rb = GetComponent<Rigidbody>();
        ballAudioSource = GetComponent<AudioSource>();
        ballAudioSource.volume = 0f;
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bumper")
        {
            audioManager.mainAudioSource.PlayOneShot(audioManager.bumper);
            fxaudioManager.FXaudioSource.PlayOneShot(fxaudioManager.gunShots[Random.Range(0, fxaudioManager.gunShots.Length)]);
        }
        else if (other.tag == "Saloon" && missionMusicIsPlaying == false)
        {
            musicManager.musicSource.Stop();
            musicManager.musicSource.PlayOneShot(musicManager.saloonMusic);
            missionMusicIsPlaying = true;
        }
        else if (other.tag == "choochoo")
        {
            fxaudioManager.FXaudioSource.PlayOneShot(fxaudioManager.choochoo);
        }
        else if (other.tag == "Banka" && missionMusicIsPlaying == false)
        {
            musicManager.musicSource.Stop();
            musicManager.musicSource.PlayOneShot(musicManager.bankMusic);
            missionMusicIsPlaying = true;
            fxaudioManager.FXaudioSource.PlayOneShot(fxaudioManager.gunCock);
        }
        else if (other.tag == "izbacivac")
        {
            audioManager.mainAudioSource.PlayOneShot(audioManager.izbacivac, 0.4f);
        }
        else if (other.tag == "Jail" && missionMusicIsPlaying == false)
        {
            musicManager.musicSource.Stop();
            musicManager.musicSource.PlayOneShot(musicManager.jailMusic);
            missionMusicIsPlaying = true;
        }



        }
    void FixedUpdate()
    {

        ballAudioSource.volume = Vector3.SqrMagnitude(rb.velocity) * 0.009f;  // glasnoća rolanja ovisno o brzini kugle
        //Debug.Log(Vector3.SqrMagnitude(rb.velocity) * 0.005f);

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "env")
        {
            audioManager.mainAudioSource.volume = collision.relativeVelocity.sqrMagnitude * 0.01f;
            audioManager.mainAudioSource.pitch = Random.Range(0.8f, 1.2f);
            audioManager.mainAudioSource.PlayOneShot(audioManager.ballSounds[0]);
        }
        else if (collision.transform.tag == "paddle")
        {
            
            audioManager.mainAudioSource.volume = collision.relativeVelocity.sqrMagnitude * 0.01f;
            audioManager.mainAudioSource.PlayOneShot(audioManager.ballSounds[1]);
        }
        else if (collision.transform.tag == "odbijac")
        {
            
            audioManager.mainAudioSource.PlayOneShot(audioManager.odbijac, 0.3f);
        }


    }


}
