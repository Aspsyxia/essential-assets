using UnityEngine;
using System.Linq;

namespace EssentialAssets.Core
{
    public class CanvasBasedLayout: MonoBehaviour
    {
        [Header("Canvas")]
        [SerializeField] protected Canvas layoutCanvas;

        protected bool IsActive;

        private void Awake()
        {
            Close();
        }

        protected void Toggle()
        {
            if (!StatusCheck()) return;
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
            foreach (var layout in FindObjectsOfType<CanvasBasedLayout>())
            {
                layout.Close();
            }
        }
        
        private bool StatusCheck()
        {
            return FindObjectsOfType<CanvasBasedLayout>().All(layout => layout == this || !layout.IsActive);
        }
    }
}