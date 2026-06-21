using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts
{
    public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable<T>
    {
        [SerializeField] private T _prefab;

        private ObjectPool<T> _poll;

        public int ValueSpawnedObjects { get; private set; } = 0;
        public int ValueCreatedObjects { get; private set; } = 0;
        public int ValueActivedObjects { get; private set; } = 0;

        public event Action<Vector3> ObjectRelised;
        public event Action StatsObjectChanged;

        private T Create()
        {
            ValueCreatedObjects++;
            StatsObjectChanged?.Invoke();

            return Instantiate(_prefab, Vector3.zero, Quaternion.identity);
        }

        private void Configure(T obj)
        {
            obj.gameObject.SetActive(true);
            obj.ReadyToDestroy += ReturnToPool;

            ValueActivedObjects++;
            StatsObjectChanged?.Invoke();
        }

        private void ReturnToPool(T obj)
        {
            obj.ReadyToDestroy -= ReturnToPool;

            ObjectRelised?.Invoke(obj.transform.position);

            _poll.Release(obj);

            ValueActivedObjects--;
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

            ValueSpawnedObjects++;
            StatsObjectChanged?.Invoke();

            return _poll.Get();
        }
    }
}