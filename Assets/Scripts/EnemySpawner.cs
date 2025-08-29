using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private Coroutine _coroutine;
    private bool _isSpawnerEnabled = true;

    private void Start()
    {
        StartEnemiesSpawnCount();
    }

    private void SpawnEnemy()
    {
        int randomNumberSpawnPoint = Random.Range(0, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[randomNumberSpawnPoint].transform;

        Enemy enemy = Instantiate(_enemy, spawnPoint.position, Quaternion.identity);
        enemy.Init(_spawnPoints[randomNumberSpawnPoint].Target);
    }

    private void StartEnemiesSpawnCount()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountEnemiesSpawn());
    }

    private IEnumerator CountEnemiesSpawn()
    {
        var wait = new WaitForSeconds(_spawnInterval);

        while (_isSpawnerEnabled)
        {
            yield return wait;
            SpawnEnemy();
        }
    }
}
