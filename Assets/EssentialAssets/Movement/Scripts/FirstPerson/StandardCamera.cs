using Core;
using UnityEngine;

namespace CameraBehaviour
{
    [RequireComponent(typeof(Camera))]
    public class StandardCamera : InputAction
    {
        [Header("Specification")]
        [SerializeField][Range(0, 360)] private float cameraAngleLimit = 90f;
        [SerializeField][Range(0f, 1f)] private float mouseSensitivity = 1f;

        private float _rotationY;
        private float _rotationX;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if(!IsActive) return;
            MoveCamera();
        }

        private void MoveCamera()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            
            _rotationY -= mouseY;
            _rotationX += mouseX;
            
            _rotationY = Mathf.Clamp(_rotationY, -cameraAngleLimit, cameraAngleLimit);
            
            transform.localRotation = Quaternion.Euler(Vector3.right *_rotationY) ;
            transform.parent.localRotation = Quaternion.Euler(Vector3.up * _rotationX);
        }
    }
}