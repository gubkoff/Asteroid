using System.Collections;
using System.Collections.Generic;
using Asteroid.GameLogic.Core;
using Asteroid.GameLogic.Events;
using Asteroid.GameLogic.Pooling;
using Asteroid.GameLogic.Settings;
using Asteroid.GameLogic.SpawnManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroid.Gameplay.Core
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private GameSettingsSO _settings;
        [SerializeField] private GameObject _gameOverPopup;
        [SerializeField] private List<PoolItem> _poolItems;
        [SerializeField] private EnemySpawn _enemySpawn;

        

        private void OnEnable()
        {
            EventsHolder.OnPlayerDeath += PlayerDeath;
        }

        private void OnDisable()
        {
            EventsHolder.OnPlayerDeath -= PlayerDeath;
        }

        private void Start()
        {
            InitGame();
        }

        private void InitGame()
        {
            _gameOverPopup.SetActive(false);
            GameData.SetGameData(_settings);
            IPoolingManager pool = new PoolingManager(_poolItems, transform);
            pool.PreparePool();
            Spawner.SetPool(pool);
            _enemySpawn.Init(_settings);
            AddPlayer();
        }

        public void ReloadGame()
        {
            SceneManager.LoadScene(Constants.GAME_SCENE_NAME);
        }

        private void AddPlayer()
        {
            var itemPrefab = Instantiate(_settings.PlayerPrefab, Vector3.zero, Quaternion.identity);
            itemPrefab.transform.SetParent(transform, false);
        }

        private void PlayerDeath()
        {
            StartCoroutine(GameOver());
        }

        private IEnumerator GameOver()
        {
            yield return new WaitForSeconds(1f);
            _enemySpawn.EndSpawn();
            _gameOverPopup.SetActive(true);
            EventsHolder.RaiseScoresChanged(GameData.Scores);
        }
    }
}