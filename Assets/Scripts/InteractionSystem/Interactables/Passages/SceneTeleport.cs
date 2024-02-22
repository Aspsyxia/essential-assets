﻿using EssentialAssets.InteractionSystem;
using UnityEngine;

namespace EssentialAssets.Passages
{
    public class SceneTeleport: MonoBehaviour, IInteractable
    {
        [SerializeField] private int nextSceneIndex;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SystemsManager.Instance.sceneTransition.TriggerSceneChange(nextSceneIndex);
            }
        }

        public void Interact()
        {
            SystemsManager.Instance.sceneTransition.TriggerSceneChange(nextSceneIndex);
        }

        public InteractionType GetInteractionType()
        {
            return InteractionType.Examine;
        }
    }
}