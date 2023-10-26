using UnityEngine;

namespace EssentialAssets.Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue", order = 1)]
    public class Dialogue : ScriptableObject
    {
        public string[] dialogueContributors;
        public Sprite[] contributorsImages;
        public string[] sentences;
    }
}