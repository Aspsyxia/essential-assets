using UnityEngine;
using EssentialAssets.Utilities;

namespace EssentialAssets.Controls.CameraBehaviour
{
    [RequireComponent(typeof(Camera))]
    public class TankCamera : InputAction
    {
        [Header("Values"), Min(0)]
        [SerializeField] private float cameraAngleLimit = 80f;

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
            var mouseX = Input.GetAxis("Mouse X") * Constants.MouseSensitivity;
            var mouseY = Input.GetAxis("Mouse Y") * Constants.MouseSensitivity;

            _xRotation -= mouseY;
            _yRotation += mouseX;

            _xRotation = Mathf.Clamp(_xRotation, -cameraAngleLimit, cameraAngleLimit);
            _yRotation = Mathf.Clamp(_yRotation, -cameraAngleLimit, cameraAngleLimit);

            transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        }
    }
    
    
}