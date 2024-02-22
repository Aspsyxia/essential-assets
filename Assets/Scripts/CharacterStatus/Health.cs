using System;
using UnityEngine;
using EssentialAssets.Actions;

namespace EssentialAssets.Status
{
    public class Health: MonoBehaviour
    {
        [Header("Specification")]
        [SerializeField] private int healthPoints = 5;

        private ActionManager manager;
        
        public event Action PlayerDeath;

        public bool IsDead { get; private set; }

        private void Awake()
        {
            manager = GetComponent<ActionManager>();
        }

        /// <summary>
        /// Subtracts given amount  from target's health points
        /// <param name="damageAmount">number of health points to be subtracted</param>
        /// </summary>
        public void TakeDamage(int damageAmount)
        {
            if (IsDead) return;
            healthPoints = Math.Max(0, healthPoints - damageAmount);
            if (healthPoints == 0) Death();
        }

        /// <summary>
        /// Method that deactivates character that run out of health points and triggers "game over" if that character is player.
        /// </summary>
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