using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private Image image;
        [SerializeField] private Canvas dialogueCanvas;
        
        [Header("Specification")]
        [SerializeField] private float typeSpeedDelay = 0.05f;
        [SerializeField] private bool dialogueWithImages;
        
        private Queue<string> _sentences;
        private List<string> _dialogueContributors;
        private List<Sprite> _dialogueContributorsImages;
        private Coroutine _activeCoroutine;
        private PlayerStatus _player;

        private void Start()
        {
            _sentences = new Queue<string>();
            dialogueCanvas.enabled = false;
            _player = FindObjectOfType<PlayerStatus>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            DialoguePreActions(true);
            _activeCoroutine = StartCoroutine(PrepareDialogueDisplay(dialogue));
        }
        
        public void StartDialogue(Dialogue dialogue, int state)
        {
            DialoguePreActions(true);
            _activeCoroutine = StartCoroutine(PrepareDialogueDisplay(dialogue, state));
        }

        public void StartTip(Dialogue dialogue)
        {
            DialoguePreActions(false);
            
            foreach (var sentence in dialogue.sentences) _sentences.Enqueue(sentence);
            nameText.text = dialogue.dialogueContributors[0];
            image.sprite = dialogue.contributorsImages[0];
            
            _activeCoroutine = StartCoroutine(DisplayTip());
        }
        
        private void DialoguePreActions(bool playerStop)
        {
            if (_activeCoroutine != null) StopAllCoroutines();
            _sentences.Clear();
            dialogueCanvas.enabled = true;
            if (playerStop) _player.DisablePlayerControls();
        }
        
        private IEnumerator PrepareDialogueDisplay(Dialogue dialogue)
        {
            foreach (var sentence in dialogue.sentences) _sentences.Enqueue(sentence);
            _dialogueContributors = new List<string>(dialogue.dialogueContributors);
            _dialogueContributorsImages = new List<Sprite>(dialogue.contributorsImages);
            yield return DisplayDialogue();
        }
        
        private IEnumerator PrepareDialogueDisplay(Dialogue dialogue, int state)
        {
            var sentence = dialogue.sentences[state];
            nameText.text = dialogue.dialogueContributors[0];
            image.sprite = dialogue.contributorsImages[0];
            yield return TypeOneSentence(sentence);
        }
        
        IEnumerator DisplayDialogue()
        {
            while (_sentences.Count != 0)
            {
                var sentence = _sentences.Dequeue();
                var sentenceInfo = sentence.Split(';');
                nameText.text = _dialogueContributors[int.Parse(sentenceInfo[1])];
                image.sprite = _dialogueContributorsImages[int.Parse(sentenceInfo[1])];
                yield return TypeSentence(sentenceInfo[0]);
                yield return new WaitUntil(() => DialogueLineSkip());
            }
            
            EndDialogue();
        }

        IEnumerator DisplayTip()
        {
            var sentence = _sentences.Dequeue();
            yield return TypeSentence(sentence);
            yield return new WaitForSeconds(3f);
            dialogueCanvas.enabled = false;
        }

        private IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = string.Empty;

            foreach (var letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSecondsRealtime(typeSpeedDelay);
                
                if (!Input.GetKeyDown(KeyCode.Space)) continue;
                dialogueText.text = sentence;
                break;
            }
        }

        private IEnumerator TypeOneSentence(string sentence)
        {
            yield return TypeSentence(sentence);
            yield return new WaitUntil(() => DialogueLineSkip());
            dialogueText.text = string.Empty;
            EndDialogue();
        }

        private void EndDialogue()
        {
            dialogueCanvas.enabled = false;
            _player.EnablePlayerControls();
        }

        private static bool DialogueLineSkip()
        {
            return Input.GetKeyDown(KeyCode.E);
        }
    }
}