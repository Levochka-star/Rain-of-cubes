using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(ColorChanger))]

    public class Cube : MonoBehaviour, IPoolable<Cube>
    {
        private Coroutine _coroutine;
        private ColorChanger _colorChanger;

        public event Action<Cube> ReadyToDestroy;

        public void Stop()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
            {
                if (TryGetComponent<ColorChanger>(out ColorChanger colorChanger))
                {
                    Colorer(collision, colorChanger);
                }

                _coroutine = StartCoroutine(WaitDelayDestroy(UnityEngine.Random.Range(2, 5)));
            }
        }

        private IEnumerator WaitDelayDestroy(float delay)
        {
            yield return new WaitForSeconds(delay);

            ReadyToDestroy?.Invoke(this);
        }

        private void Colorer(Collision collision, ColorChanger colorChanger)
        {
            if (colorChanger._wasTouch == false)
            {
                colorChanger.Work();
            }
        }
    }
}