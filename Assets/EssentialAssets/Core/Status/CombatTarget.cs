using System;
using UnityEngine;

namespace Core
{
    public class CombatTarget: MonoBehaviour
    {
        private void OnParticleCollision(GameObject other)
        {
            print("got hit by particle");
            GetComponent<Health>().TakeDamage(1);
        }
    }
}