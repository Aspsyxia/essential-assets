using UnityEngine;

namespace Items
{
    public class ShootingWeapon : EquippableItem
    {
        [Header("References")] [SerializeField]
        private ParticleSystem projectiles;

        protected override void Start()
        {
            base.Start();
            projectiles.Stop();
        }

        protected override void CheckForInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                projectiles.Play();
            }

            if (Input.GetMouseButtonUp(0))
            {
                projectiles.Stop();
            }
        }
    }
}
