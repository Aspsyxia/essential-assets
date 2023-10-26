using EssentialAssets.Core;
using UnityEngine;

public class GameOver : CanvasBasedLayout
{
    
    //Add events that cause game to be over in Start method and subscribe them to ForceOpen method
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().PlayerDeath += ForceOpen;
    }

    public void Restart()
    {
        SceneTransition.InstantReload();
    }
    
    public void BackToMenu()
    {
        SceneTransition.TriggerSceneChange(0);
    }
}
