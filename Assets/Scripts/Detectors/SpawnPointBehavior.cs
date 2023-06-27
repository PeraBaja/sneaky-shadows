using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnPointBehavior : MonoBehaviour
{
    [SerializeField] SpawnPointData spawnPointData;
    [SerializeField] GameObject player;
    [SerializeField] int maxSouls;

    AudioSource audioSourceRevive;
    GameObject playerInstance;
    int soulCounter = 0;

    private void Awake()
    {
        audioSourceRevive = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == player.layer)
        {
            spawnPointData.CurrentSpawnPosition = transform.position;
        }
        if (collider.gameObject.TryGetComponent(out PlayerSoulBehaviour soul))
        {
            soulCounter++;
            Destroy(collider.gameObject);
        }
        if (soulCounter >= maxSouls)
        {
            if (playerInstance != null) return;
            InstantiatePlayer();
        }
    }    
    void InstantiatePlayer()
    {
        audioSourceRevive.Play();
        playerInstance = Instantiate(player, spawnPointData.CurrentSpawnPosition, Quaternion.identity);
        soulCounter = 0;
    }
}
