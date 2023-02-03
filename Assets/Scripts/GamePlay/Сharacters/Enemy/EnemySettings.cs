using Asteroid.GameLogic.Core;
using UnityEngine;

namespace Asteroid.Gameplay.Enemy
{
    public class EnemySettings : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _speed;
        [SerializeField] private float _turnSpeed;

        [Header("Scores")] 
        [SerializeField] private int _scores;
        
        [Header("Spawn after death")]
        [SerializeField] private bool _isSpawnObjectsAfterDeath;
        [SerializeField] private ObjectType _spawnType;
        [SerializeField] private int _spawnCount;
        
        public float Speed => _speed;
        public float TurnSpeed => _turnSpeed;
        
        public int Scores => _scores;
        
        public bool IsSpawnObjectsAfterDeath => _isSpawnObjectsAfterDeath;
        public ObjectType SpawnType => _spawnType;
        public int SpawnCount => _spawnCount;
    }
}
