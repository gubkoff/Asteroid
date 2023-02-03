using System.Collections;
using Asteroid.GameLogic.Core;
using Asteroid.GameLogic.Settings;
using Asteroid.GameLogic.SpawnManagement;
using UnityEngine;

namespace Asteroid.Gameplay
{
    public class EnemySpawn : MonoBehaviour
    {
        private GameSettingsSO _settings;
        private bool _isSpawned;
        private bool _isStartGame;

        public void Init(GameSettingsSO settings)
        {
            _isSpawned = true;
            _isStartGame = true;
            _settings = settings;
            StartCoroutine(Spawn());
        }

        public void EndSpawn()
        {
            _isSpawned = false;
        }

        private IEnumerator Spawn()
        {
            while (_isSpawned)
            {
                var timeSpawn = _isStartGame ? 1f : Random.Range(_settings.MinTimeSpawn, _settings.MaxTimeSpawn);
                yield return new WaitForSeconds(timeSpawn);
                _isStartGame = false;
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            CountingSpawner.SpawnOutOfScreen(GetEnemyType());
        }

        private ObjectType GetEnemyType()
        {
            return Random.Range(-1f, 1f) > _settings.UfoSpawnProbabilities ? ObjectType.UFO : ObjectType.BigAsteroid;
        }
    }
}