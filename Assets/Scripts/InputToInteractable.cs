using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

/// <summary>
/// This class allows the interaction of an XRGrabInteractable object based on the text input in a TMP_InputField.
/// </summary>
public class InputToInteractable : MonoBehaviour
{
    /// <summary>
    /// The input field where the text input is received.
    /// </summary>
    public TMP_InputField inputField;

    /// <summary>
    /// The XRGrabInteractable object that is controlled based on the input field's value.
    /// </summary>
    public XRGrabInteractable drawerInteractable;

    /// <summary>
    /// Called before the first frame update.
    /// Initializes the input field event.
    /// </summary>
    void Start()
    {
        inputField.onValueChanged.AddListener(CheckInputValue);
    }

    /// <summary>
    /// Checks the value of the input field and enables the XRGrabInteractable object if the input matches "CABINET OPEN".
    /// </summary>
    /// <param name="inputValue">The value of the input field.</param>
    private void CheckInputValue(string inputValue)
    {
        if(inputValue == "CABINET OPEN")
        {
            drawerInteractable.enabled = true;
        }
    }
}
