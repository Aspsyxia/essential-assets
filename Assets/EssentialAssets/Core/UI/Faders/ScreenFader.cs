using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    /// <summary>
    /// Makes use of Fader class, and allows to fade screen in and out.
    /// </summary>
    public class ScreenFader: MonoBehaviour
    {
        private Fader _fader;
        private static Image _screenOverlay;
        public static ScreenFader Instance;

        private void Awake()
        {
            if (Instance != null) return;
            Instance = this;
            _screenOverlay = GetComponentInChildren<Image>();
            _fader = GetComponent<Fader>();
            _fader.HideObject(_screenOverlay);
            DontDestroyOnLoad(gameObject);
        }
        
        public IEnumerator ScreenFadeIn()
        {
            yield return _fader.FadeIn(_screenOverlay);
        }
        
        public IEnumerator ScreenFadeOut()
        {
            yield return _fader.FadeOut(_screenOverlay);
        }
        
    }
}