using UnityEngine;

namespace Interaction
{
    public interface IInteractable
    {
        /// <summary>
        /// Interaction behaviour.
        /// </summary>
        public void Interact();
        /// <summary>
        /// Returns Key that triggers interaction.
        /// </summary>
        public KeyCode GetInteractionPrompt();
    }
}
