using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Placenote;

/// <summary>
/// Should be attached to main UI canvas.
/// Controls the UI for MultiplayerSampleScene.
/// </summary>
public class MultiplayerSampleView : PlacenotePunMultiplayerBehaviour 
{
    // Child object references
    public GameObject FinishMappingButton;
    public GameObject StartGameButton;
    public GameObject MainMenu;
    public GameObject BackButton;

    /// <summary>
    /// Ensures proper UI is on when enabled.
    /// </summary>
    private void OnEnable ()
    {
        Reset ();
        Debug.LogWarning ("Make sure these OnClick functions are set for the following child objects of MultiplayerSampleView:\n" +
                   "HostRoomButton: PlacenoteMultiplayerManager.HostRoom (\"TextForHostRoomFunction\")\n" +
                   "StartGameButton: PlacenoteMultiplayerManager.StartGame ()\n" +
                   "FinishMappingButton: PlacenoteMultiplayerManager.StopMapping ()\n" +
                   "BackButton: PlacenoteMultiplayerManager.QuitGame ()\n");
    }

    /// <summary>
    /// Hide main menu when joining room.
    /// </summary>
    protected override void OnStartJoiningRoom ()
    {
        MainMenu.SetActive (false);
        BackButton.SetActive (true);
    }

    /// <summary>
    /// There are sufficient points and the player may stop mapping.
    /// </summary>
    protected override void OnMappingSufficient ()
    {
        FinishMappingButton.SetActive (true);
    }

    protected override void OnLocalized ()
    {
        // Only show start button when the client has not started playing.
        if (!PlacenoteMultiplayerManager.Instance.IsPlaying)
        {
            StartGameButton.SetActive (true);
        }
    }

    /// <summary>
    /// Hide start button on Placenote LOST Status
    /// </summary>
    protected override void OnLocalizationLost ()
    {
        StartGameButton.SetActive (false);
    }

    /// <summary>
    /// Reset UI to main menu on quit.
    /// </summary>
    protected override void OnGameQuit ()
    {
        Reset ();
    }

    /// <summary>
    /// Show the main menu and hides the mapping buttons on start up.
    /// </summary>
    private void Reset ()
    {
        FinishMappingButton.SetActive (false);
        StartGameButton.SetActive (false);
        MainMenu.SetActive (true);
        BackButton.SetActive (false);
    }

    /// <summary>
    /// Needed for Unity Editor because OnMappingSufficient is never called
    /// in simulator.
    /// </summary>
    #if UNITY_EDITOR
    protected override void OnMappingStart ()
    {
        FinishMappingButton.SetActive (true);
    }
    #endif
}
