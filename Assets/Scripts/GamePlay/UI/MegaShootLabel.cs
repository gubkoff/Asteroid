using Asteroid.GameLogic.Events;
using TMPro;
using UnityEngine;

namespace Asteroid.UI
{
    public class MegaShootLabel : MonoBehaviour
    {
        private TextMeshProUGUI _label;
        private float _timer;
        
        private void Awake()
        {
            _label = GetComponent<TextMeshProUGUI>();
        }
    
        private void OnEnable()
        {
            EventsHolder.OnMegaShootChanged += ShowValue;
            EventsHolder.OnMegaShootTimerChanged += ShowTimer;
        }
        
        private void OnDisable()
        {
            EventsHolder.OnMegaShootChanged -= ShowValue;
            EventsHolder.OnMegaShootTimerChanged -= ShowTimer;
        }

        private void ShowValue(int value)
        {
            _label.text = value.ToString();
            _label.color = Color.white;
        }

        private void ShowTimer(float value)
        {
            _label.text = value.ToString("0.0");
            _label.color = Color.red;
        }
    }
}
