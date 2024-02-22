using EssentialAssets.DialogueSystem;
using EssentialAssets.GameState;
using EssentialAssets.Utilities;
using EssentialAssets.VisualEffects;
using UnityEngine;

/// <summary>
/// Class that gathers systems that are often used in other script and in each scene to reduce dependencies. Make sure
/// it is properly initialized in first scene before main menu.
/// </summary>
public class SystemsManager : MonoBehaviour
{
    [HideInInspector] public Fader fader;
    [HideInInspector] public SceneTransition sceneTransition;
    [HideInInspector] public DialogueManager dialogueManager;
    [HideInInspector] public SoundManager soundManager;

    public static SystemsManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }

        fader = GetComponentInChildren<Fader>();
        sceneTransition = GetComponentInChildren<SceneTransition>();
        dialogueManager = GetComponentInChildren<DialogueManager>();
        soundManager = GetComponentInChildren<SoundManager>();

        sceneTransition.InstantLoad(1);
    }
}
