using Asteroid.GameLogic.Core;
using UnityEngine;

namespace Asteroid.GameLogic.SpawnManagement
{
    public static class CountingSpawner
    {   
        private static int _spawnCount;
        
        public static void SpawnOutOfScreen(ObjectType type)
        {
            Spawner.SpawnOutOfScreen(type);
            _spawnCount++;
        }

        public static void Spawn(ObjectType type, Vector3 position)
        {
            Spawner.Spawn(type, position);
            _spawnCount++;
        }

        public static void Spawn(ObjectType type, Vector3 position, Quaternion rotation)
        {
            Spawner.Spawn(type, position, rotation);
            _spawnCount++;
        }

        public static void DeSpawn(GameObject obj)
        {
            Spawner.DeSpawn(obj);
            _spawnCount--;
        }

        public static void Clear()
        {
            _spawnCount = 0;
        }

        public static int GetCount()
        {
            return _spawnCount;
        }
    }
}
