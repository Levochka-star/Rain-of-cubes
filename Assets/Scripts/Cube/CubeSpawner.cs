using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(GeneratorSpawnZone))]
    public class CubeSpawner : Spawner<Cube>
    {
        private Coroutine _coroutine;

        private GeneratorSpawnZone _spawnZone;

        private WaitForSeconds _waitSpawn = new WaitForSeconds(0.2f);

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
            _coroutine = StartCoroutine(WaitDelaySpawn());
        }

        private IEnumerator WaitDelaySpawn()
        {
            while (enabled)
            {
                yield return _waitSpawn;

                Cube cube = Spawn();

                cube.transform.position = _spawnZone.GenerateRandomVector3();
            }
        }
    }
}