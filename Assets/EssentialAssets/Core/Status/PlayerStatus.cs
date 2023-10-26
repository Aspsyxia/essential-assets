using System.Collections.Generic;
using EssentialAssets.Dialogue;
using EssentialAssets.Passages;
using UnityEngine;

namespace EssentialAssets.Core
{
    /// <summary>
    /// Class that manages player's current status. It is important for things such as interactions.
    /// </summary>
    public class PlayerStatus: MonoBehaviour
    {
        private void Start()
        {
            SceneTransition.SceneChange += DisablePlayerControls;
            ObjectTeleport.Teleporting += DisablePlayerControls;
            ObjectTeleport.DoneTeleporting += EnablePlayerControls;
            FindObjectOfType<DialogueManager>().DialogueStart += DisablePlayerControls;
            FindObjectOfType<DialogueManager>().DialogueEnd += EnablePlayerControls;
        }

        public static void DisablePlayerControls()
        {
            var inputActions = new List<InputAction>(FindObjectsOfType<InputAction>());
            foreach (var inputAction in inputActions) inputAction.Disable();
        }

        public static void EnablePlayerControls()
        {
            var inputActions = new List<InputAction>(FindObjectsOfType<InputAction>());
            foreach (var inputAction in inputActions) inputAction.Enable();
        }
        
    }
}