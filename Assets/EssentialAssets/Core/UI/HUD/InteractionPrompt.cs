using UnityEngine;
using System;
using TMPro;

namespace EssentialAssets.Core
{
    /// <summary>
    /// Manages HUD element that shows up when interaction is possible
    /// </summary>
    public class InteractionPrompt: MonoBehaviour
    {
        [SerializeField] private GameObject interactionPromptObject;
        
        private TMP_Text _promptText;
        private void Start()
        {
            var interaction = FindObjectOfType<Interaction>();
            interaction.InteractionPossible += EnablePrompt;
            interaction.InteractionStop += ClearPrompt;
            
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