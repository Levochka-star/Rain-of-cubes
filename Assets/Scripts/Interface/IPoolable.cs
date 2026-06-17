using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IPoolable<T> where T : MonoBehaviour, IPoolable<T>
    {
        public event Action<T> ReadyToDestroy;
    }
}
