using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource;

    public AudioClip explosion1;
    public AudioClip explosion2;
    public AudioClip gun;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        if(clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
