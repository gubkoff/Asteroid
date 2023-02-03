using Asteroid.GameLogic.Events;
using TMPro;
using UnityEngine;

namespace Asteroid.UI
{
    public class SpeedLabel : MonoBehaviour
    {
        private TextMeshProUGUI _label;
        
        private void Awake()
        {
            _label = GetComponent<TextMeshProUGUI>();
        }
    
        private void OnEnable()
        {
            EventsHolder.OnSpeedChanged += ShowValue;
        }

        private void OnDisable()
        {
            EventsHolder.OnSpeedChanged -= ShowValue;
        }

        private void ShowValue(float value)
        {
            _label.text = value.ToString("0.0");
        }
    }
}

