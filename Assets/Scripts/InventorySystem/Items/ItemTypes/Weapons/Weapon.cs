using UnityEngine;
using EssentialAssets.Status;

namespace EssentialAssets.Items
{
    public abstract class Weapon: EquippableItem
    {
        [Header("Raycast")]
        [SerializeField] protected Transform customRaycastOrigin;
        [SerializeField] protected bool cameraIsOrigin = true;

        [Header("VFX")]
        [SerializeField] protected ParticleSystem attackEffect;
        [SerializeField] protected GameObject hitVFX;
        
        [Header("Specification")]
        [SerializeField] protected int damage = 2;
        [SerializeField] protected float range = 5f;
        [SerializeField] protected float attackCooldown = 0.5f;
        
        protected bool CanAttack = true;
        private Transform _weaponRaycast;

        protected override void Start()
        {
            base.Start();
            _weaponRaycast = cameraIsOrigin ? GameObject.FindGameObjectWithTag("MainCamera").transform : customRaycastOrigin;
        }

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
            if (Physics.Raycast(_weaponRaycast.position, _weaponRaycast.forward, out var hit, range))
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
            var effect = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(effect, 0.5f);
        }
    }
}