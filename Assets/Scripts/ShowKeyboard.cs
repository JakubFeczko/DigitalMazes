using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

/// <summary>
/// This class manages the display of a keyboard for the input field.
/// </summary>
public class ShowKeyboard : MonoBehaviour
{
    /// <summary>
    /// Reference to the InputField component attached to the GameObject.
    /// </summary>
    private TMP_InputField inputField;

    /// <summary>
    /// At the start of the scene, it gets the input field component and sets up the event listener.
    /// </summary>
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onSelect.AddListener(x => OpenKeyboard());
    }

    /// <summary>
    /// Opens the keyboard and sets it to the text currently in the input field.
    /// </summary>
    public void OpenKeyboard()
    {
        NonNativeKeyboard.Instance.InputField = inputField;
        NonNativeKeyboard.Instance.PresentKeyboard(inputField.text);
    }
}
