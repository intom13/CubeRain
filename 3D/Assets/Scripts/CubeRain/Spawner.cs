using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private CubePool _cubePool;

    [SerializeField] private List<Transform> _spawnPoints;

    private readonly int _minRandomValue = 0;

    private WaitForSeconds _spawnerTimeout;

    private void Start()
    {
        _spawnerTimeout = new WaitForSeconds(_timeBetweenSpawn);

        StartCoroutine(SpawnCycle());
    }

    private IEnumerator SpawnCycle()
    {
        while (true)
        {
            LocateObject(GetRandomSpawnPoint(), _cubePool.GetObject());

            yield return _spawnerTimeout;
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(_minRandomValue, _spawnPoints.Count)];
    }

    private void LocateObject(Transform spawnPointTransform, GameObject newCube)
    {
        newCube.transform.position = spawnPointTransform.position;

        newCube.SetActive(true);
    }
}
