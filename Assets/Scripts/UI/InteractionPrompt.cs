using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using EssentialAssets.InteractionSystem;

namespace EssentialAssets.UI
{
    /// <summary>
    /// Manages HUD element that informs when interaction is possible.
    /// </summary>
    public class InteractionPrompt: MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text promptText;
        [SerializeField] private Image interactionImage;

        private void Awake()
        {
            ClearPrompt();
        }

        public void EnablePrompt(InteractionData data)
        {
            interactionImage.gameObject.SetActive(true);
            promptText.text = data.InteractionLabel;
        }

        public void ClearPrompt()
        {
            interactionImage.gameObject.SetActive(false);
            promptText.text = String.Empty;
        }
    }
}