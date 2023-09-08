using System.Collections;
using UnityEngine;

namespace Interaction
{
    /// <summary>
    /// Marks objects as doors that can be opened by interacting with them.
    /// </summary>
    public class Door : MonoBehaviour, IInteractable
    {
        [Header("Specification")]
        [SerializeField] private DoorType doorType;
        
        [Header("Slide door")]
        [SerializeField] private SlideDirection slideDirection;
        [SerializeField][Range(0f, 10f)] private float slideDistance;
        [SerializeField][Range(0f, 10f)] private float slideSpeed = 1.5f;

        [Header("Standard door")]
        [SerializeField][Range(0f, 360f)] private float openingAngle = 95f;
        [SerializeField][Range(0f, 50f)] private float openingSpeed = 1f;
        [SerializeField][Range(0f, 1f)] private float openingDelay = 0.1f;


        private bool _isOpen;

        private enum DoorType
        {
            Standard,
            Slide
        }
        
        private enum SlideDirection
        {
            Left,
            Right
        }
        
        private Vector3 _startPosition;
        private Vector3 _doorAngles;
        private Coroutine _activeCoroutine;

        private float _startAngle;
        private float _finalAngle;
        
        private void Start()
        {
            var doorTransform = transform;
            _startPosition = doorTransform.localPosition;
            _doorAngles = doorTransform.localEulerAngles;
            DetermineAngles();
        }

        private void DetermineOpeningAction()
        {
            _activeCoroutine = doorType switch
            {
                DoorType.Slide => StartCoroutine(SlideBehaviour()),
                DoorType.Standard => StartCoroutine(DetermineRotationDirection()),
                _ => _activeCoroutine
            };
        }

        private void DetermineAngles()
        {
            _startAngle = transform.localEulerAngles.y;
            if (_startAngle >= 0)
                _finalAngle = _startAngle + openingAngle;
            else
                _finalAngle = _startAngle - openingAngle;
        }

        private IEnumerator DetermineRotationDirection()
        {
            if (_isOpen) yield return RotateToClose();
            else yield return RotateToOpen();
        }
        
        private IEnumerator RotateToOpen()
        {
            _isOpen = true;
            while (_doorAngles.y < _finalAngle)
            {
                _doorAngles.y += openingSpeed;
                transform.rotation = Quaternion.Euler(_doorAngles);
                yield return new WaitForSeconds(openingDelay * Time.deltaTime);
            }
        }

        private IEnumerator RotateToClose()
        {
            _isOpen = false;
            while (_doorAngles.y > _startAngle)
            {
                _doorAngles.y -= openingSpeed;
                transform.rotation = Quaternion.Euler(_doorAngles);
                yield return new WaitForSeconds(openingDelay * Time.deltaTime);
            }
        }
        
        private IEnumerator SlideBehaviour()
        {
            var endPosition = DetermineEndPosition();
            _isOpen = !_isOpen;
            
            while (transform.localPosition != endPosition)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPosition, slideSpeed * Time.deltaTime);
                yield return null;
            }
        }

        private Vector3 DetermineEndPosition()
        {
            Vector3 endPosition = new Vector3(0,0,0);
            
            endPosition = slideDirection switch
            {
                SlideDirection.Left when _isOpen => _startPosition,
                SlideDirection.Left => _startPosition + transform.TransformDirection(Vector3.left) * slideDistance,
                SlideDirection.Right when _isOpen => _startPosition,
                SlideDirection.Right =>  _startPosition + transform.TransformDirection(Vector3.right) * slideDistance,
                _ => endPosition
            };

            return endPosition;
        }

        public void Interact()
        {
            if(_activeCoroutine != null) StopAllCoroutines();
            DetermineOpeningAction();
        }

        public KeyCode GetInteractionPrompt()
        {
            return KeyCode.E;
        }
    }
}