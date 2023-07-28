using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

/// <summary>
/// This class manages the operations of a Keypad, including storing the correct password, capturing user input, and invoking events based on the correctness of the input.
/// </summary>
public class KeyPad : MonoBehaviour
{
    ///<summary> 
    /// Stores the correct password as a list of integers.
    ///</summary>
    public List<int> correctPassword = new List<int>();

    ///<summary> 
    /// Stores the input password as a list of integers.
    ///</summary>
    public List<int> inputPasswordList = new List<int>();

    ///<summary> 
    /// UI element to display the code.
    ///</summary>
    [SerializeField] private TMP_InputField codeDisplay;

    ///<summary> 
    /// Time after which the keypad is reset.
    ///</summary>
    [SerializeField] private float resetTime = 2f;

    ///<summary> 
    /// Text to be displayed upon successful password entry.
    ///</summary>
    [SerializeField] private string successText;

    ///<summary> 
    /// Event to be invoked upon successful password entry.
    ///</summary>
    [Space(5f)]
    [Header("Keypad Entry Events")]
    public UnityEvent onCorrectPassword;

    ///<summary> 
    /// Event to be invoked upon unsuccessful password entry.
    ///</summary>
    public UnityEvent onIncorrectPassword;

    ///<summary> 
    /// Number of entries allowed in the password.
    ///</summary>
    [Header("Number Of Entry")]
    public int numberOfEntry;

    ///<summary> 
    /// Defines whether multiple successful activations are allowed.
    ///</summary>
    public bool allowMultipleActivations = false;

    ///<summary> 
    /// Tracks if the correct password has already been used.
    ///</summary>
    private bool hasUsedCorrectCode = false;

    ///<summary> 
    /// Public accessor for hasUsedCorrectCode
    ///</summary>
    public bool HasUsedCorrectCode { get { return hasUsedCorrectCode; } }

    ///<summary> 
    /// Method to handle user number entry. Adds the input number to the password list, updates the display, and checks the password if enough numbers have been entered.
    ///</summary>
    public void UserNumberEntry(int selectNum)
    {
        if(inputPasswordList.Count >= numberOfEntry)
        {
            return;
        }

        inputPasswordList.Add(selectNum);

        UpdateDisplay();

        if(inputPasswordList.Count >= numberOfEntry)
        {
            CheckPassword();
        }
    }

    ///<summary> 
    /// Method to check if the entered password is correct. If any number in the input password does not match the correct password, it calls the IncorrectPassword() method.
    ///</summary>
    private void CheckPassword()
    {
        for(int i = 0; i < correctPassword.Count; i++)
        {
            if (inputPasswordList[i] != correctPassword[i])
            {
                IncorrectPassword();
                return;
            }
        }
        correctPasswordGiven();
    }

    ///<summary> 
    /// Method to handle the event of correct password input. It invokes the onCorrectPassword event, updates the display to show the successText, and starts a ResetKeyCode coroutine.
    ///</summary>
    private void correctPasswordGiven()
    {
        if (allowMultipleActivations)
        {
            onCorrectPassword.Invoke();
            codeDisplay.text = successText;
            StartCoroutine(ResetKeyCode());
        }
        else if(!allowMultipleActivations && !hasUsedCorrectCode)
        {
            onCorrectPassword.Invoke();
            hasUsedCorrectCode = true;
            codeDisplay.text = successText;
        }
    }

    ///<summary> 
    /// Method to handle the event of incorrect password input. It invokes the onIncorrectPassword event and starts a ResetKeyCode coroutine.
    ///</summary>
    private void IncorrectPassword()
    {
        onIncorrectPassword.Invoke();
        StartCoroutine(ResetKeyCode());
    }

    ///<summary> 
    /// Method to update the display with the currently entered password.
    ///</summary>
    private void UpdateDisplay()
    {
        codeDisplay.text = null;
        for(int i = 0; i< inputPasswordList.Count; i++)
        {
            Debug.Log(inputPasswordList[i]);
            codeDisplay.text += inputPasswordList[i];
        }
    }

    ///<summary> 
    /// Method to delete an entry from the entered password.
    ///</summary>
    public void DeleteEntry()
    {
        if (inputPasswordList.Count <= 0)
        {
            return;
        }

        var listposition = inputPasswordList.Count - 1;
        inputPasswordList.RemoveAt(listposition);

        UpdateDisplay();
    }

    ///<summary> 
    /// Coroutine to reset the entered password after a certain period of time (defined by resetTime).
    ///</summary>
    IEnumerator ResetKeyCode()
    {
        yield return new WaitForSeconds(resetTime);

        inputPasswordList.Clear();
        codeDisplay.text = "Enter Code...";
    }
}
