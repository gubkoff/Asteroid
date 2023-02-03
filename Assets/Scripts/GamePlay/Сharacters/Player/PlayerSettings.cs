using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid.Gameplay.Player
{
    public class PlayerSettings : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _slowdown;

        [SerializeField] private float _turnSpeed;

        [Header("Mega Shoot")] 
        [SerializeField] private int _megaShootCount;
        [SerializeField] public float _megaShootRestartSeconds;
        
        public float MaxSpeed => _maxSpeed;
        public float Acceleration => _acceleration;
        public float Slowdown => _slowdown;
        public float TurnSpeed => _turnSpeed;
        
        public int MegaShootCount => _megaShootCount;
        public float MegaShootRestartSeconds => _megaShootRestartSeconds;
    }
}

