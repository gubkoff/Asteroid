using Asteroid.GameLogic.Core;
using Asteroid.Gameplay.Enemy;
using Asteroid.GameLogic.SpawnManagement;
using UnityEngine;

namespace Asteroid.Gameplay
{
    public class Shoot : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals(Constants.ENEMY_TAG))
            {
                var death = other.gameObject.GetComponent<EnemyDeath>();
                death?.Death();
                Spawner.DeSpawn(gameObject);
            }
        }
    }
}
