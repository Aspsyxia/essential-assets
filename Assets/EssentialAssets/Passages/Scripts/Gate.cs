using Interaction;
using UnityEngine;

namespace Passages
{
    /// <summary>
    /// A type of passage that allows to add specific opening animation.
    /// </summary>
    public class UniquePassage : MonoBehaviour, IInteractable
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