using UnityEngine;
using EssentialAssets.Status;
using EssentialAssets.UI;

namespace EssentialAssets.GameState
{
    public class GameStateManager : CanvasOverlay
    {
        [SerializeField] private Canvas successCanvas;
        [SerializeField] private Canvas failureCanvas;

        //Add events that cause game to be over in Start method and subscribe them to ForceOpen method
        private void Start()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().PlayerDeath += ForceOpen;
        }

        public void Restart()
        {
            SystemsManager.Instance.sceneTransition.InstantLoad();
        }

        public void BackToMenu()
        {
            SystemsManager.Instance.sceneTransition.TriggerSceneChange(1);
        }
    }
}
