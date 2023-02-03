using Asteroid.GameLogic.Events;
using TMPro;
using UnityEngine;

namespace Asteroid.UI
{
    public class ScoresLabel : MonoBehaviour
    {
        private TextMeshProUGUI _label;
        
        private void Awake()
        {
            _label = GetComponent<TextMeshProUGUI>();
        }
    
        private void OnEnable()
        {
            EventsHolder.OnScoresChanged += ShowValue;
        }
        
        private void OnDisable()
        {
            EventsHolder.OnScoresChanged -= ShowValue;
        }

        private void ShowValue(int value)
        {
            _label.text = value.ToString();
        }
    }
}