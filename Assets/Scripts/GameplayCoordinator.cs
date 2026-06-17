using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCoordinator : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private SphereSpawner _sphereSpawner;
    [SerializeField] private Detonator _detonator;

    private void Start()
    {
        _cubeSpawner.Work();
    }

    private void OnEnable()
    {
        _cubeSpawner.ObjectRelised += StartSpawnSphere;
        _sphereSpawner.ObjectRelised += StartExplosing;
    }

    private void OnDisable()
    {
        _cubeSpawner.ObjectRelised -= StartSpawnSphere;
        _sphereSpawner.ObjectRelised -= StartExplosing;
    }

    private void StartSpawnSphere(Vector3 position)
    {
        _sphereSpawner.Work(position);
    }

    private void StartExplosing(Vector3 position)
    {
        _detonator.Work(position);
    }
}
