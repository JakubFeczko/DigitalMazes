using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// This class handles updating the user's preferences from the UI, including volume and turn type.
/// </summary>
public class SetOptionFromUI : MonoBehaviour
{
    /// <summary>
    /// Volume control slider.
    /// </summary>
    public Scrollbar volumeSlider;

    /// <summary>
    /// Dropdown selection for the turn type.
    /// </summary>
    public TMPro.TMP_Dropdown turnDropdown;

    /// <summary>
    /// Script to apply turn type based on player's preferences.
    /// </summary>
    public SetTurnTypeFromPlayerPref turnTypeFromPlayerPref;

    /// <summary>
    /// Invoked at the start of the scene, sets up the volume and turn type from player preferences.
    /// </summary>
    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetGlobalVolume);
        turnDropdown.onValueChanged.AddListener(SetTurnPlayerPref);

        if (PlayerPrefs.HasKey("turn"))
            turnDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("turn"));
    }

    /// <summary>
    /// Sets the global audio volume.
    /// </summary>
    /// <param name="value">The value to set the global volume to, on a scale from 0 to 1.</param>
    public void SetGlobalVolume(float value)
    {
        AudioListener.volume = value;
    }

    /// <summary>
    /// Sets the player preference for turn type and applies the change.
    /// </summary>
    /// <param name="value">The value representing the turn type in player preferences.</param>
    public void SetTurnPlayerPref(int value)
    {
        PlayerPrefs.SetInt("turn", value); 
        turnTypeFromPlayerPref.ApplyPlayerPref();
    }
}
