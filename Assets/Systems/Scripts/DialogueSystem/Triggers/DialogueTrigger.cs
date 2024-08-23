using EssentialAssets.InteractionSystem;
using UnityEngine;
using EssentialAssets.Utilities;

namespace EssentialAssets.DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] protected Dialogue dialogue;

        [Header("Specification")] 
        [SerializeField] protected DialogueType type;
        [SerializeField] protected bool oneTime;
        
        protected enum DialogueType
        {
            Dialogue,
            Tip
        }
        
        public void TriggerDialogue()
        {
            switch (type)
            {
                case DialogueType.Dialogue:
                    SystemsManager.Instance.dialogueManager.StartDialogue(dialogue);
                    break;
                case DialogueType.Tip:
                    SystemsManager.Instance.dialogueManager.StartTip(dialogue);
                    break;
            }

            if (oneTime) GetComponent<InteractableObject>().enabled = false;
        }
        
        public void TriggerDialogue(int state)
        {
            SystemsManager.Instance.dialogueManager.StartStateDialogue(dialogue, state);
        }
    }
}