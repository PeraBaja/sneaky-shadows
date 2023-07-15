using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSettingsMenu : MonoBehaviour
{
    [SerializeField] OpenSettingsMenu settingsButton;

    CloseSettingsMenu closeSettingsMenu;
    Animator SettingMenuAnimator;
    void Awake()
    {
        closeSettingsMenu = GetComponentInChildren<CloseSettingsMenu>();
        SettingMenuAnimator = GetComponent<Animator>();
        settingsButton.OnPulse += Show; 
        closeSettingsMenu.OnClose += Hide;
    }
    void Show()
    {
        SettingMenuAnimator.SetBool("IsShowing", true);
    }
    void Hide()
    {
        SettingMenuAnimator.SetBool("IsShowing", false);
    }
}
