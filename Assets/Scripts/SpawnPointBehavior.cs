using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnPointBehavior : MonoBehaviour
{
    [SerializeField] SpawnPointData spawnPointData;
    [SerializeField] GameObject player;
    [SerializeField] int maxSouls;
    int soulCounter = 0;
    private async void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == player.layer) 
        {
            spawnPointData.CurrentSpawnPosition = transform.position;
        }
        if (collider.gameObject.TryGetComponent(out PlayerSoulBehaviour soul))
        {
            soulCounter++;
            Debug.Log("SoulCounter: " + soulCounter);
            Destroy(collider.gameObject);
        }

        if (soulCounter >= maxSouls)
        {
            
            Instantiate(player, spawnPointData.CurrentSpawnPosition, Quaternion.identity);
            soulCounter = 0;
        }

    }
}
