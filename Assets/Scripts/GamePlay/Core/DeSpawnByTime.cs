using Asteroid.GameLogic.SpawnManagement;
using UnityEngine;

namespace Asteroid.Gameplay
{
    public class DeSpawnByTime : MonoBehaviour
    {
        [SerializeField] private float _timer;
        private float timer;
        private bool isStartTimer;

        private void OnEnable()
        {
            isStartTimer = true;
            timer = 0;
        }

        private void OnDisable()
        {
            isStartTimer = false;
        }

        private void Update()
        {
            if (isStartTimer)
            {
                if (timer < _timer)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    isStartTimer = false;
                    Spawner.DeSpawn(gameObject);
                }
            }
        }
    }
}
