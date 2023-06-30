using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDieAudio : MonoBehaviour
{
    [SerializeField] GameObject deathAudioSource;

    DetectWhenPlayerDies detectWhenPlayerDies;

    private void Awake()
    {
        detectWhenPlayerDies = GetComponent<DetectWhenPlayerDies>();
        detectWhenPlayerDies.OnDie += ReproduceAudioSource;
    }

    private void ReproduceAudioSource()
    {
        GameObject deathAudioSourceInstance = Instantiate(deathAudioSource);

        if(deathAudioSourceInstance.TryGetComponent(out AudioSource audioSource)) audioSource.Play();

        Destroy(deathAudioSourceInstance, 3f);

    }
}
