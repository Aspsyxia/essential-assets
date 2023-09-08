using System.Collections.Generic;
using Dialogue;
using Passages;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// Class that manages player's current status. It is important for things such as interactions.
    /// </summary>
    public class PlayerStatus: MonoBehaviour
    {
        private List<InputAction> _inputActions;

        private void Start()
        {
            SceneTransition.SceneChange += DisablePlayerControls;
            ObjectTeleport.Teleporting += DisablePlayerControls;
            ObjectTeleport.DoneTeleporting += EnablePlayerControls;
            DialogueManager.DialogueStart += DisablePlayerControls;
            DialogueManager.DialogueEnd += EnablePlayerControls;

            _inputActions = new List<InputAction>(FindObjectsOfType<InputAction>());
        }

        private void DisablePlayerControls()
        {
            foreach (var inputAction in _inputActions) inputAction.Disable();
        }

        private void EnablePlayerControls()
        {
            foreach (var inputAction in _inputActions) inputAction.Enable();
        }

        public void PlayerDie()
        {
            DisablePlayerControls();
        }
    }
}