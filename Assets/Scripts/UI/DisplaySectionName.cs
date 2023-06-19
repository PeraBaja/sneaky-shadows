using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySectionName : MonoBehaviour
{
    Animation displayAnimation;
    TextMeshProUGUI sectionText;

    private void Awake()
    {
        EventManager.OnPlayerIsNewSection += Display;
        displayAnimation = GetComponent<Animation>();
        sectionText = GetComponent<TextMeshProUGUI>();
    }
    void Display(string sectionName)
    {
        Debug.Log("display");
        sectionText.text = sectionName;
        displayAnimation.Play();
    }
    private void OnDestroy()
    {
        EventManager.OnPlayerIsNewSection -= Display;
    }
}
