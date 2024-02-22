using EssentialAssets.UI;
using EssentialAssets.Utilities;
using UnityEngine;

namespace EssentialAssets.InteractionSystem
{
    /// <summary>
    /// Allows GameObject with this script attached to interact with other GameObjects using IInteractable interface.
    /// </summary>
    internal class Interaction : InputAction
    {
        [Header("Specification")]
        [SerializeField] private float interactionRange = 3f;
        [SerializeField] private Transform interactionOrigin;

        [Header("Interaction type data")] 
        [SerializeField] private InteractionData[] interactionData;
        
        private InteractionPrompt prompt;

        private void Start()
        {
            prompt = FindObjectOfType<InteractionPrompt>();
        }
        
        private void Update()
        {
            if(!IsActive) return;
            InteractionCheck();
        }
        
        private void InteractionCheck()
        {
            if (Physics.Raycast(interactionOrigin.position, interactionOrigin.forward, out var hit, interactionRange))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    prompt.EnablePrompt(MatchInteractionData(interactable.GetInteractionType()));
                    
                    if (Input.GetMouseButtonDown(0))
                    {
                        foreach(var interactionBehaviour in hit.collider.GetComponents<IInteractable>())
                        {
                            interactionBehaviour.Interact();
                        }
                    }
                }
                else
                {
                    prompt.ClearPrompt();
                }
            }
            else prompt.ClearPrompt();
        }

        private InteractionData MatchInteractionData(InteractionType type)
        {
            foreach (var data in interactionData)
            {
                if (data.Type == type) return data;
            }

            return interactionData[0];
        }
    }
}
