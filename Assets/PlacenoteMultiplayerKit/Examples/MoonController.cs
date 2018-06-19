using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Placenote;

/// <summary>
/// Should be attached to SampleMoon game object.
/// Controls SampleMoon game object.
/// </summary>
public class MoonController : MonoBehaviour
{
	void Start () 
    {
        // Register this object to the current game controller.
        // This is important so that all clients have a reference to this object.
        GameController.Instance.RegisterMoon (this);
	}
}
