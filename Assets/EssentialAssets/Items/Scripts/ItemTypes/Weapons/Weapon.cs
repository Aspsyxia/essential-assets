using UnityEngine;
using Core;

namespace Items
{
    public abstract class Weapon: EquippableItem
    {
        [Header("Raycast")]
        [SerializeField] protected Transform raycastOrigin; 

        [Header("VFX")]
        [SerializeField] protected ParticleSystem attackEffect;
        [SerializeField] protected GameObject hitVFX;
        
        [Header("Specification")]
        [SerializeField] protected int damage = 2;
        [SerializeField] protected float range = 5f;
        [SerializeField] protected float attackCooldown = 0.5f;
        
        protected bool CanAttack = true;

        protected override void Use()
        {
            if (CanAttack) Attack();
        }

        protected virtual void Attack()
        {
            print("Attacked");
        }
        
        protected void ProcessRaycast()
        {
            if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out RaycastHit hit, range))
            {  
                if (hit.collider.TryGetComponent(out CombatTarget target))
                {
                    CreateImpact(hit);
                    target.GetComponent<Health>().TakeDamage(damage);
                }
            }
        }
        
        private void CreateImpact(RaycastHit hit)
        {
            GameObject effect = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(effect, 0.5f);
        }
    }
}