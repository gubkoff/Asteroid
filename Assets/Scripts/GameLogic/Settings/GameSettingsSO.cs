using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid.GameLogic.Settings
{
    [CreateAssetMenu(fileName = "Game Settings", menuName = "Settings/Game Settings")]
    public class GameSettingsSO : ScriptableObject
    {
        [Header("Player")]
        [SerializeField] private GameObject _playerPrefab;
        
        [Header("Spawn")]
        [SerializeField][Range(1, 20)] private float _minTimeSpawn;
        [SerializeField][Range(1, 20)] private float _maxTimeSpawn;
        [SerializeField][Range(-1, 1)] private float _ufoSpawnProbabilities;
        

        public GameObject PlayerPrefab => _playerPrefab;
        
        public float MinTimeSpawn => _minTimeSpawn;
        public float MaxTimeSpawn => _maxTimeSpawn;
        public float UfoSpawnProbabilities => _ufoSpawnProbabilities;

    }
}

