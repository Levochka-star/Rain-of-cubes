using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    private ObjectPool<GameObject> _poll;

    private void Start()
    {

    }

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        Cube clone = Instantiate(_prefab, GenerateRandomVector3(), _prefab.transform.rotation);
    }

    private Vector3 GenerateRandomVector3()
    {
        var nextTransform = transform.position;

        nextTransform.x = (Random.Range(transform.position.x - transform.
        localScale.x * 0.5f, transform.position.x + transform.localScale.x * 0.5f));

        nextTransform.y = (Random.Range(transform.position.y - transform.
        localScale.y * 0.5f, transform.position.y + transform.localScale.y * 0.5f));

        nextTransform.z = (Random.Range(transform.position.z - transform.
        localScale.z * 0.5f, transform.position.z + transform.localScale.z * 0.5f));

        return nextTransform;
    }
}
