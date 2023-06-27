using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWhenPlayerDies : MonoBehaviour
{
    [SerializeField] float boundsLenght;
    [SerializeField] int obstacleLayer;

    public event Action OnDie;
    private void FixedUpdate()
    {
        KillIsOutOfBounds();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == obstacleLayer)
        {
            Destroy(this.gameObject);
            OnDie?.Invoke();
        }
    }

    void KillIsOutOfBounds()
    {
        if (Mathf.Abs(this.transform.position.y) >= boundsLenght)
        {
            Debug.Log("Kill Out Of Bounds");
            Destroy(this.gameObject);
            OnDie?.Invoke();
        }
    }
}

