using System;
using UnityEngine;

namespace EssentialAssets.Core
{
    /// <summary>
    /// Allows GameObject with this script attached to interact with other GameObjects using IInteractable interface.
    /// </summary>
    internal class Interaction : InputAction
    {
        [Header("Specification")]
        [SerializeField] private float interactionRange = 3f;
        [SerializeField] private Transform interactionOrigin;

        public event Action<string> InteractionPossible;
        public event Action InteractionStop;
        
        private void Update()
        {
            if(!IsActive) return;
            InteractionCheck();
        }
        
        private void InteractionCheck()
        {
            if (Physics.Raycast(interactionOrigin.position, interactionOrigin.forward, out var hit, interactionRange))
            {
                if (!hit.collider.TryGetComponent(out IInteractable interactable)) return;
                InteractionPossible?.Invoke($"interact - {interactable.GetInteractionPrompt().ToString()}");
                if (Input.GetKeyDown(interactable.GetInteractionPrompt())) interactable.Interact();
            }
            else InteractionStop?.Invoke();
        }
    }
}
