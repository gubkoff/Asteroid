using Asteroid.GameLogic.Core;
using UnityEngine;

namespace Asteroid.Gameplay
{
    public class TeleportToOppositeSide : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        private Vector3 _boundary;

        private void Start()
        {
            _boundary = _collider.bounds.size;
        }

        private void FixedUpdate()
        {
            if (CoordinateHelper.IsOutOfScreen(transform.position, _boundary))
            {
                transform.position = CoordinateHelper.GetOppositeScreenSidePosition(transform.position, _boundary);
            }
        }
    }
}
