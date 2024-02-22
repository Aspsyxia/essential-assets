using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EssentialAssets.GameState
{
    public class SceneTransition: MonoBehaviour
    {
        public event Action SceneChange;
        
        public void TriggerSceneChange(int nextSceneIndex)
        {
            SceneChange?.Invoke();
            StartCoroutine(ChangeScene(nextSceneIndex));
        }
        
        private IEnumerator ChangeScene(int nextSceneIndex)
        {
            yield return SystemsManager.Instance.fader.ScreenFadeOut();
            yield return SceneManager.LoadSceneAsync(nextSceneIndex);
            yield return SystemsManager.Instance.fader.ScreenFadeIn();
        }
        
        public void InstantLoad()
        {
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(sceneIndex);
        }
        
        public void InstantLoad(int sceneIndex)
        {
            SceneManager.LoadSceneAsync(sceneIndex);
        }
    }
}