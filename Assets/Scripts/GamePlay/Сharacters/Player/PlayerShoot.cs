using Asteroid.GameLogic.SpawnManagement;
using Asteroid.GameLogic.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroid.Gameplay.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Transform _shotSpawn;
        
        public void Shoot()
        {
            Spawner.Spawn(ObjectType.Bolt, _shotSpawn.position, _shotSpawn.rotation);
        }
    }
}
