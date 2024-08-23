using UnityEngine;
using EssentialAssets.DialogueSystem;

namespace EssentialAssets.InteractionSystem
{
    [RequireComponent(typeof(DialogueTrigger))]
    public class InteractableObject: MonoBehaviour, IInteractable
    {
        private DialogueTrigger _dialogueTrigger;

        private void Awake()
        {
            _dialogueTrigger = GetComponent<DialogueTrigger>();
        }

        public virtual void Interact()
        {
            _dialogueTrigger.TriggerDialogue();
        }

        public InteractionType GetInteractionType()
        {
            return InteractionType.Examine;
        }
    }
}