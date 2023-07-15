using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettingsMenu : MonoBehaviour
{
    public event Action OnClose; 
    public void Close()
    {
        OnClose?.Invoke();
    }
}
