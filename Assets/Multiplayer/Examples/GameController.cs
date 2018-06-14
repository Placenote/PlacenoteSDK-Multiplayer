using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Placenote;

/// <summary>
/// Instantiates moon and player prebabs.
/// Controls logic to hide game objects until player is playing.
/// </summary>
public class GameController : PlacenotePunMultiplayerBehaviour
{
    private List<PlayerController> mPlayerList;
    private MoonController mSampleMoon;

    #region Singleton
    private static GameController sInstance = null;
    public static GameController Instance
    {
        get { return sInstance; }
    }

    /// <summary>
    /// Returns whether the instance has been initialized or not.
    /// </summary>
    public static bool IsInitialized
    {
        get { return sInstance != null; }
    }

    /// <summary>
    /// Base awake method that sets the singleton's unique instance.
    /// </summary>
    protected virtual void Awake ()
    {
        if (sInstance != null)
        {
            Debug.LogError ("Trying to instantiate a second instance of PlacenoteMultiplayerManager singleton ");
        }
        else
        {
            sInstance = this;
            mPlayerList = new List<PlayerController> ();
        }
    }

    protected virtual void OnDestroy ()
    {
        if (sInstance == this)
        {
            sInstance = null;
        }
    }
    #endregion Singleton

    #region Override functions
    /// <summary>
    /// Instantiate objects when game starts.
    /// </summary>
    protected override void OnGameStart ()
    {
        // Only instantiate moon if one doesn't already exist.
        if (mSampleMoon == null)
            PhotonNetwork.Instantiate ("SampleMoon", Vector3.zero, Quaternion.identity, 0);
        // If a moon already does exist then set it to active.
        else
            mSampleMoon.gameObject.SetActive (true);
        // Create player
        PhotonNetwork.Instantiate ("Player", Vector3.zero, Quaternion.identity, 0);
    }

    /// <summary>
    /// Reset registered objects when quiting to main menu
    /// </summary>
    protected override void OnGameQuit ()
    {
        mSampleMoon = null;
        mPlayerList = new List<PlayerController> ();
    }
    #endregion Override functions

    #region Registering objects
    /// <summary>
    /// Registers the player.
    /// Hides/Shows all players based on if local client is playing or not.
    /// </summary>
    /// <param name="newPlayer">New player.</param>
    public void RegisterPlayer (PlayerController newPlayer)
    {
        mPlayerList.Add (newPlayer);
        foreach (PlayerController player in mPlayerList)
        {
            player.gameObject.SetActive (PlacenoteMultiplayerManager.Instance.IsPlaying);
        }
    }

    /// <summary>
    /// Registers the moon.
    /// Hides/Shows moon based on if local client is playing or not.
    /// </summary>
    /// <param name="newMoon">New moon.</param>
    public void RegisterMoon (MoonController newMoon)
    {
        mSampleMoon = newMoon;
        mSampleMoon.gameObject.SetActive (PlacenoteMultiplayerManager.Instance.IsPlaying);
    }
    #endregion Registering objects
}
