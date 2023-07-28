using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// This class manages the turn type setting based on the user's preferences.
/// </summary>
public class SetTurnTypeFromPlayerPref : MonoBehaviour
{
    /// <summary>
    /// Reference to the Snap Turn Provider.
    /// </summary>
    public ActionBasedSnapTurnProvider snapTurn;

    /// <summary>
    /// Reference to the Continuous Turn Provider.
    /// </summary>
    public ActionBasedContinuousTurnProvider continuousTurn;

    /// <summary>
    /// At the start of the scene, apply the turn type setting from player preferences.
    /// </summary>
    void Start()
    {
        ApplyPlayerPref();
    }

    /// <summary>
    /// Applies the player's preferred turn type. If "turn" key has value 0, snap turn is enabled. If it has value 1, continuous turn is enabled.
    /// </summary>
    public void ApplyPlayerPref()
    {
        if(PlayerPrefs.HasKey("turn"))
        {
            int value = PlayerPrefs.GetInt("turn");
            if(value == 0)
            {
                snapTurn.leftHandSnapTurnAction.action.Enable();
                snapTurn.rightHandSnapTurnAction.action.Enable();
                continuousTurn.leftHandTurnAction.action.Disable();
                continuousTurn.rightHandTurnAction.action.Disable();
            }
            else if(value == 1)
            {
                snapTurn.leftHandSnapTurnAction.action.Disable();
                snapTurn.rightHandSnapTurnAction.action.Disable();
                continuousTurn.leftHandTurnAction.action.Enable();
                continuousTurn.rightHandTurnAction.action.Enable();
            }
        }
    }
}
