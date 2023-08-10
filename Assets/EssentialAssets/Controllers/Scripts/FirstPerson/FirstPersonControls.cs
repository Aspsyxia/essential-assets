using UnityEngine;

namespace Controls
{
    public class FirstPersonControls : PlayerControls
    {
        [Header("References")]
        [SerializeField] private Camera playerCamera;
        
        private Vector3 _middlePoint;
        public float MiddlePoint => _middlePoint.y;

        private void Awake()
        {
            _middlePoint = playerCamera.transform.localPosition;
        }

        protected override void StandardControls()
        {
            CalculateGravity();
            
            float moveForward = VerticalInput * moveSpeed * Time.deltaTime;
            float moveSideways = HorizontalInput * moveSpeed * Time.deltaTime;
            var movement = new Vector3(moveSideways, Gravity * Time.deltaTime, moveForward);
            
            Controller.Move(transform.TransformDirection(movement));
        }
        
        protected override void UpdateAnimation()
        {
            ObjectAnimator.SetFloat("forwardSpeed", VerticalInput);
            ObjectAnimator.SetFloat("sideSpeed", Mathf.Abs(HorizontalInput));
        }
    }
}