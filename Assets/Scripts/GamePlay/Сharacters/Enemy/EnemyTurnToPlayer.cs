using Asteroid.GameLogic.Core;
using UnityEngine;

namespace Asteroid.Gameplay.Enemy
{
    [RequireComponent(typeof(EnemySettings))]
    public class EnemyTurnToPlayer : MonoBehaviour
    {
        private EnemySettings _settings;
        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = GameObject.FindWithTag(Constants.PLAYER_TAG)?.transform;
            _settings = GetComponent<EnemySettings>();
        }
        
        private void FixedUpdate()
        {
            SetRotation();
        }

        private void SetRotation()
        {
            Quaternion rotation = transform.rotation;

            if (_playerTransform != null)
            {
                Vector3 targetDirection = (_playerTransform.position - transform.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                rotation = Quaternion.RotateTowards(transform.rotation, targetRotation , Time.fixedDeltaTime * _settings.TurnSpeed);
            }
            transform.rotation = rotation;
            Debug.DrawLine(transform.position, transform.forward * 20 + transform.position, Color.green);
        }
    }
}
