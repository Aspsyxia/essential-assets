using UnityEngine;
using Core;

namespace Interaction
{
    internal class Interaction : InputAction
    {
        [Header("Specification")]
        [SerializeField] private float interactionRange = 3f;
        
        private void Update()
        {
            if(!IsActive) return;
            InteractionCheck();
        }
        
        private void InteractionCheck()
        {
            var forward = transform.TransformDirection(Vector3.forward);

            if (!Physics.Raycast(transform.position, forward, out var hit, interactionRange)) return;
            if (!hit.collider.TryGetComponent(out IInteractable interactable)) return;
            if(Input.GetKeyDown(KeyCode.E)) interactable.Interact();
        }
    }
}
