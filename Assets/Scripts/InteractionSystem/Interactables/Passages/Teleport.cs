using UnityEngine;
using System;
using System.Collections;
using EssentialAssets.InteractionSystem;

namespace EssentialAssets.Passages
{
    public class Teleport : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform destination;

        private GameObject _player;
        private GameObject _objectToTeleport;

        public static event Action Teleporting;
        public static event Action DoneTeleporting;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private IEnumerator TeleportObject(GameObject objectToTeleport)
        {
            Teleporting?.Invoke();
            yield return SystemsManager.Instance.fader.ScreenFadeOut();
            objectToTeleport.transform.position = destination.position;
            yield return SystemsManager.Instance.fader.ScreenFadeIn();
            DoneTeleporting?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(TeleportObject(other.gameObject));
        }

        public void Interact()
        {
            StartCoroutine(TeleportObject(_player));
        }

        public InteractionType GetInteractionType()
        {
            return InteractionType.Examine;
        }
    }
}
