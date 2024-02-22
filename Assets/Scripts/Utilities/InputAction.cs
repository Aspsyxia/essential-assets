using UnityEngine;

namespace EssentialAssets.Utilities
{
    /// <summary>
    /// Marks all MonoBehaviours that take player input.
    /// </summary>
    public abstract class InputAction: MonoBehaviour
    {
        /// <summary>
        /// Activates or deactivates InputAction based on given bool value.
        /// </summary>
        protected bool IsActive = true;

        public virtual void Enable()
        {
            IsActive = true;
        }

        public virtual void Disable()
        {
            IsActive = false;
        }
    }
}