using UnityEngine;
using EssentialAssets.Dialogue;
using EssentialAssets.Items;
using EssentialAssets.Core;

namespace Jigoku.Interaction
{
    [RequireComponent(typeof(DialogueTrigger))]
    public class Lock : MonoBehaviour, IInteractable
    {
        [SerializeField] private KeyItem keyItem;
        
        public void Interact()
        {
            if (keyItem.IsPicked())
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
