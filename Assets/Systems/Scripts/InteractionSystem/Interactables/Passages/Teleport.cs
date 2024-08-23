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

        public static event Action Teleporting;
        public static event Action DoneTeleporting;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(TeleportObject(other.gameObject));
        }

        private IEnumerator TeleportObject(GameObject objectToTeleport)
        {
            Teleporting?.Invoke();
            yield return SystemsManager.Instance.screenOverlay.ScreenFadeOut(2f);

            objectToTeleport.transform.position = destination.position;

            yield return SystemsManager.Instance.screenOverlay.ScreenFadeIn(2f);
            DoneTeleporting?.Invoke();
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
