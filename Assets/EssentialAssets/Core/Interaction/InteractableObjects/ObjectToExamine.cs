using UnityEngine;
using EssentialAssets.Dialogue;

namespace EssentialAssets.Core
{
    [RequireComponent(typeof(DialogueTrigger))]
    public class ObjectToExamine: MonoBehaviour, IInteractable
    {
        public virtual void Interact()
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }

        public KeyCode GetInteractionPrompt()
        {
            return KeyCode.E;
        }
    }
}