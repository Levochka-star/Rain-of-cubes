using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(GeneratorSpawnZone))]
    public class SphereSpawner : Spawner<Sphere>
    {
        public void Work(Vector3 position)
        {
            Sphere sphere = Spawn();

            sphere.transform.position = position;
        }
    }
}
