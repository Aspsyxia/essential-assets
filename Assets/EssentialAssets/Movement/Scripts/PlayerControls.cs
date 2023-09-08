using System;
using System.Collections;
using Core;
using UnityEngine;

namespace Controls
{
    [RequireComponent(typeof(CharacterController), typeof(Animator))]
    public class PlayerControls: InputAction
    {
        [Header("Basic specification")]
        [SerializeField] protected float moveForwardSpeed = 5f;
        [SerializeField] protected float moveBackSpeed = 0.5f;
        [SerializeField] protected float rotateSpeed = 90f;
        [SerializeField] protected bool tankControls = false;
        
        [Header("Jumping Specification")]
        [SerializeField] protected float jumpingHeight = 10f;
        [SerializeField] protected float fallingSpeed;
        
        protected CharacterController Controller;
        protected Animator ObjectAnimator;
        protected Vector3 MoveDirection;
        protected float Gravity;
        protected float VerticalInput;
        protected float HorizontalInput;
        public float MoveForwardSpeed => moveForwardSpeed;
        public float MoveBackSpeed => moveBackSpeed;
        public bool UsingTankControls => tankControls;
        
        protected virtual void Start()
        {
            Controller = GetComponent<CharacterController>();
            ObjectAnimator = GetComponent<Animator>();
            moveBackSpeed = -moveBackSpeed;
        }

        protected virtual void Update()
        {
            if (!IsActive) return;
            VerticalInput = Input.GetAxis("Vertical");
            HorizontalInput = Input.GetAxis("Horizontal");
            MovePlayer();
            UpdateAnimation();
        }

        protected virtual void MovePlayer()
        {
            if (tankControls) TankControls();
            else StandardControls();
        }

        protected virtual void StandardControls()
        {
            Debug.Log("Standard controls");
        }

        private void TankControls()
        {
            CalculateGravity();
            
            var moveForward = Mathf.Max(moveBackSpeed, VerticalInput) * moveForwardSpeed * Time.deltaTime;
            var rotateAround = HorizontalInput * rotateSpeed * Time.deltaTime;
            
            MoveDirection = transform.TransformDirection(new Vector3(0f, Gravity * Time.deltaTime, moveForward));
            Controller.Move(MoveDirection);
            transform.Rotate(0f, rotateAround, 0f);
        }
        
        protected void CalculateGravity()
        {
            if (Controller.isGrounded && Gravity < 0f) Gravity = Physics.gravity.y;
            Gravity += Physics.gravity.y * Time.deltaTime;
        }

        protected void GroundCheck()
        {
            if (!Controller.isGrounded) return;
            
            MoveDirection.y = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        private void Jump()
        {
            MoveDirection.y = jumpingHeight;
        }
        
        protected virtual void UpdateAnimation()
        {
            Debug.Log("Updates player animation");
        }
        
        protected IEnumerator SmoothAnimationStop()
        {
            while (ObjectAnimator.GetFloat("forwardSpeed") > 0)
            {
                ObjectAnimator.SetFloat("forwardSpeed", ObjectAnimator.GetFloat("forwardSpeed") - 0.1f);
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}