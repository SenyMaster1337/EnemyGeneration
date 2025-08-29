using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Vector3 _movementDirection;

    private Coroutine _coroutine;
    private bool _isSpawnerEnabled = true;
    private float _rotationX = 0f;
    private float _rotationZ = 0f;

    private void Start()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            Debug.Log(spawnPoint.position);
        }

        StartEnemiesSpawnCount();
    }

    private void SpawnEnemy()
    {
        Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        float randomRotationY = Random.Range(0f, 360f);

        Enemy enemy = Instantiate(_enemy, randomSpawnPoint.position, Quaternion.Euler(_rotationX, randomRotationY, _rotationZ));
        enemy.Init(_movementDirection);
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
