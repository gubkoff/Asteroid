using Asteroid.GameLogic.Events;
using TMPro;
using UnityEngine;

namespace Asteroid.UI
{
    public class CoordinatesLabel : MonoBehaviour
    {
        private TextMeshProUGUI _label;

        private void Awake()
        {
            _label = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            EventsHolder.OnCoordinatesChanged += ShowValue;
        }

        private void OnDisable()
        {
            EventsHolder.OnCoordinatesChanged -= ShowValue;
        }

        private void ShowValue(Vector3 value)
        {
            _label.text = $"X: {value.x.ToString("0.0")} | Y: {value.z.ToString("0.0")}";
        }
    }
}