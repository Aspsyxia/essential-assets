using System;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    [SerializeField] private float xScroll = 0.5f;
    [SerializeField] private float yScroll = 0.5f;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float xOffset = Time.time * xScroll;
        float yOffset = Time.time * yScroll;
        
        _renderer.material.mainTextureOffset = new Vector2(xOffset, yOffset);
    }
}
