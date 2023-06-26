using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEasterEgg : MonoBehaviour
{
    void Awake()
    {
        EventManager.OnPlayerActivateEasterEgg += Activate;
    }

    private void Activate()
    {
        this.gameObject.SetActive(true);
    }
}
