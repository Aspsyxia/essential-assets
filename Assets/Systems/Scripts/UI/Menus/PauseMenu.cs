using EssentialAssets.Utilities;
using UnityEngine;

namespace EssentialAssets.UI
{
    /// <summary>
    /// Simple class that brings essential pause menu options.
    /// </summary>
    public class PauseMenu : CanvasOverlay
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }

        /// <summary>
        /// Close the pause menu and return to the application.
        /// </summary>
        public void Resume()
        {
            Close();
        }

        /// <summary>
        /// Return to main menu.
        /// </summary>
        public void Exit()
        {
            SystemsManager.Instance.sceneTransitionManager.TriggerSceneLoadWithFade(1);
        }
    }
}
