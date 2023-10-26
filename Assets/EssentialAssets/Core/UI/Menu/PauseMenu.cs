using System;
using EssentialAssets.Core;
using UnityEngine;

public class PauseMenu : CanvasBasedLayout
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Resume()
    {
        Close();
    }

    public void Exit()
    {
        SceneTransition.TriggerSceneChange(0);
    }
}
