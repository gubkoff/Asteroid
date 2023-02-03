using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid.Gameplay
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.position += (transform.forward * _speed) * Time.deltaTime;
        }
    }
}
