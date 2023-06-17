using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerSoulBehaviour : MonoBehaviour
{
    [SerializeField] SpawnPointData spawnPointData;
    new Rigidbody2D rigidbody2D;
    Vector2 randomForce;
    
    int randomSpeed;
    private void Awake()
    {
        randomForce = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        randomSpeed = Random.Range(40, 50);
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private async void Start()
    {
        SparceSoul();
        await Task.Delay(1200);
        InvokeRepeating("GoToSpawn", 0f, 1f);
    }
    void GoToSpawn()
    {
        Vector2 targetDirection = (spawnPointData.CurrentSpawnPosition - (Vector2)transform.position).normalized;
        rigidbody2D.velocity = targetDirection * randomSpeed;
    }
    void SparceSoul()
    {
        rigidbody2D.AddForce(randomForce, ForceMode2D.Impulse);
    }
}
