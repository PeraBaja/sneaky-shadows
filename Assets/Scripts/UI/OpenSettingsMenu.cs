using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingsMenu : InteractButton
{
    public event Action OnPulse;
    protected override void Interact()
    {
        OnPulse?.Invoke();
    }
}
