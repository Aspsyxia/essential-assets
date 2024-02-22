using UnityEngine;
using UnityEngine.SceneManagement;

namespace EssentialAssets.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private int startingScene = 1;
        
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        /// <summary>
        /// Quits application.
        /// </summary>
        public void ExitGame()
        {
            Application.Quit();
        }

        /// <summary>
        /// Immediately takes you to the first scene.
        /// </summary>
        public void PlayGame()
        {
            SceneManager.LoadSceneAsync(startingScene);
        }

        /// <summary>
        /// Makes smooth transition to the next scene using fader.
        /// </summary>
        public void PlayGameTransition()
        {
            SystemsManager.Instance.sceneTransition.TriggerSceneChange(startingScene);
        }

        public void PlayMenuButtonSoundEffect()
        {
            SystemsManager.Instance.soundManager.PlayButtonClickEffect();
        }
    }
}
