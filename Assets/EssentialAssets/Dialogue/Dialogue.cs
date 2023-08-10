using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue", order = 1)]
    public class Dialogue : ScriptableObject
    {
        public string[] dialogueContributors;
        public string[] sentences;
        public Sprite[] contributorsImages;
    }
}