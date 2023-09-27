using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueManager : CanvasBasedLayout
    {
        [Header("References")]
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text dialogueText;

        [Header("Specification")]
        [SerializeField] private float typeSpeedDelay = 0.05f;
        [SerializeField] private bool dialogueWithImages;
        
        private Queue<string> _sentences;
        private List<string> _dialogueContributors;
        
        private Coroutine _activeCoroutine;
        
        public static event Action DialogueStart;
        public static event Action DialogueEnd;
        
        internal static event Action<Dialogue> PassDialogue;
        internal static event Action<int> ImageSwitch;

        private void Start()
        {
            _sentences = new Queue<string>();
            ToggleLayout(false);
        }

        public void StartDialogue(Dialogue dialogue)
        {
            DialoguePreActions(dialogue, true);
            _activeCoroutine = StartCoroutine(PrepareDialogueDisplay(dialogue));
        }
        
        public void StartStateDialogue(Dialogue dialogue, int state)
        {
            DialoguePreActions(dialogue, true);
            _activeCoroutine = StartCoroutine(PrepareStateDialogueDisplay(dialogue, state));
        }

        public void StartTip(Dialogue dialogue)
        {
            DialoguePreActions(dialogue, false);
            foreach (var sentence in dialogue.sentences) _sentences.Enqueue(sentence);
            nameText.text = dialogue.dialogueContributors[0];
            if (dialogueWithImages) ImageSwitch?.Invoke(0);
            _activeCoroutine = StartCoroutine(DisplayTip());
        }
        
        private void DialoguePreActions(Dialogue dialogue, bool playerStop)
        {
            if (_activeCoroutine != null) StopAllCoroutines();
            _sentences.Clear();
            ToggleLayout(true);
            PassDialogue?.Invoke(dialogue);
            if (playerStop) DialogueStart?.Invoke();
        }
        
        private IEnumerator PrepareDialogueDisplay(Dialogue dialogue)
        {
            foreach (var sentence in dialogue.sentences) _sentences.Enqueue(sentence);
            _dialogueContributors = new List<string>(dialogue.dialogueContributors);
            yield return DisplayDialogue();
        }
        
        private IEnumerator PrepareStateDialogueDisplay(Dialogue dialogue, int state)
        {
            var sentence = dialogue.sentences[state];
            nameText.text = dialogue.dialogueContributors[0];
            if (dialogueWithImages) ImageSwitch?.Invoke(0);
            yield return TypeOneSentence(sentence);
        }
        
        IEnumerator DisplayDialogue()
        {
            while (_sentences.Count != 0)
            {
                var sentence = _sentences.Dequeue();
                var sentenceInfo = sentence.Split(';');
                nameText.text = _dialogueContributors[int.Parse(sentenceInfo[1])];
                if (dialogueWithImages) ImageSwitch?.Invoke(int.Parse(sentenceInfo[1]));
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
            ToggleLayout(false);
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
            ToggleLayout(false);
            DialogueEnd?.Invoke();
        }

        private static bool DialogueLineSkip()
        {
            return Input.GetKeyDown(KeyCode.E);
        }

        private void ToggleLayout(bool state)
        {
            IsActive = state;
            layoutCanvas.enabled = state;
        }
    }
}