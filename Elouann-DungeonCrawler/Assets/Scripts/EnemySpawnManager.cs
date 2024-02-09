using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public List<EnemySpawner> EnemySpawners;
    [SerializeField]
    private int _numberToSpawn;
    [SerializeField]
    private float _delayBetweenSpawn;
    private int _randomSpawner = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        if (EnemySpawners != null)
        {
            for (int i = 0; i < _numberToSpawn; i++)
            {
                yield return new WaitForSeconds(_delayBetweenSpawn);
                _randomSpawner = Random.Range(0, EnemySpawners.Count);
                EnemySpawners[_randomSpawner].SpawnEnemy(1);
            }

            EnemySpawners[_randomSpawner].SpawnEnemy(0);
        }
        else
        {
            Debug.LogError("La liste de spawner est vide");
        }
    }
}
