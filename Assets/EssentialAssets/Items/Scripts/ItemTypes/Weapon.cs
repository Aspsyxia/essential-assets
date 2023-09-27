using UnityEngine;

namespace Items
{
    public abstract class Weapon: EquippableItem
    {
        [Header("Raycast")]
        [SerializeField] private Transform raycastOrigin;//The raycast is going to be shot from our point of view

        [Header("VFX")]
        [SerializeField] private ParticleSystem attackEffect;
        [SerializeField] private GameObject hitVFX;
        
        [Header("Specification")]
        [SerializeField] private float range = 100f;
        [SerializeField] private float damage = 2f;
        [SerializeField] private float attackCooldown = 0.5f;
        
        private bool _canAttack = true;

        protected override void Use()
        {
            Attack();
        }

        protected virtual void Attack()
        {
            print($"Attacked with a {name}");
        }
        
        //not finished
    }
}