using UnityEngine;
using Core;

namespace Passages
{
    public class ScenePortal: MonoBehaviour, IInteractable
    {
        [SerializeField] private int nextSceneIndex;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SceneTransition.TriggerSceneChange(nextSceneIndex);
            }
        }

        public void Interact()
        {
            SceneTransition.TriggerSceneChange(nextSceneIndex);
        }

        public KeyCode GetInteractionPrompt()
        {
            return KeyCode.E;
        }
    }
}