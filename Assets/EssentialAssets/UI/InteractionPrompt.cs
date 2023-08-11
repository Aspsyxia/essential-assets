﻿using System;
using TMPro;
using UnityEngine;

namespace EssentialAssets.UI
{
    public class InteractionPrompt: MonoBehaviour
    {
        [SerializeField] private GameObject interactionPromptObject;
        
        private TMP_Text _promptText;
        private void Start()
        {
            Interaction.Interaction.InteractionPossible += EnablePrompt;
            Interaction.Interaction.InteractionStop += ClearPrompt;
            
            _promptText = interactionPromptObject.GetComponentInChildren<TMP_Text>();
            ClearPrompt();
        }

        private void EnablePrompt(string prompt)
        {
            _promptText.text = prompt;
            interactionPromptObject.SetActive(true);
        }

        private void ClearPrompt()
        {
            _promptText.text = String.Empty;
            interactionPromptObject.SetActive(false);
        }
    }
}