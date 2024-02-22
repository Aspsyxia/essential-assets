using UnityEngine;
using System.Collections;

namespace EssentialAssets.Items
{
    public class MeleeWeapon: Weapon
    {
        protected override void Attack()
        {
            StartCoroutine(ProcessMeleeAttack());
        }

        private IEnumerator ProcessMeleeAttack()
        {
            yield return AttackStartActions();
            yield return AttackEndActions(); 
        }

        private IEnumerator AttackStartActions()
        {
            CanAttack = false;
            AudioSource.PlayOneShot(useSound);
            Animator.SetTrigger("use");
            yield return null;
        }
        
        private IEnumerator AttackEndActions()
        {
            yield return new WaitForSeconds(attackCooldown);
            CanAttack = true;
        }
        
        public void Hit()
        {
            ProcessRaycast();
        }
    }
}