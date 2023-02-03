using Asteroid.GameLogic.Events;
using Asteroid.GameLogic.Settings;

namespace Asteroid.GameLogic.Core
{
    public static class GameData
    {
        private static int _scores;

        static GameData()
        {
            EventsHolder.OnEnemyDeath += EnemyDeath;
        }

        public static int Scores => _scores;

        public static void SetGameData(GameSettingsSO settings)
        {
            _scores = 0;
            EventsHolder.RaiseScoresChanged(_scores);
        }

        private static void EnemyDeath(int scores)
        {
            _scores += scores;
            EventsHolder.RaiseScoresChanged(_scores);
        }
    }
}
