using System;
using UnityEngine;

namespace Core
{
    public class Health: MonoBehaviour
    {
        [SerializeField] private int healthPoints = 5;
        
        public bool IsDead { get; private set; }

        public void TakeDamage(int damageAmount)
        {
            healthPoints = Math.Max(0, healthPoints - damageAmount);
            if (healthPoints == 0) Death();
        }

        private void Death()
        {
            IsDead = true;
            print($"{name} died");
        }
    }
}