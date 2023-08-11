using Dialogue;
using Interaction;
using Pickable;
using UnityEngine;

namespace Jigoku.Interaction
{
    [RequireComponent(typeof(DialogueTrigger))]
    public class Lock : MonoBehaviour, IInteractable
    {
        [SerializeField] private Key key;
        
        public void Interact()
        {
            if (key.IsPicked)
            {
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<DialogueTrigger>().TriggerDialogue(1);
            }
            else
            {
                GetComponent<DialogueTrigger>().TriggerDialogue(0);
            }
        }

        public KeyCode GetInteractionPrompt()
        {
            return KeyCode.E;
        }
    }
}
