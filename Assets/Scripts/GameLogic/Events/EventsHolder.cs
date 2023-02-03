using System;
using UnityEngine;

namespace Asteroid.GameLogic.Events
{
    public static class EventsHolder
    {
        public static Action<Vector3> OnCoordinatesChanged;
        public static Action<float> OnTurnChanged;
        public static Action<float> OnSpeedChanged;
        public static Action<int> OnScoresChanged;
        public static Action OnPlayerDeath;
        public static Action<int> OnEnemyDeath;
        public static Action<int> OnMegaShootChanged;
        public static Action<float> OnMegaShootTimerChanged;

        public static void RaiseCoordinatesChanged(Vector3 coord)
        {
            OnCoordinatesChanged?.Invoke(coord);
        }

        public static void RaiseTurnChanged(float angle)
        {
            OnTurnChanged?.Invoke(angle);
        }
        
        public static void RaiseSpeedChanged(float speed)
        {
            OnSpeedChanged?.Invoke(speed);
        }
        
        public static void RaiseScoresChanged(int speed)
        {
            OnScoresChanged?.Invoke(speed);
        }
        
        public static void RaisePlayerDeath()
        {
            OnPlayerDeath?.Invoke();
        }
        
        public static void RaiseEnemyDeath(int scores)
        {
            OnEnemyDeath?.Invoke(scores);
        }

        public static void RaiseMegaShootChanged(int count)
        {
            OnMegaShootChanged?.Invoke(count);
        } 
        
        public static void RaiseMegaShootTimerChanged(float time)
        {
            OnMegaShootTimerChanged?.Invoke(time);
        }
    }
}

