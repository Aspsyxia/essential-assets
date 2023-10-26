using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace EssentialAssets.Core
{
    /// <summary>
    /// Makes use of Fader class, and allows to fade screen in and out.
    /// </summary>
    public class ScreenFader: MonoBehaviour
    {
        private Fader _fader;
        private static Image _screenOverlay;
        private static GraphicRaycaster _raycaster;
        public static ScreenFader Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                _screenOverlay = GetComponentInChildren<Image>();
                _fader = GetComponent<Fader>();
                _raycaster = GetComponent<GraphicRaycaster>();
                _fader.HideObject(_screenOverlay);
                _raycaster.enabled = false;
                DontDestroyOnLoad(gameObject);
            }
        }
        
        public IEnumerator ScreenFadeOut()
        {
            _raycaster.enabled = true;
            yield return _fader.FadeIn(_screenOverlay);
        }
        
        public IEnumerator ScreenFadeIn()
        {
            yield return _fader.FadeOut(_screenOverlay);
            _raycaster.enabled = false;
        }
        
    }
}