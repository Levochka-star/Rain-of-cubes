using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Colorer))]

    public class Sphere : MonoBehaviour, IPoolable<Sphere>
    {
        [SerializeField] private float _minSecondsLive = 2f;
        [SerializeField] private float _maxSecondsLive = 5f;

        private float _lifeTime;

        private Coroutine _coroutine;

        public event Action<Sphere> ReadyToDestroy;
        public event Action<float> AlphaChanging;

        private void OnEnable()
        {
            _lifeTime = UnityEngine.Random.Range(_minSecondsLive, _maxSecondsLive);

            _coroutine = StartCoroutine(WaitDelayDestroy(_lifeTime));
        }

        private void OnDisable()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator WaitDelayDestroy(float delay)
        {
            float progress = delay;
            float totalDuration = progress;

            while (progress > 0)
            {
                AlphaChanging?.Invoke(progress/totalDuration);

                progress -= Time.deltaTime;

                yield return null;
            }

            ReadyToDestroy?.Invoke(this);
        }
    }
}
