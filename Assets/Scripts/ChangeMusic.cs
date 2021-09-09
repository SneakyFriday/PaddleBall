using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip playerWinSound, aiWinSound;
    private AudioSource _audioSource1;

    void Start()
    {
        _audioSource1 = GetComponent<AudioSource>();
        
        // playerWinSound = (AudioClip)Resources.Load("victorySound");
        // aiWinSound = (AudioClip)Resources.Load("gameOverSound");
    }

    public void PlayPlayerWinSound()
    {
        _audioSource1.clip = playerWinSound;
        _audioSource1.volume = 0.2f;
        _audioSource1.Play();
        Debug.Log("PlayerWinMusic");
    }

    public void PlayAIWinSound()
    {
        _audioSource1.clip = aiWinSound;
        _audioSource1.volume = 0.2f;
        _audioSource1.Play();
        Debug.Log("AIWinMusic");
    }
}
