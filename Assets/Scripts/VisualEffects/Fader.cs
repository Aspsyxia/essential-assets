using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace EssentialAssets.VisualEffects
{
    /// <summary>
    /// Allows to smoothly show or hide UI image objects.
    /// </summary>
    [RequireComponent(typeof(GraphicRaycaster), typeof(Image))]
    public class Fader : MonoBehaviour
    {
        [SerializeField] private Color baseColor = Color.black;
        
        [Header("Visibility")] 
        [SerializeField][Range(0, 1)] private float minVisibility = 0f;
        [SerializeField][Range(0, 1)] private float maxVisibility = 0.65f;

        [Header("Speed")] 
        [SerializeField][Range(0, 1)] private float fadingOutSpeed = 0.01f;
        [SerializeField][Range(0, 1)] private float fadingInSpeed = 0.01f;
        
        private Color _tempColor;
        private Coroutine _activeCoroutine;
        
        private static Image _screenOverlay;
        private static GraphicRaycaster _raycaster;
        
        private void Awake()
        {
            _screenOverlay = GetComponent<Image>();
            _raycaster = GetComponent<GraphicRaycaster>();
            
            _screenOverlay.color = baseColor;
            HideObject(_screenOverlay);
            _raycaster.enabled = false;
        }

        /// <summary>
        /// Instantly hides given image.
        /// </summary>
        /// <param name="image">image to hide</param>
        public void HideObject(Image image)
        {
            _tempColor = image.color;
            _tempColor.a = minVisibility;
            image.color = _tempColor;
        }
        
        /// <summary>
        /// Instantly shows given image.
        /// </summary>
        /// <param name="image">image to hide</param>
        public void ShowObject(Image image)
        {
            _tempColor = image.color;
            _tempColor.a = maxVisibility;
            image.color = _tempColor;
        }
        
        /// <summary>
        /// Smoothly hides given image.
        /// </summary>
        /// <param name="image">image to hide</param>
        public IEnumerator FadeOut(Image image)
        {
            _tempColor = image.color;
            
            while (_tempColor.a > minVisibility)
            {
                _tempColor.a -= fadingOutSpeed;
                image.color = _tempColor;
                yield return new WaitForSeconds(0.005f * Time.deltaTime);
            }
        }

        /// <summary>
        /// Smoothly shows given image.
        /// </summary>
        /// <param name="image">image to show</param>
        public IEnumerator FadeIn(Image image)
        {
            while (_tempColor.a < maxVisibility)
            {
                _tempColor.a += fadingInSpeed;
                image.color = _tempColor;
                yield return new WaitForSeconds(0.005f * Time.deltaTime);
            }
        }
        
        public void TriggerFadeIn(Image image)
        {
            if (_activeCoroutine != null) StopAllCoroutines();
            _activeCoroutine = StartCoroutine(FadeIn(image));
        }
        
        public void TriggerFadeOut(Image image)
        {
            if (_activeCoroutine != null) StopAllCoroutines();
            _activeCoroutine = StartCoroutine(FadeOut(image));
        }
        
        /// <summary>
        /// Makes screen smoothly fade under overlay image.
        /// </summary>
        /// <returns></returns>
        public IEnumerator ScreenFadeOut()
        {
            _raycaster.enabled = true;
            yield return FadeIn(_screenOverlay);
        }
        
        /// <summary>
        /// Makes screen smoothly show from underneath overlay image.
        /// </summary>
        /// <returns></returns>
        public IEnumerator ScreenFadeIn()
        {
            yield return FadeOut(_screenOverlay);
            _raycaster.enabled = false;
        }

        /// <summary>
        /// Changes old screen overlay sprite to new one given as a parameter<param name="newImage">new image</param>
        /// </summary>
        public void SwitchOverlayImage(Sprite newImage)
        {
            _screenOverlay.sprite = newImage;
        }
    }
}
