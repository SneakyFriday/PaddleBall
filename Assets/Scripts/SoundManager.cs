using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public AudioMixer audioMixer;
    private static SoundManager _soundManagerInstance;
    // Needs to add a AudioSource on the AudioManager!

    private void Awake()
    {
        // Checks if there is a SoundManager
        // If so, it destroys the new gameObject
        if (_soundManagerInstance == null)
        {
            _soundManagerInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
          Destroy(gameObject);  
        }
    }

    private void Start()
    {
        // _audioSource = GetComponent<AudioSource>();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
