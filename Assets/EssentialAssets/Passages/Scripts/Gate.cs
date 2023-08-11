using Interaction;
using UnityEngine;

namespace Passages
{
    public class Passage : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            GetComponent<Animator>().SetTrigger("open");
            GetComponent<BoxCollider>().enabled = false;
        }

        public KeyCode GetInteractionPrompt()
        {
            return KeyCode.E;
        }
    }
}