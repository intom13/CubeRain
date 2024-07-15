using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _startPoolSize;

    private Transform _transform;

    private readonly List<GameObject> _cubePool = new List<GameObject>();

    private void Start()
    {
        _transform = GetComponent<Transform>();

        for (int i = 0; i < _startPoolSize; i++)
        {
            AddObjectToPool();
        }
    }

    public GameObject GetObject()
    {
        foreach (var cube in _cubePool)
        {
            if (cube.activeSelf == false)
                return cube;
        }
        return AddObjectToPool();
    }

    private GameObject AddObjectToPool()
    {
        Cube newCube = Instantiate(_prefab, _transform);

        newCube.gameObject.SetActive(false);
        _cubePool.Add(newCube.gameObject);

        return newCube.gameObject;
    }
}
