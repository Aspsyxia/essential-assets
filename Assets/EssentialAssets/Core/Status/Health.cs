using System;
using UnityEngine;
using EssentialAssets.Ai;

namespace EssentialAssets.Core
{
    public class Health: MonoBehaviour
    {
        [SerializeField] private int healthPoints = 5;

        private ActionManager manager;
        
        public event Action PlayerDeath;

        public bool IsDead { get; private set; }

        private void Awake()
        {
            manager = GetComponent<ActionManager>();
        }

        public void TakeDamage(int damageAmount)
        {
            if (IsDead) return;
            healthPoints = Math.Max(0, healthPoints - damageAmount);
            if (healthPoints == 0) Death();
        }

        private void Death()
        {
            IsDead = true;
            
            if (CompareTag("Player")) PlayerDeath?.Invoke();
            else manager.StopCurrentAction();
            
            if (TryGetComponent(out Collider collider)) collider.enabled = false;
            GetComponent<Animator>().SetTrigger("death");
        }
    }
}