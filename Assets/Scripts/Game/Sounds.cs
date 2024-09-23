using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip win;   
    public AudioClip lose;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }

    public void PlaySoundWin()
    {
        PlaySound(win);
    }

    public void PlaySoundLose()
    {
        PlaySound(lose);
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
