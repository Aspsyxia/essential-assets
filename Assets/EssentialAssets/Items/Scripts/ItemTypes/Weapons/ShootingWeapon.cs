using System.Collections;
using UnityEngine;

namespace Items
{
    public class ShootingWeapon : Weapon
    {
        [Header("References")] 
        [SerializeField] private ParticleSystem projectiles;

        [Header("Fire mode")] 
        [SerializeField] private bool rapidFire = false;

        protected override void Start()
        {
            base.Start();
            projectiles.Stop();
        }

        protected override void CheckForInput()
        {
            if (rapidFire)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Attack();
                }

                if (!Input.GetMouseButtonUp(0)) return;
                AttackStop();
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (CanAttack) StartCoroutine(SingleShot());
                }
            }
        }

        protected override void Attack()
        {
            Animator.Play("RapidFire");
            //AudioSource.PlayOneShot(useSound);
            projectiles.Play();
            ProcessRaycast();
        }

        private void AttackStop()
        {
            Animator.Play("Standby");
            projectiles.Stop();
        }

        private IEnumerator SingleShot()
        {
            CanAttack = false;
            AudioSource.PlayOneShot(useSound);
            Animator.SetTrigger("use");
            ProcessRaycast();
            yield return new WaitForSeconds(attackCooldown);
            CanAttack = true;
        }
    }
}
