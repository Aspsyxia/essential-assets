using System.Linq;
using UnityEngine;

namespace Core
{
    public class CanvasBasedLayout: MonoBehaviour
    {
        [Header("Canvas")]
        [SerializeField] protected Canvas layoutCanvas;

        protected bool IsActive;
        
        protected void Toggle()
        {
            if (!StatusCheck()) return;
            if (IsActive) Exit();
            else Open();
        }

        private void Exit()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            PlayerStatus.EnablePlayerControls();
            layoutCanvas.enabled = false;
            IsActive = false;
        }

        private void Open()
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            PlayerStatus.DisablePlayerControls();
            layoutCanvas.enabled = true;
            IsActive = true;
        }
        
        private bool StatusCheck()
        {
            return FindObjectsOfType<CanvasBasedLayout>().All(layout => layout == this || !layout.IsActive);
        }
    }
}