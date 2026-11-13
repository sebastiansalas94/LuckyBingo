using System.Collections;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

/// <summary>
/// Plays the FMOD music event (Main Sequence) and sets FMOD's global parameters.
/// Put this on the AudioManager GameObject in 2DScene.
/// </summary>
public class FMODMusic : MonoBehaviour
{
    [Header("FMOD Event")]
    [Tooltip("The music event to play when the scene starts.")]
    [SerializeField] private EventReference mainSequence;

    private EventInstance musicInstance;

    // Start runs as a coroutine so it can wait for the banks to load.
    private IEnumerator Start()
    {
        // Desktop: banks load instantly, so this loop is skipped.
        // Web: banks download in the background; starting the event before
        // the download finishes would play nothing, so wait here.
        while (!RuntimeManager.HaveAllBanksLoaded)
        {
            yield return null;
        }

        // Create a playable copy of the event and start it.
        musicInstance = RuntimeManager.CreateInstance(mainSequence);
        musicInstance.start();

        // These parameters are GLOBAL in the FMOD project, so they are set on
        // the whole FMOD system, not on the event. Values are the label names
        // exactly as they appear in FMOD Studio.
        // SetGlobalLabel("GameStart", "True");
        // SetGlobalLabel("View", "TV");
        // SetGlobalLabel("Stage", "0");
    }

    /// <summary>
    /// Sets a global labeled FMOD parameter by its label name, e.g.
    /// FMODMusic.SetGlobalLabel("View", "Window");
    /// Can be called from any script.
    /// </summary>
    public static void SetGlobalLabel(string parameter, string label)
    {
        FMOD.RESULT result = RuntimeManager.StudioSystem.setParameterByNameWithLabel(parameter, label);

        if (result != FMOD.RESULT.OK)
        {
            Debug.LogWarning($"[FMODMusic] Could not set {parameter} = {label}: {result}");
        }
    }
}
