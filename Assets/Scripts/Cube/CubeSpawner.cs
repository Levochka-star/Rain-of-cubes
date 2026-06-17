using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(GeneratorSpawnZone))]
    public class CubeSpawner : Spawner<Cube>
    {
        private Coroutine _coroutine;

        private GeneratorSpawnZone _spawnZone;

        private void Awake()
        {
            _spawnZone = GetComponent<GeneratorSpawnZone>();
        }

        private void OnDisable()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        public void Work()
        {
            _coroutine = StartCoroutine(WaitDelaySpawn(0.2f));
        }

        private IEnumerator WaitDelaySpawn(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);

                Cube cube = Spawn();

                cube.transform.position = _spawnZone.GenerateRandomVector3();
            }
        }
    }
}