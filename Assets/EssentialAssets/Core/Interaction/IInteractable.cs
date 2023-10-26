using UnityEngine;

namespace EssentialAssets.Core
{
    public interface IInteractable
    {
        /// <summary>
        /// Interaction behaviour.
        /// </summary>
        public void Interact();
        /// <summary>
        /// Returns KeyItem that triggers interaction.
        /// </summary>
        public KeyCode GetInteractionPrompt();
    }
}
