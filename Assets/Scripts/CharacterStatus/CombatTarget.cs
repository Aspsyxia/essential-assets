using UnityEngine;

namespace EssentialAssets.Status
{
    /// <summary>
    /// Marks object as a combat target, what makes it vulnerable to projectiles (temporary simplified) and allows objects with Fighter component to attack it.
    /// </summary>
    public class CombatTarget: MonoBehaviour
    {
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnParticleCollision(GameObject other)
        {
            _health.TakeDamage(1);
        }
    }
}