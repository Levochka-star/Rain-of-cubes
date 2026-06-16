using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(ColorChanger))]

    public class Sphere : MonoBehaviour, IPoolable<Sphere>
    {
        public event Action<Sphere> ReadyToDestroy;

    }
}
