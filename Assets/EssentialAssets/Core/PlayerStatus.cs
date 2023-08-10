using System.Collections.Generic;
using CameraBehaviour;
using UnityEngine;

namespace Core
{
    public class PlayerStatus: MonoBehaviour
    {
        [SerializeField] private PlayerPerspective perspective;

        private enum PlayerPerspective
        {
            FirstPerson,
            ThirdPerson,
            FixedAngles
        }

        private List<InputAction> _inputActions;

        private void Start()
        {
            _inputActions = perspective switch
            {
                PlayerPerspective.FirstPerson => new List<InputAction>(GetComponents<InputAction>()) {FindObjectOfType<HeadBobbing>()},
                PlayerPerspective.ThirdPerson => new List<InputAction>(GetComponents<InputAction>()) {FindObjectOfType<CameraFollow>()},
                PlayerPerspective.FixedAngles => new List<InputAction>(GetComponents<InputAction>()),
                _ => _inputActions
            };
        }

        public void DisablePlayerControls()
        {
            foreach (var inputAction in _inputActions) inputAction.Disable();
        }

        public void EnablePlayerControls()
        {
            foreach (var inputAction in _inputActions) inputAction.Enable();
        }

        public void PlayerDie()
        {
            //settrigger(deatH)
            DisablePlayerControls();
        }
    }
}