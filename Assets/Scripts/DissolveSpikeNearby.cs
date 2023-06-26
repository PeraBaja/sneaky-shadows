using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSpikeNearby : MonoBehaviour
{
    [SerializeField] Material spikeMaterial;
    [SerializeField] float scale;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out DetectWhenPlayerDies player))
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            Debug.Log("Fade: " + distanceToPlayer);
            spikeMaterial.SetFloat("_Fade", distanceToPlayer / scale);
        }
    }
}
