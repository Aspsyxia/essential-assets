using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    [SerializeField] private float xScroll = 0.5f;
    [SerializeField] private float yScroll = 0.5f;
    
    void Update()
    {
        float xOffset = Time.time * xScroll;
        float yOffset = Time.time * yScroll;
        
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(xOffset, yOffset);
    }
}
