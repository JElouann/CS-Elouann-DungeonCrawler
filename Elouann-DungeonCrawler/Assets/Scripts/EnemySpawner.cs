using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemySpawnManager _spawnManager;
    [SerializeField]
    private List<SO_Enemies> _enemies;

    public void SpawnEnemy(int enemyIndex)
    {
        Instantiate(_enemies[enemyIndex].EnemyPrefab, this.transform);
    }
}
