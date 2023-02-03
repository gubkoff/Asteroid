using Asteroid.GameLogic.Events;
using UnityEngine;

namespace Asteroid.Gameplay.Player
{
    [RequireComponent(typeof(PlayerSettings))]
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerSettings _settings;
        private float _acceleration;
        private float _speed;

        public float Speed => _speed;

        private void Start()
        {
            _settings = GetComponent<PlayerSettings>();
        }

        public void Acceleration(float acceleration)
        {
            _acceleration = acceleration;
        }

        private void Movement()
        {
            _speed += _acceleration * _settings.Acceleration * Time.fixedDeltaTime;
            _speed -= _settings.Slowdown * Time.fixedDeltaTime;
            _speed = Mathf.Clamp(_speed, 0, _settings.MaxSpeed);

            transform.position += (transform.forward * _speed) * Time.deltaTime;

            EventsHolder.RaiseCoordinatesChanged(transform.position);
            EventsHolder.RaiseSpeedChanged(_speed);
        }

        private void FixedUpdate()
        {
            Movement();
            Debug.DrawLine(transform.position, transform.forward * 20 + transform.position, Color.red);
        }
    }
}