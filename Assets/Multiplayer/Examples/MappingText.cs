using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Placenote;
using UnityEngine.UI;

/// <summary>
/// Updates text object during mapping session as host player or as non-host
/// player to provide feedback.
/// </summary>
public class MappingText : PlacenotePunMultiplayerBehaviour
{
    private Text mappingText;
    private void Awake ()
    {
        mappingText = gameObject.GetComponent<Text> ();
        mappingText.text = "In Main Menu.";
    }

    protected override void OnStartJoiningRoom ()
    {
        if (PlacenoteMultiplayerManager.Instance.IsHost)
            mappingText.text = "Hosting room...";
        else
            mappingText.text = "Joining room...";
    }

    protected override void OnJoinedRoom ()
    {
        // Wait for the host to map when local client is not the host, and a
        // map does not already exist.
        if (!PlacenoteMultiplayerManager.Instance.IsHost
            && !PlacenoteMultiplayerManager.Instance.HasRoomStarted)
            mappingText.text = "Wait for the host to map the room.";
    }

    protected override void OnMappingStart ()
    {
        if (PlacenoteMultiplayerManager.Instance.IsHost)
            mappingText.text = "Move your phone around to create a map.";
    }

    protected override void OnMappingFailed ()
    {
        mappingText.text = "Failed to start mapping session. Please restart app...";
    }

    protected override void OnGameStart ()
    {
        mappingText.text = "Game start!";
    }

    protected override void OnGameQuit ()
    {
        mappingText.text = "In Main Menu.";
    }

    #region Mapping status and progress
    protected override void OnMapSavingProgressUpdate (float progress)
    {
        mappingText.text = "Saving Progress..." + (progress * 100f) + "%";
    }

    protected override void OnMapSavingStatusUpdate (bool savingResult)
    {
        mappingText.text = "Saving " + (savingResult ? "success!" : "Error!");
    }

    protected override void OnMapLoadingProgressUpdate (float progress)
    {
        mappingText.text = "Loading Map..." + (progress * 100f) + "%";
    }

    protected override void OnMapLoadingStatusUpdate (bool loadingResult)
    {
        mappingText.text = "Loading " + (loadingResult ? "success!" : "Error!");
    }
    #endregion Mapping status and progress

    #region Localization
    protected override void OnLocalizationLost ()
    {
        if (PlacenoteMultiplayerManager.Instance.IsPlaying)
        {
            mappingText.text = "Lost";
        }
        else
        {
            mappingText.text = "Move and look to where the map was created to localize.";
        }
    }

    protected override void OnLocalized ()
    {
        if (PlacenoteMultiplayerManager.Instance.IsPlaying) 
        {
            mappingText.text = "Localized";    
        }
        else
        {
            mappingText.text = "Localized! Press the button to start the game";
        }
    }
    #endregion Localization
}
