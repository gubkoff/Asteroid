using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid.Gameplay.Player
{
    public class PlayerSynchronizeTurn : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private PlayerTurn _turn;
        
        private float _acceleration;
        private float _accelerationResult;
        
        public void Acceleration(float acceleration)
        {
            _acceleration = acceleration;
        }
        
        private void SetAccelerationByTurn()
        {
            var angle = Quaternion.Angle(_movement.transform.rotation, _turn.transform.rotation);
            
            _accelerationResult = angle < 90 ? _acceleration : -_acceleration;
            _movement.Acceleration(_accelerationResult);
        }
        
        private void SynchroniseTurn()
        {
            if (_acceleration <= 0)
            {
               return;
            }
            
            if (_accelerationResult < 0 && _movement.Speed == 0 || _accelerationResult > 0)
            {
                _movement.transform.rotation = _turn.transform.rotation;
                _turn.transform.localEulerAngles = Vector3.zero;
            }
        }

        private void FixedUpdate()
        {
            SetAccelerationByTurn();
            SynchroniseTurn();
        }
    }
}
