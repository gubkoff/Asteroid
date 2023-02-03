using Asteroid.GameLogic.SpawnManagement;
using Asteroid.GameLogic.Core;
using UnityEngine;

namespace Asteroid.Gameplay.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        public void Death()
        {
            Spawner.Spawn(ObjectType.ExplosionVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
