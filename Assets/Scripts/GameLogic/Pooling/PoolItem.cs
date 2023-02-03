using System;
using Asteroid.GameLogic.Core;
using UnityEngine;

namespace Asteroid.GameLogic.Pooling
{
    [Serializable]
    public sealed class PoolItem
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private ObjectType _type;
        [SerializeField] private int _size;

        public GameObject Prefab => _prefab;
        public ObjectType Type => _type;
        public int Size => _size;
    }
}