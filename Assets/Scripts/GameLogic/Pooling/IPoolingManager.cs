using Asteroid.GameLogic.Core;
using UnityEngine;

namespace Asteroid.GameLogic.Pooling
{
    public interface IPoolingManager
    {
        void PreparePool();
        public GameObject GetObjectByType(ObjectType type);
    }
}