using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnPointSO", menuName = "SpawnPoint")]
public class SpawnPointData : ScriptableObject
{
    public Vector2 CurrentSpawnPosition;
}
