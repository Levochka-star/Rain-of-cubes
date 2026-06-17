using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Cube : MonoBehaviour, IPoolable<Cube>
    {
        [SerializeField] private float _minSecondsLive = 2f;
        [SerializeField] private float _maxSecondsLive = 5f;

        private Coroutine _coroutine;

        private bool _wasTouch;
        private float _lifeTime;

        public event Action<Cube> ReadyToDestroy;
        public event Action ColorChangeRequested;

        private void OnEnable()
        {
            _lifeTime = UnityEngine.Random.Range(_minSecondsLive, _maxSecondsLive);
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

                _coroutine = StartCoroutine(WaitDelayDestroy(_lifeTime));
            }
        }

        private IEnumerator WaitDelayDestroy(float delay)
        {
            yield return new WaitForSeconds(delay);

            ReadyToDestroy?.Invoke(this);
        }
    }
}