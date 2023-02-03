using Asteroid.GameLogic.Events;
using UnityEngine;

namespace Asteroid.Gameplay.Player
{
    public class PlayerTurn : MonoBehaviour
    {
        [SerializeField] private PlayerSettings _settings;
        private float _direction;
        private float _angle;

        public void Turn(float direction)
        {
            Debug.Log("TURN");
            _direction = direction;
        }

        private void ChangeTurn()
        {
            if (_direction != 0)
            {
                _angle = transform.eulerAngles.y + _direction * (_settings.TurnSpeed * Time.fixedDeltaTime);
                transform.eulerAngles = new Vector3(0,_angle,0);
                EventsHolder.RaiseTurnChanged(transform.eulerAngles.y);
            }
        }

        private void FixedUpdate()
        {
            ChangeTurn();
            Debug.DrawLine(transform.position, transform.forward * 20 + transform.position, Color.green);
        }
    }
}
