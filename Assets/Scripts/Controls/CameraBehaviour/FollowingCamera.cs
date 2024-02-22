using UnityEngine;
using EssentialAssets.Utilities;

namespace EssentialAssets.Controls.CameraBehaviour
{
    public class FollowingCamera : InputAction
    {
        [Header("References")]
        [SerializeField] private Transform target;
        [SerializeField] private Transform pivot;
        [SerializeField] private Camera cameraObject;
        [SerializeField] private Vector3 offset;
        
        [Header("Rotation")] 
        [SerializeField][Range(0f, 360f)] private float maxUpRotation = 45f;
        [SerializeField] [Range(0f, 360f)] private float maxDownRotation = 345f;

        [Header("Collision")] 
        [SerializeField] private float collisionOffset = 0.2f;
        [SerializeField] private float adjustingSpeed = 5f;

        private Vector3 _targetRotation;
        private Quaternion _cameraRotation;
        private float _distance;

        private Vector3 _desiredPosition;
        private Quaternion _desiredRotation;
        
        private void Start()
        {
            SetupPivot();
            offset = target.position - transform.position;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        private void LateUpdate()
        {
            if (!IsActive) return;
            FollowTarget();
            RotateCamera();
            CameraCollision();
            MoveCameraToPosition();
        }

        private void FollowTarget()
        {
            transform.position = target.position - (_cameraRotation * offset);
            cameraObject.transform.LookAt(target);
        }

        private void RotateCamera()
        {
            var horizontal = Input.GetAxis("Mouse X") * Constants.MouseSensitivity;
            var vertical  = Input.GetAxis("Mouse Y") * Constants.MouseSensitivity;
            
            target.Rotate(0,horizontal,0);
            pivot.Rotate(-vertical,0,0);

            RotatePivot();

            var desiredYAngle = target.eulerAngles.y;
            var desiredXAngle = pivot.eulerAngles.x;
            
            _cameraRotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        }

        private void RotatePivot()
        {
            if (pivot.rotation.eulerAngles.x > maxUpRotation && pivot.rotation.eulerAngles.x < 180f)
            {
                pivot.rotation = Quaternion.Euler(maxUpRotation, 0, 0);
            }
            
            if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < maxDownRotation)
            {
                pivot.rotation = Quaternion.Euler(maxDownRotation, 0, 0);
            }
        }
        
        private void CameraCollision()
        {
            var position = pivot.position;
            _desiredPosition = position - (_cameraRotation * offset);
            
            var direction = _desiredPosition - position;
            var distance = direction.magnitude;
            
            if (Physics.SphereCast(pivot.position, 0.5f, direction, out var hit, distance))
            {
                if (hit.collider.gameObject != pivot.gameObject && hit.collider.gameObject != target.gameObject)
                {
                    if (!target.GetComponent<CharacterController>().isGrounded) return;
                    _desiredPosition = hit.point + hit.normal * collisionOffset;
                }
                else
                {
                    _desiredPosition = pivot.position;
                }
            }
            
            _desiredRotation = Quaternion.LookRotation(pivot.position - transform.position, Vector3.up);
        }
        
        private void MoveCameraToPosition()
        {
            var cameraTransform = cameraObject.transform;
            
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, _desiredPosition, Time.deltaTime * adjustingSpeed);
            cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, _desiredRotation, Time.deltaTime * adjustingSpeed);
        }

        private void SetupPivot()
        {
            var pivotTransform = pivot.transform;
            var targetTransform = target.transform;
            
            var parentPivotTransform = new Vector3(targetTransform.position.x, transform.position.y, targetTransform.position.z);
            pivotTransform.position = parentPivotTransform;
            pivotTransform.parent = targetTransform;
        }
    }
}


