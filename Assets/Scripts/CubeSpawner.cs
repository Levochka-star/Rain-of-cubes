using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class CubeSpawner : Spawner<Cube>
    {
        private Coroutine _coroutine;

        public void Stop()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private IEnumerator WaitDelayDestroy(float delay)
        {
            yield return new WaitForSeconds(delay);

            Cube cube = Spawn();

            cube.transform.position = GenerateRandomVector3();
            Work();
        }

        private void Start()
        {
            Work();
        }

        private void Work()
        {
            _coroutine = StartCoroutine(WaitDelayDestroy(0.2f));

        }

        public Vector3 GenerateRandomVector3()
        {
            var nextTransform = transform.position;

            nextTransform.x = (UnityEngine.Random.Range(transform.position.x - transform.
            localScale.x * 0.5f, transform.position.x + transform.localScale.x * 0.5f));

            nextTransform.y = (UnityEngine.Random.Range(transform.position.y - transform.
            localScale.y * 0.5f, transform.position.y + transform.localScale.y * 0.5f));

            nextTransform.z = (UnityEngine.Random.Range(transform.position.z - transform.
            localScale.z * 0.5f, transform.position.z + transform.localScale.z * 0.5f));

            return nextTransform;
        }
    }
}