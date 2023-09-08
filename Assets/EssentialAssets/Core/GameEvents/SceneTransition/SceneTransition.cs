using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneTransition: MonoBehaviour
    {
        private static SceneTransition _instance;
        public static event Action SceneChange;

        private void Awake()
        {
            if (_instance != null) return;
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public static void TriggerSceneChange(int nextSceneIndex)
        {
            SceneChange?.Invoke();
            _instance.StartCoroutine(ChangeScene(nextSceneIndex));
        }
        
        private static IEnumerator ChangeScene(int nextSceneIndex)
        {
            yield return ScreenFader.Instance.ScreenFadeIn();
            yield return SceneManager.LoadSceneAsync(nextSceneIndex);
            yield return ScreenFader.Instance.ScreenFadeOut();
        }
    }
}