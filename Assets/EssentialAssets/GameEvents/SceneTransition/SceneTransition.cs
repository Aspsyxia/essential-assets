using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core
{
    public class SceneTransition: MonoBehaviour
    {
        private Fader _fader;
        private static Image _screenOverlay;
        private static SceneTransition _instance;
        public static event Action SceneChange;

        private void Awake()
        {
            if (_instance != null) return;
            _instance = this;
            _screenOverlay = GetComponentInChildren<Image>();
            _fader = GetComponent<Fader>();
            DontDestroyOnLoad(gameObject);
        }

        public static void TriggerSceneChange(int nextSceneIndex)
        {
            SceneChange?.Invoke();
            _instance.StartCoroutine(ChangeScene(nextSceneIndex));
        }
        
        private static IEnumerator ChangeScene(int nextSceneIndex)
        {
            yield return _instance._fader.FadeIn(_screenOverlay);
            yield return SceneManager.LoadSceneAsync(nextSceneIndex);
            yield return _instance._fader.FadeOut(_screenOverlay);
        }
    }
}