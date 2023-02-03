using Asteroid.GameLogic.Core;
using Asteroid.GameLogic.Events;
using Asteroid.GameLogic.SpawnManagement;
using UnityEngine;

namespace Asteroid.Gameplay.Enemy
{
    [RequireComponent(typeof(EnemySettings))]
    public class EnemyDeath : MonoBehaviour
    {
        private EnemySettings _settings;

        private void Start()
        {
            _settings = GetComponent<EnemySettings>();
        }

        public void Death()
        {
            LaunchDeath();
            SpawnObjectsAfterDeath();
        }

        public void MegaDeath()
        {
            LaunchDeath();
        }

        private void LaunchDeath()
        {
            EventsHolder.RaiseEnemyDeath(_settings.Scores);
            Spawner.Spawn(ObjectType.ExplosionVFX, transform.position, transform.rotation);
            Spawner.DeSpawn(gameObject);
        }

        private void SpawnObjectsAfterDeath()
        {
            if (_settings.IsSpawnObjectsAfterDeath)
            {
                for (int i = 0; i < _settings.SpawnCount; i++)
                {
                    if (!_settings.SpawnType.Equals(ObjectType.Empty))
                    {
                        Spawner.Spawn(_settings.SpawnType, transform.position);
                    }
                }
            }
        }
    }
}
