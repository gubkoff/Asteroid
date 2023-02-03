using System;
using System.Collections;
using System.Collections.Generic;
using Asteroid.GameLogic.Core;
using Asteroid.GameLogic.Events;
using Asteroid.GameLogic.SpawnManagement;
using UnityEngine;

namespace Asteroid.Gameplay.Player
{
    [RequireComponent(typeof(PlayerSettings))]
    public class PlayerMegaShoot : MonoBehaviour
    {
        [SerializeField] private Transform _shotSpawn;
        
        private PlayerSettings _settings;
        private int _shootCount;
        private bool _isStartShootTimer;
        private float _timerInSecond;

        private void OnEnable()
        {
            EventsHolder.OnMegaShootChanged += MegaShootChanged;
        }
        
        private void OnDisable()
        {
            EventsHolder.OnMegaShootChanged -= MegaShootChanged;
        }


        private void Start()
        {
            _settings = GetComponent<PlayerSettings>();
            _shootCount = _settings.MegaShootCount;
            EventsHolder.RaiseMegaShootChanged(_shootCount);
        }
        
        private void FixedUpdate()
        {
            MegaShootTimer();
        }

        public void Shoot()
        {
            if (_shootCount > 0)
            {
                _shootCount--;
                EventsHolder.RaiseMegaShootChanged(_shootCount);
                Spawner.Spawn(ObjectType.MegaBolt, _shotSpawn.position, _shotSpawn.rotation);

                if (_shootCount == 0)
                {
                    _isStartShootTimer = true;
                    _timerInSecond = _settings._megaShootRestartSeconds;
                }
            }
        }

        private void MegaShootChanged(int count)
        {
            _shootCount = count;
        }
        
        private void MegaShootTimer()
        {
            if (!_isStartShootTimer)
                return;

            if (_timerInSecond >= 0)
            {
                _timerInSecond -= Time.deltaTime;
                EventsHolder.RaiseMegaShootTimerChanged(_timerInSecond);
            }
            else
            {
                EventsHolder.RaiseMegaShootChanged(_settings.MegaShootCount);
                _isStartShootTimer = false;
                _timerInSecond = 0;
            }
        }
    }
}
