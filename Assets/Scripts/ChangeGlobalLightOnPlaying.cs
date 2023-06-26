using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChangeGlobalLightOnPlaying : MonoBehaviour
{
    Light2D light2D;
    void Start()
    {
        light2D = GetComponent<Light2D>();
        light2D.intensity = 0.7f;
    }
}
