using UnityEngine;

namespace Core
{
    public abstract class InputAction: MonoBehaviour
    {
        /// <summary>
        /// Marks all MonoBehaviours that take player input.
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