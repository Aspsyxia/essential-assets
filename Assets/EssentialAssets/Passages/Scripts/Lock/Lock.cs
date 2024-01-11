using System;
using UnityEngine;
using EssentialAssets.Dialogue;
using EssentialAssets.Items;
using EssentialAssets.Core;

namespace EssentialAssets.Interaction
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

        public KeyCode GetInteractionPrompt()
        {
            return KeyCode.E;
        }
    }
}
