using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerNearbyMaximunSoul : MonoBehaviour
{
    public event Action isInTheArea;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DetectWhenPlayerDies player))
        {
            isInTheArea?.Invoke();
        }
    }
}
