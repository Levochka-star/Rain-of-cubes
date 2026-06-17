using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts
{
    public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable<T>
    {
        [SerializeField] private T _prefab;

        private ObjectPool<T> _poll;

        public event Action<Vector3> ObjectRelised;

        private void Configure(T obj)
        {
            obj.gameObject.SetActive(true);
            obj.ReadyToDestroy += ReturnToPool;
        }

        private void ReturnToPool(T obj)
        {
            obj.ReadyToDestroy -= ReturnToPool;

            ObjectRelised?.Invoke(obj.transform.position);

            _poll.Release(obj);
        }

        protected T Spawn()
        {
            if (_poll == null)
            {
                _poll = new ObjectPool<T>(
                  createFunc: () => Instantiate(_prefab, Vector3.zero, Quaternion.identity),
                  actionOnGet: Configure,
                  actionOnRelease: (obj) => obj.gameObject.SetActive(false),
                  actionOnDestroy: (obj) => Destroy(obj.gameObject),
                  collectionCheck: false,
                  defaultCapacity: 20,
                  maxSize: 30
                  );
            }

            return _poll.Get();
        }
    }
}