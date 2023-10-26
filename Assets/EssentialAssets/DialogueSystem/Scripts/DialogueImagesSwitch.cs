using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EssentialAssets.Dialogue
{
    public class DialogueImagesSwitch : MonoBehaviour
    {
        [SerializeField] private Image image;
        
        private List<Sprite> _dialogueContributorsImages;

        private void Start()
        {
            FindObjectOfType<DialogueManager>().PassDialogue += LoadImages;
            FindObjectOfType<DialogueManager>().ImageSwitch += ChangeCorrespondingImage;
        }

        private void LoadImages(Dialogue dialogue)
        {
            _dialogueContributorsImages = new List<Sprite>(dialogue.contributorsImages);
        }

        private void ChangeCorrespondingImage(int imageIndex)
        {
            image.sprite = _dialogueContributorsImages[imageIndex];
        }
    }
}