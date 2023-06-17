using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingsMenu : InteractButton
{
    public event Action OnPlayerPulseSettingButton;
    protected override void Interact()
    {
        OnPlayerPulseSettingButton?.Invoke();
    }
}
