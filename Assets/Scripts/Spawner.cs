using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts
{
    public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable<T>
    {
        [SerializeField] private T _prefab;

        private ObjectPool<T> _poll;

        private int _valueSpawnedObjects = 0;
        private int _valueCreatedObjects = 0;
        private int _valueActivedObjects = 0;

        public int ValueSpawnedObjects => _valueSpawnedObjects;
        public int ValueCreatedObjects => _valueCreatedObjects;
        public int ValueActivedObjects => _valueActivedObjects;

        public event Action<Vector3> ObjectRelised;
        public event Action StatsObjectChanged;

        private T Create()
        {
            _valueCreatedObjects++;
            StatsObjectChanged?.Invoke();

            return Instantiate(_prefab, Vector3.zero, Quaternion.identity);
        }

        private void Configure(T obj)
        {
            obj.gameObject.SetActive(true);
            obj.ReadyToDestroy += ReturnToPool;

            _valueActivedObjects++;
            StatsObjectChanged?.Invoke();
        }

        private void ReturnToPool(T obj)
        {
            obj.ReadyToDestroy -= ReturnToPool;

            ObjectRelised?.Invoke(obj.transform.position);

            _poll.Release(obj);

            _valueActivedObjects--;
            StatsObjectChanged?.Invoke();
        }

        protected T Spawn()
        {
            if (_poll == null)
            {
                _poll = new ObjectPool<T>(
                  createFunc: Create,
                  actionOnGet: Configure,
                  actionOnRelease: (obj) => obj.gameObject.SetActive(false),
                  actionOnDestroy: (obj) => Destroy(obj.gameObject),
                  collectionCheck: false,
                  defaultCapacity: 20,
                  maxSize: 30
                  );
            }

            _valueSpawnedObjects++;
            StatsObjectChanged?.Invoke();

            return _poll.Get();
        }
    }
}