using EssentialAssets.DialogueSystem;
using EssentialAssets.GameState;
using EssentialAssets.Utilities;

/// <summary>
/// Class that gathers systems that are often used in other script and in each scene to reduce dependencies. Make sure
/// it is properly initialized in first scene before main menu.
/// </summary>
public class SystemsManager : Singleton<SystemsManager>
{
    public ScreenOverlay screenOverlay { get; private set; }
    public SceneTransitionManager sceneTransitionManager { get; private set; }
    public DialogueManager dialogueManager { get; private set; }
    public SoundManager soundManager { get; private set; }

    protected override void Awake()
    {
        screenOverlay = GetComponentInChildren<ScreenOverlay>();
        sceneTransitionManager = GetComponentInChildren<SceneTransitionManager>();
        dialogueManager = GetComponentInChildren<DialogueManager>();
        soundManager = GetComponentInChildren<SoundManager>();

        base.Awake();

        sceneTransitionManager.InstantSceneLoad(1);
    }
}
