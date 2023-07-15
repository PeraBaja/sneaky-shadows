using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolumeValue : MonoBehaviour
{
    [SerializeField] AudioMixerGroup audioGroup;
    public void SetVolume(float desireVolume)
    {
        audioGroup.audioMixer.SetFloat("Volume", 20 * Mathf.Log10(desireVolume));
    }
}
