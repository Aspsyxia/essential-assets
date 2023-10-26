using UnityEngine;
using UnityEngine.SceneManagement;

namespace EssentialAssets.Core
{
    [RequireComponent(typeof(AudioSource))]

    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private int startingScene = 1;
        [SerializeField] private AudioClip clickEffect;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        /// <summary>
        /// Simply takes you to the starting scene.
        /// </summary>
        public void PlayGame()
        {
            SceneManager.LoadSceneAsync(startingScene);
        }

        /// <summary>
        /// Makes smooth transition to the next scene using screen fader.
        /// </summary>
        public void PlayGameTransition()
        {
            SceneTransition.TriggerSceneChange(startingScene);
        }

        public void MakeSoundEffect()
        {
            _audioSource.PlayOneShot(clickEffect);
        }
    }
}
