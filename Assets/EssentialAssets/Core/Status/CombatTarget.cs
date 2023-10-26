using UnityEngine;

namespace EssentialAssets.Core
{
    public class CombatTarget: MonoBehaviour
    {
        private void OnParticleCollision(GameObject other)
        {
            GetComponent<Health>().TakeDamage(1);
        }
    }
}