using EssentialAssets.Core;
using UnityEngine;

namespace EssentialAssets.Items
{
    public class Pickable : MonoBehaviour, IInteractable
    {
        protected void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            PickingBehaviour();
        }

        protected virtual void PickingBehaviour()
        {
            HideObject();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }

        public void Interact()
        {
            PickingBehaviour();
        }

        public KeyCode GetInteractionPrompt()
        {
            return KeyCode.E;
        }
    }
}