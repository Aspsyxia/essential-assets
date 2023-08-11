using UnityEngine;
using Interaction;

namespace Dialogue
{
    public class DialogueTrigger : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private Dialogue dialogue;

        [Header("Specification")] 
        [SerializeField] private DialogueType type;
        [SerializeField] private bool oneTime;
        
        private DialogueManager _manager;

        private enum DialogueType
        {
            Dialogue,
            Tip
        }
        
        private void Start()
        {
            _manager = FindObjectOfType<DialogueManager>();
        }
        
        public void TriggerDialogue()
        {
            switch (type)
            {
                case DialogueType.Dialogue:
                    _manager.StartDialogue(dialogue);
                    break;
                case DialogueType.Tip:
                    _manager.StartTip(dialogue);
                    break;
            }

            if (oneTime) GetComponent<ObjectToExamine>().enabled = false;
        }
        
        public void TriggerDialogue(int state)
        {
            _manager.StartDialogue(dialogue, state);
        }
    }
}