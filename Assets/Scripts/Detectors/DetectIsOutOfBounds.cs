using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectIsOutOfBounds : MonoBehaviour
{
    DetectWhenPlayerDies player;
    [SerializeField] float boundsLenght;

    private void Awake()
    {
        player = GetComponent<DetectWhenPlayerDies>();
    }
    private void Update()
    {
        if(Mathf.Abs(transform.position.y) >= boundsLenght)
        {
            player.OnDie?.Invoke();
            Destroy(player.gameObject);
        }
    }
}
