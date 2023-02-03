using Asteroid.GameLogic.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroid.Gameplay.Player
{
    public class Player : MonoBehaviour, InputMaster.IPlayerActions
    {
        [SerializeField] private PlayerSettings _settings;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerTurn _playerTurn;
        [SerializeField] private PlayerSynchronizeTurn _playerSynchronizeTurn;
        [SerializeField] private PlayerShoot _playerShoot;
        [SerializeField] private PlayerMegaShoot _playerMegaShoot;
        [SerializeField] private PlayerDeath _playerDeath;
        
        private void OnEnable()
        {
            EventsHolder.OnPlayerDeath += Death;
        }
        private void OnDisable()
        {
            EventsHolder.OnPlayerDeath -= Death;
        }

        private void Start()
        {
            PlayerInput.SetPlayer(this);
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _playerShoot?.Shoot();
            }
        }

        public void OnMegaShoot(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _playerMegaShoot.Shoot();
            }
        }

        public void OnTurn(InputAction.CallbackContext context)
        {
            if (context.started || context.canceled)
            {
                _playerTurn.Turn(context.ReadValue<float>());
            }
        }

        public void OnAcceleration(InputAction.CallbackContext context)
        {
            if (context.started || context.canceled)
            {
                _playerMovement.Acceleration(context.ReadValue<float>());
                _playerSynchronizeTurn?.Acceleration(context.ReadValue<float>());
            }
        }

        private void Death()
        {
            _playerDeath?.Death();
        }
    }
}