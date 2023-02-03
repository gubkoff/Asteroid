using Asteroid.GameLogic.Core;
using Asteroid.GameLogic.Pooling;
using UnityEngine;

namespace Asteroid.GameLogic.SpawnManagement
{
    public static class Spawner
    {
        private static IPoolingManager _poolingManager;

        public static void SetPool(IPoolingManager pool)
        {
            _poolingManager = pool;
        }

        public static void SpawnOutOfScreen(ObjectType type)
        {
            Spawn(type, CoordinateHelper.GetRandomCoordinatesOutOfScreen());
        }

        public static void Spawn(ObjectType type, Vector3 position)
        {
            Spawn(type, position, CoordinateHelper.GetRandomRotateByY());
        }

        public static void Spawn(ObjectType type, Vector3 position, Quaternion rotation)
        {
            var obj = _poolingManager?.GetObjectByType(type);
            if (obj != null)
            {
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
            }
        }

        public static void DeSpawn(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}
       