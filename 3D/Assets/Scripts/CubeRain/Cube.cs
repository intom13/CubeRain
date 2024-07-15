using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CubeColorChanger))]
public class Cube : MonoBehaviour
{
    private readonly float _minLifeTime = 2f;
    private readonly float _maxLifeTime = 5f;
    private readonly float _second = 1f;

    private int _touchesCount = 0;

    private WaitForSeconds _oneSecond;

    private CubeColorChanger _cubeColorChanger;

    private void Start()
    {
        _cubeColorChanger = GetComponent<CubeColorChanger>();

        _oneSecond = new WaitForSeconds(_second);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Plate plate))
        {
            if(_touchesCount == 0)
            {
                _cubeColorChanger.ChangeColor();

                StartCoroutine(LifeCycle());
            }

            _touchesCount++;
        }
    }

    private IEnumerator LifeCycle()
    {
        for (int i=0; i < DefineLifeTime(); i++)
        {
            yield return _oneSecond;
        }

        RemoveCube();
    }

    private float DefineLifeTime()
    {
        return Random.Range(_minLifeTime, _maxLifeTime); ;
    }

    private void RemoveCube()
    {
        gameObject.SetActive(false);

        _touchesCount = 0;
    }
}
