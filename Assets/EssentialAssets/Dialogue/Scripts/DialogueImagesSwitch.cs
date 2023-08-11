using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    public class DialogueImagesSwitch : MonoBehaviour
    {
        [SerializeField] private Image image;
        
        private List<Sprite> _dialogueContributorsImages;

        private void Start()
        {
            DialogueManager.PassDialogue += LoadImages;
            DialogueManager.ImageSwitch += ChangeCorrespondingImage;
        }

        private void LoadImages(Dialogue dialogue)
        {
            _dialogueContributorsImages = new List<Sprite>(dialogue.contributorsImages);
        }

        public void ChangeCorrespondingImage(int imageIndex)
        {
            image.sprite = _dialogueContributorsImages[imageIndex];
        }
    }
}