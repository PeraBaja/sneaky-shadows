using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ActivateEasterEgg : MonoBehaviour
{
    [SerializeField] GameObject EasterEgg;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DetectWhenPlayerDies player))
        {
            EasterEgg.SetActive(true);
            EventManager.OnPlayerActivateEasterEgg?.Invoke();
        }
    }
}
