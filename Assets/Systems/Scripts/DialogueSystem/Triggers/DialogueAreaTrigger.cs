using UnityEngine;

namespace EssentialAssets.DialogueSystem
{
    public class DialogueAreaTrigger : DialogueTrigger
    {
        private bool _canBeTriggered = true;
        
        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player") || !_canBeTriggered) return;
            _canBeTriggered = false;
            TriggerDialogue();
        }

        private void OnTriggerExit(Collider other)
        {
            if(!other.CompareTag("Player")) return;
            _canBeTriggered = true;
        }
    }
}