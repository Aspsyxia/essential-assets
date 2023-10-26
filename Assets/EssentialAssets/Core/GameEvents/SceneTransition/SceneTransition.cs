using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EssentialAssets.Core
{
    public class SceneTransition: MonoBehaviour
    {
        private static SceneTransition _instance;
        public static event Action SceneChange;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public static void TriggerSceneChange(int nextSceneIndex)
        {
            SceneChange?.Invoke();
            _instance.StartCoroutine(ChangeScene(nextSceneIndex));
        }

        public static void InstantReload()
        {
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
            DisableGameplayConstrains();
        }
        
        private static IEnumerator ChangeScene(int nextSceneIndex)
        {
            yield return ScreenFader.Instance.ScreenFadeOut();
            yield return SceneManager.LoadSceneAsync(nextSceneIndex);
            DisableGameplayConstrains();
            yield return ScreenFader.Instance.ScreenFadeIn();
        }

        private static void DisableGameplayConstrains()
        {
            // Time.timeScale = 1;
            // PlayerStatus.EnablePlayerControls();
        }
    }
}