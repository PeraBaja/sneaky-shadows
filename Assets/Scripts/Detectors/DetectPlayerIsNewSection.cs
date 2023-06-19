using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerIsNewSection : MonoBehaviour
{
    [SerializeField] string currentSectionName;

    BoxCollider2D areaDetector;

    private void Awake()
    {
        areaDetector = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<DetectWhenPlayerDies>(out DetectWhenPlayerDies player)) 
        {
            EventManager.OnPlayerIsNewSection?.Invoke(currentSectionName);
            areaDetector.enabled = false;
        }
        
    }
}
