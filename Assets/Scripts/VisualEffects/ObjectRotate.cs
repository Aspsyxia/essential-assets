using UnityEngine;

namespace EssentialAssets.VisualEffects
{
    public class ObjectRotate : MonoBehaviour
    {
        [SerializeField] private Axis axis;
        [SerializeField] private float rotatingSpeed = 5f;

        private enum Axis
        {
            X,
            Y,
            Z
        }

        private Quaternion _initialRotation;
        private Quaternion _newRotation = Quaternion.identity; // Initialize _newRotation

        private void Start()
        {
            _initialRotation = transform.rotation;
        }

        private void Update()
        {
            switch (axis)
            {
                case Axis.X:
                    _newRotation *= Quaternion.Euler(rotatingSpeed * Time.deltaTime, 0f, 0f);
                    break;
                case Axis.Y:
                    _newRotation *= Quaternion.Euler(0f, rotatingSpeed * Time.deltaTime, 0f);
                    break;
                case Axis.Z:
                    _newRotation *= Quaternion.Euler(0f, 0f, rotatingSpeed * Time.deltaTime);
                    break;
            }

            transform.rotation = _initialRotation * _newRotation;
        }
    }
}