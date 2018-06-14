using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Placenote;

/// <summary>
/// Should be attached to the ViewRoomsPanel game object.
/// A sample script that demonstrates how to use the PlacenoteMultiplayerManager
/// function GetListOfNearbyRooms to generates a list of clickable buttons.
/// Instantiates a button for every room within a set metre range.
/// </summary>
public class ViewRooms : PlacenotePunMultiplayerBehaviour 
{
    // Content gameObject that is parent of created buttons.
    [SerializeField] GameObject contentField;

    // Button prefab.
    [SerializeField] GameObject roomButtonPrefab;

    // Range in meters to search for rooms
    private const float GPS_SEARCH_RANGE = 100f;

    protected override void OnConnectedToPhoton ()
    {
        GenerateViewRooms ();
    }

    /// <summary>
    /// Generates all the available rooms that are nearby based on GPS
    /// </summary>
    public void GenerateViewRooms ()
    {
        // Clear the rooms first.
        DeleteViewRooms ();
        // Get all rooms within the GPS range
        RoomInfo[] roomsArray = PlacenoteMultiplayerManager.Instance.GetListOfNearbyRooms (GPS_SEARCH_RANGE);
        if (roomsArray.Length > 0)
        {
            foreach (RoomInfo game in roomsArray)
            {
                // Create 1 button for each room
                GameObject room = (GameObject)Instantiate (roomButtonPrefab);

                // Add the JoinRoom function call to the button as an
                // onClick Listener.
                room.GetComponent<Button>
                    ().onClick.AddListener (() =>
                    {
                        PlacenoteMultiplayerManager.Instance.JoinRoom (game.Name);
                    });         

                // Setting the button's text to display the room name
                room.transform.GetChild (0).GetComponent<Text> ().text = game.Name;
                // Setting the button's parent to be the content field
                room.transform.SetParent (contentField.transform, false);
            }
        }
    }

    /// <summary>
    /// Removes all rooms from viewRoomsPanel
    /// </summary>
    void DeleteViewRooms ()
    {
        foreach (Transform child in contentField.transform)
        {
            Destroy (child.gameObject);
        }
    }

    /// <summary>
    /// Generate rooms again if received a room list update.
    /// </summary>
    protected override void OnRoomListUpdate ()
    {
        GenerateViewRooms ();
    }
}
