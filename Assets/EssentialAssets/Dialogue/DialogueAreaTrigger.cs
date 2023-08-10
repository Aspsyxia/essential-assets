﻿using UnityEngine;

namespace Dialogue
{
    public class DialogueAreaTrigger : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private Dialogue dialogue;

        [Header("Specification")] 
        [SerializeField] private DialogueType type;
        [SerializeField] private bool oneTime = true;

        private bool _isActive = true;
        private enum DialogueType
        {
            Dialogue,
            Tip
        }
        
        private void TriggerDialogue()
        {
            switch (type)
            {
                case DialogueType.Dialogue:
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    break;
                case DialogueType.Tip:
                    FindObjectOfType<DialogueManager>().StartTip(dialogue); 
                    gameObject.GetComponent<Collider>().enabled = false;
                    break;
            }
            
            if (oneTime) gameObject.SetActive(false);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player") || !_isActive) return;
            _isActive = false;
            TriggerDialogue();
        }

        private void OnTriggerExit(Collider other)
        {
            if(!other.CompareTag("Player")) return;
            _isActive = true;
        }
    }
}