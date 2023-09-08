using Controls;
using Core;
using UnityEngine;

namespace CameraBehaviour
{
    [RequireComponent(typeof(Camera))]
    public class HeadBobbing : InputAction
    {
        [Header("Specification"), Range(0, 3f)]
        [SerializeField] private float bobbingSpeed = 2.5f;
        [SerializeField] private float bobbingAmplitude = 0.05f;
    
        private FirstPersonControls _player;
        private float _timer;
        
        private void Start()
        {
            _player = GetComponentInParent<FirstPersonControls>();
        }

        private void Update () 
        {
            if (!IsActive) return;
            PerformHeadBob();
        }

        private void PerformHeadBob()
        {
            var waveSlice = 0f;
            var verticalInput = Mathf.Max(0, Input.GetAxis("Vertical"));
            var currentPosition = transform.localPosition;

            if (Mathf.Abs(verticalInput) == 0f)
            {
                _timer = 0f;
            }
            else
            {
                waveSlice = Mathf.Sin(_timer);
                _timer += bobbingSpeed * _player.MoveForwardSpeed * Time.deltaTime;
                if (_timer > Mathf.PI * 2f) _timer -= Mathf.PI * 2f;
            }

            if (waveSlice != 0f)
            {
                var translateChange = waveSlice * bobbingAmplitude * Mathf.Abs(verticalInput);
                currentPosition.y = _player.MiddlePoint + translateChange;
            }
            else
            {
                currentPosition.y = _player.MiddlePoint;
            }

            transform.localPosition =  currentPosition;
        }
    }
}