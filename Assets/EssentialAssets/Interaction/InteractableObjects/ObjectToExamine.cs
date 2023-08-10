using Dialogue;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(DialogueTrigger))]
    public class ObjectToExamine: MonoBehaviour, IInteractable
    {
        public virtual void Interact()
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }

        public void GetInteractionPrompt()
        {
            throw new System.NotImplementedException();
        }
    }
}