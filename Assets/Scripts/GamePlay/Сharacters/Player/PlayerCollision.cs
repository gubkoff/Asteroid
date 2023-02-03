using System;
using Asteroid.GameLogic.Core;
using Asteroid.GameLogic.Events;
using Asteroid.Gameplay.Enemy;
using UnityEngine;

namespace Asteroid.Gameplay.Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals(Constants.ENEMY_TAG))
            {
                EventsHolder.RaisePlayerDeath();
                var enemyDeath = other.gameObject.GetComponent<EnemyDeath>();
                enemyDeath?.Death();
            }
        }
    }
}