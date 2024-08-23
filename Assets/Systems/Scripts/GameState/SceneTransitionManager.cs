using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EssentialAssets.GameState
{
    public class SceneTransitionManager : MonoBehaviour
    {
        [Header("Scene loading specification")]
        [SerializeField][Min(0)] private float fadeOutTime = 2f;
        [SerializeField][Min(0)] private float fadeInTime = 2f;
        public event Action SceneChange;

        public void TriggerSceneLoadWithFade(int nextSceneIndex)
        {
            SceneChange?.Invoke();
            StartCoroutine(LoadSceneWithFade(nextSceneIndex));
        }

        private IEnumerator LoadSceneWithFade(int nextSceneIndex)
        {
            yield return SystemsManager.Instance.screenOverlay.ScreenFadeOut(fadeOutTime);
            yield return SceneManager.LoadSceneAsync(nextSceneIndex);
            yield return SystemsManager.Instance.screenOverlay.ScreenFadeIn(fadeInTime);
        }

        public void InstantSceneReload()
        {
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(sceneIndex);
        }

        public void InstantSceneLoad(int sceneIndex) => SceneManager.LoadSceneAsync(sceneIndex);
    }
}