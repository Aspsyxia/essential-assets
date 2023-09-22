using UnityEngine;
using Core;

namespace Pickable
{
    public class Key: Pickable, IInteractable
    {
        public bool IsPicked { get; private set; }
        protected override void PickingBehaviour()
        {
            IsPicked = true;
            base.PickingBehaviour();
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