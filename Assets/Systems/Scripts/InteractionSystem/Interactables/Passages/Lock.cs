using UnityEngine;
using EssentialAssets.DialogueSystem;
using EssentialAssets.Items;

namespace EssentialAssets.InteractionSystem
{
    [RequireComponent(typeof(DialogueTrigger))]
    public class Lock : MonoBehaviour, IInteractable
    {
        [SerializeField] private KeyItem keyItem;

        private DialogueTrigger _dialogueTrigger;

        private void Awake()
        {
            _dialogueTrigger = GetComponent<DialogueTrigger>();
        }

        public void Interact()
        {
            if (keyItem.IsPicked())
            {
                GetComponent<BoxCollider>().enabled = false;
                _dialogueTrigger.TriggerDialogue(1);
            }
            else
            {
                _dialogueTrigger.TriggerDialogue(0);
            }
        }

        public InteractionType GetInteractionType()
        {
            return InteractionType.Examine;
        }
    }
}
