using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts
{
    public interface IPoolable<T> where T : MonoBehaviour, IPoolable<T>
    {
        public event Action<T> ReadyToDestroy;
    }

    public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable<T>
    {
        [SerializeField] private T _prefab;

        private ObjectPool<T> _poll;

        private void Awake()
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

        private void Configure(T obj)
        {
            obj.gameObject.SetActive(true);
            obj.ReadyToDestroy += ReturnToPool;
        }

        private void ReturnToPool(T obj)
        {
            obj.ReadyToDestroy -= ReturnToPool;
            _poll.Release(obj);
        }

        protected T Spawn()
        {
            return _poll.Get();
        }
    }
}