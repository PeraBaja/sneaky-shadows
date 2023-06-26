using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToObliterateSound : MonoBehaviour
{
    [SerializeField] AudioClip obliterateAudio;
    AudioSource audioManager;
    private void Awake()
    {
        EventManager.OnObliterateMaxSoul += ChangeClipAudio;
        audioManager = GetComponent<AudioSource>();
    }

    private void ChangeClipAudio()
    {
        audioManager.clip = obliterateAudio;
        audioManager.loop = false;
        audioManager.Play();
    }
}
