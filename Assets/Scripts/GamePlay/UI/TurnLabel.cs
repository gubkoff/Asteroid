using Asteroid.GameLogic.Events;
using TMPro;
using UnityEngine;

namespace Asteroid.UI
{
    public class TurnLabel : MonoBehaviour
    {
        private TextMeshProUGUI _label;
        
        private void Awake()
        {
            _label = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            EventsHolder.OnTurnChanged += ShowValue;
        }
        
        private void OnDisable()
        {
            EventsHolder.OnTurnChanged -= ShowValue;
        }

        private void ShowValue(float value)
        {
            _label.text = value.ToString("0.0");
        }
    }
}