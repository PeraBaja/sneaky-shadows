using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DetectWhenPlayerDies player))
        {
            player.OnDie?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
