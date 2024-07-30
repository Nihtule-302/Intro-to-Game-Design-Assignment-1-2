using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource SFXSource;
    public AudioSource movementSource;

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip laughing;
    public AudioClip LoadingGun;
    public AudioClip moving;

    public bool playerIsMoving = false;

    void Start()
    {
        movementSource.clip = moving;

        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) 
    {
        SFXSource.clip = clip;
        SFXSource.Play();
    }

    void Update()
    {
        if (playerIsMoving && !movementSource.isPlaying)
        {
            movementSource.clip = moving;
            movementSource.Play();
        }
        else if (!playerIsMoving && movementSource.isPlaying)
        {
            movementSource.Stop();
        }
    }

}
