using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace EssentialAssets.Core
{
    /// <summary>
    /// Allows to smoothly show or hide UI image objects.
    /// </summary>
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

        /// <summary>
        /// Instantly hide given image.
        /// </summary>
        /// <param name="image">image to hide</param>
        public void HideObject(Image image)
        {
            _tempColor = image.color;
            _tempColor.a = minVisibility;
            image.color = _tempColor;
        }
        
        /// <summary>
        /// Smoothly hide given image.
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
        /// Smoothly show given image.
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
    }
}
