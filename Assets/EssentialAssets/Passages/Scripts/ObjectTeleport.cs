using UnityEngine;
using System;
using System.Collections;
using EssentialAssets.Core;

namespace EssentialAssets.Passages
{
    public class ObjectTeleport : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform destination;

        private GameObject _player;
        private GameObject _objectToTeleport;

        public static event Action Teleporting;
        public static event Action DoneTeleporting;

        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        public IEnumerator Teleport(GameObject objectToTeleport)
        {
            Teleporting?.Invoke();
            yield return ScreenFader.Instance.ScreenFadeOut();
            objectToTeleport.transform.position = destination.position;
            yield return ScreenFader.Instance.ScreenFadeIn();
            DoneTeleporting?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(Teleport(other.gameObject));
        }

        public void Interact()
        {
            StartCoroutine(Teleport(_player));
        }

        public KeyCode GetInteractionPrompt()
        {
            return KeyCode.E;
        }
    }
}
