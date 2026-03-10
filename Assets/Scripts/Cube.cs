using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Cube : MonoBehaviour, IPoolable<Cube>
    {
        private Coroutine _coroutine;

        public event Action<Cube> ReadyToDestroy;

        public void Stop()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Terrain"))
            {
                _coroutine = StartCoroutine(WaitDelayDestroy(UnityEngine.Random.Range(2, 5)));
            }
        }

        private IEnumerator WaitDelayDestroy(float delay)
        {
            yield return new WaitForSeconds(delay);

            ReadyToDestroy?.Invoke(this);
        }
    }
}