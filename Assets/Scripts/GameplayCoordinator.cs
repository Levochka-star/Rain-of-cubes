using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCoordinator : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private SphereSpawner _sphereSpawner;
    [SerializeField] private StatsViewer _cubeViewer;
    [SerializeField] private StatsViewer _sphereViewer;

    [SerializeField] private Detonator _detonator;

    private void Start()
    {
        SetStatsCube();
        SetStatsSphere();

        _cubeSpawner.Work();
    }

    private void OnEnable()
    {
        _cubeSpawner.ObjectRelised += StartSpawnSphere;
        _cubeSpawner.StatsObjectChanged += SetStatsCube;

        _sphereSpawner.ObjectRelised += StartExplosing;
        _sphereSpawner.StatsObjectChanged += SetStatsSphere;
    }

    private void OnDisable()
    {
        _cubeSpawner.ObjectRelised -= StartSpawnSphere;
        _cubeSpawner.StatsObjectChanged -= SetStatsCube;

        _sphereSpawner.ObjectRelised -= StartExplosing;
        _sphereSpawner.StatsObjectChanged -= SetStatsSphere;
    }

    private void StartSpawnSphere(Vector3 position)
    {
        _sphereSpawner.Work(position);
    }

    private void StartExplosing(Vector3 position)
    {
        _detonator.Work(position);
    }

    private void SetStatsCube()
    {
        _cubeViewer.Write(_cubeSpawner.ValueSpawnedObjects, _cubeSpawner.ValueCreatedObjects, _cubeSpawner.ValueActivedObjects);
    }

    private void SetStatsSphere()
    {
        _sphereViewer.Write(_sphereSpawner.ValueSpawnedObjects, _sphereSpawner.ValueCreatedObjects, _sphereSpawner.ValueActivedObjects);
    }
}
