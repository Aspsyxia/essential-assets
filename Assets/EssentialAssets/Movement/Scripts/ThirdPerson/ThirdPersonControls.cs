using UnityEngine;

namespace EssentialAssets.Controls
{
    public class ThirdPersonControls : PlayerControls
    {
        [Header("References")]
        [SerializeField] private GameObject playerModel;
        
        private float _turnSmoothVelocity;
        private const float TurnSmoothTime = 0.1f;

        protected override void StandardControls()
        {
            var yTempTransform = MoveDirection.y;
            
            MoveDirection = transform.forward * VerticalInput + transform.right * HorizontalInput;
            MoveDirection = MoveDirection.normalized * moveForwardSpeed;
            MoveDirection.y = yTempTransform;
            
            GroundCheck();
            
            if (MoveDirection.x != 0f && MoveDirection.z != 0f) RotatePlayerModel();
            
            MoveDirection.y += (Physics.gravity.y * fallingSpeed);
            Controller.Move(MoveDirection * Time.deltaTime);
        }

        private void RotatePlayerModel()
        {
            var currentYRotation = playerModel.transform.rotation.eulerAngles.y;
            var targetYRotation = Mathf.Atan2(MoveDirection.x, MoveDirection.z) * Mathf.Rad2Deg;
            var newRotationY = Mathf.SmoothDampAngle(currentYRotation, targetYRotation, ref _turnSmoothVelocity, TurnSmoothTime);
            
            playerModel.transform.rotation = Quaternion.Euler(0f, newRotationY, 0f);
        }

        public override void Disable()
        {
            StartCoroutine(SmoothAnimationStop());
            base.Disable();
        }
        
        protected override void UpdateAnimation()
        {
            ObjectAnimator.SetFloat("forwardSpeed", Mathf.Abs(VerticalInput) + Mathf.Abs(HorizontalInput));
        }
    }
}