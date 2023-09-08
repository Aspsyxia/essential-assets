using Core;
using UnityEngine;

namespace CameraBehaviour
{
    [RequireComponent(typeof(Camera))]
    public class TankCamera : InputAction
    {
        [Header("Values"), Min(0)]
        [SerializeField] private float cameraAngleLimit = 80f;
        [SerializeField] private float mouseSensitivity = 3f;

        private float _xRotation;
        private float _yRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (!IsActive) return;
            MoveCamera();
        }

        private void MoveCamera()
        {
            var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            _xRotation -= mouseY;
            _yRotation += mouseX;

            _xRotation = Mathf.Clamp(_xRotation, -cameraAngleLimit, cameraAngleLimit);
            _yRotation = Mathf.Clamp(_yRotation, -cameraAngleLimit, cameraAngleLimit);

            transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        }
    }
    
    
}