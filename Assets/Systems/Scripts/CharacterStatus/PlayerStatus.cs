using System.Collections.Generic;
using EssentialAssets.Utilities;
using EssentialAssets.Passages;
using UnityEngine;

namespace EssentialAssets.Status
{
    /// <summary>
    /// Class that manages player's current status.
    /// </summary>
    public class PlayerStatus : MonoBehaviour
    {
        private void Start()
        {
            SubscribeEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
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

        private void SubscribeEvents()
        {
            SystemsManager.Instance.sceneTransitionManager.SceneChange += DisablePlayerControls;
            Teleport.Teleporting += DisablePlayerControls;
            Teleport.DoneTeleporting += EnablePlayerControls;
            SystemsManager.Instance.dialogueManager.DialogueStart += DisablePlayerControls;
            SystemsManager.Instance.dialogueManager.DialogueEnd += EnablePlayerControls;
        }

        private void UnsubscribeEvents()
        {
            SystemsManager.Instance.sceneTransitionManager.SceneChange -= DisablePlayerControls;
            Teleport.Teleporting -= DisablePlayerControls;
            Teleport.DoneTeleporting -= EnablePlayerControls;
            SystemsManager.Instance.dialogueManager.DialogueStart -= DisablePlayerControls;
            SystemsManager.Instance.dialogueManager.DialogueEnd -= EnablePlayerControls;
        }
    }
}