using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform _collectable;

    [SerializeField]
    private float _spawnTime = 5.0f;
    private float _timer = 0.0f;

    public float SpawnTime
    {
        get { return _spawnTime; }
        set { _spawnTime = value; }
    }

    private void Update()
    {
        if (_timer >= SpawnTime)
        {
            Transform spawnedCollectable = Instantiate(_collectable, transform.position, transform.rotation);
            _timer = 0.0f;
        }

        _timer += Time.deltaTime;
    }
}
