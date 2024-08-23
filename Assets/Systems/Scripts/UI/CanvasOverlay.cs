using UnityEngine;
using EssentialAssets.Status;

namespace EssentialAssets.UI
{
    public class CanvasOverlay : MonoBehaviour
    {
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
            PlayerStatus.EnablePlayerControls();
            layoutCanvas.enabled = false;
            IsActive = false;
        }

        protected void Open()
        {
            Cursor.lockState = CursorLockMode.None;
            PlayerStatus.DisablePlayerControls();
            layoutCanvas.enabled = true;
            IsActive = true;
        }

        protected void ForceOpen()
        {
            CloseAllCanvasOverlays();
            Open();
        }

        private void CloseAllCanvasOverlays()
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