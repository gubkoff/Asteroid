using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroid.Gameplay.Player
{
    public class PlayerInput : MonoBehaviour, InputMaster.IPlayerActions
    {
        private InputMaster controls;
        private static InputMaster.IPlayerActions _player;

        private void OnEnable()
        {
            if (controls != null)
                return;

            controls = new InputMaster();
            controls.Player.SetCallbacks(this);
            controls.Player.Enable();
        }

        public void OnDisable()
        {
            controls.Player.Disable();
        }

        public static void SetPlayer(InputMaster.IPlayerActions player)
        {
            _player = player;
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            _player?.OnShoot(context);
        }

        public void OnMegaShoot(InputAction.CallbackContext context)
        {
            _player?.OnMegaShoot(context);
        }

        public void OnTurn(InputAction.CallbackContext context)
        {
            _player?.OnTurn(context);
        }

        public void OnAcceleration(InputAction.CallbackContext context)
        {
            _player?.OnAcceleration(context);
        }
    }
}