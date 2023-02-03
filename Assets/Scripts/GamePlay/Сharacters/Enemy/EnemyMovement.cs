using UnityEngine;

namespace Asteroid.Gameplay.Enemy
{
    [RequireComponent(typeof(EnemySettings))]
    public class EnemyMovement : MonoBehaviour
    {
        private EnemySettings _settings;

        private void Start()
        {
            _settings = GetComponent<EnemySettings>();
        }

        private void FixedUpdate()
        {
            SetPosition();
        }

        private void SetPosition()
        {
            Vector3 position = transform.position + (transform.forward * _settings.Speed) * Time.fixedDeltaTime;
            transform.position = position;
        }
    }
}
