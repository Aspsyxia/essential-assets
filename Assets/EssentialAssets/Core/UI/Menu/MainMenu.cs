using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
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

        public void PlayGame()
        {
            SceneManager.LoadSceneAsync(startingScene);
        }

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
