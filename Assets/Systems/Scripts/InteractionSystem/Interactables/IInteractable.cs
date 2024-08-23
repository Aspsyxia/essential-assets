using UnityEngine;

namespace EssentialAssets.InteractionSystem
{
    public interface IInteractable
    {
        /// <summary>
        /// Interaction behaviour.
        /// </summary>
        public void Interact();
        /// <summary>
        /// Returns type of currently possible interaction.
        /// </summary>
        public InteractionType GetInteractionType();
    }
}
