using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
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

        public void HideObject(Image image)
        {
            _tempColor = image.color;
            _tempColor.a = minVisibility;
            image.color = _tempColor;
        }

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
