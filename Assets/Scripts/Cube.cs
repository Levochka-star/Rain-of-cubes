using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Cube : MonoBehaviour, IPoolable<Cube>, IColorable
    {
        private Coroutine _coroutine;

        public event Action<Cube> ReadyToDestroy;
        public event Action ColorChangeRequested;

        private bool _wasTouch;

        private void OnEnable()
        {
            _wasTouch = false;
        }

        private void OnDisable()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Ground>(out Ground ground) && !_wasTouch)
            {
                _wasTouch = true;
                ColorChangeRequested?.Invoke();

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