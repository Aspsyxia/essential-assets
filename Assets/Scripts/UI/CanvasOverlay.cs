using UnityEngine;
using EssentialAssets.Status;

namespace EssentialAssets.UI
{
    public class CanvasOverlay: MonoBehaviour
    {
        [Header("Canvas")]
        [SerializeField] protected Canvas layoutCanvas;
        
        protected bool IsActive;
        private CanvasOverlay[] _sceneCanvasOverlays;
        
        private void Start()
        {
            _sceneCanvasOverlays = FindObjectsOfType<CanvasOverlay>();
            Close();
        }

        protected void Toggle()
        {
            if (!IsOtherCanvasOpened()) return;
            if (IsActive) Close();
            else Open();
        }

        protected void Close()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            PlayerStatus.EnablePlayerControls();
            layoutCanvas.enabled = false;
            IsActive = false;
        }

        protected void Open()
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            PlayerStatus.DisablePlayerControls();
            layoutCanvas.enabled = true;
            IsActive = true;
        }

        protected void ForceOpen()
        {
            CloseAll();
            Open();
        }

        private void CloseAll()
        {
            foreach (var layout in _sceneCanvasOverlays)
            {
                layout.Close();
            }
        }
        
        private bool IsOtherCanvasOpened()
        {
            foreach (var overlay in _sceneCanvasOverlays)
            {
                if (overlay != this && overlay.IsActive) return false;
            }
            return true;
        }
    }
}