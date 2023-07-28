using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Class responsible for checking lever sequences.
/// </summary>
public class LeverSequenceChecker : MonoBehaviour
{
    ///<summary> 
    /// UI element to display the result text.
    ///</summary>
    [SerializeField]
    private TMP_InputField resultText;

    ///<summary> 
    /// Game object representing the first hand.
    ///</summary>
    [Header("Cabinet Hand One")]
    [SerializeField]
    public GameObject hand1;

    ///<summary> 
    /// Game object representing the second hand.
    ///</summary>
    [Header("Cabinet Hand Two")]
    [SerializeField]
    public GameObject hand2;

    ///<summary> 
    /// The expected lever sequence. True means the lever is active and False means the lever is inactive.
    ///</summary>
    private bool[] expectedSequence = { true, true, false, false, true};

    ///<summary> 
    /// States of the individual levers.
    ///</summary>
    private bool firstLever = true;
    private bool secondLever = true;
    private bool thirdLever = true;
    private bool fourthLever = true;
    private bool fifthLever = true;

    ///<summary> 
    /// Methods to change the state of each lever.
    ///</summary>
    public void activeFirstLaver(){firstLever = true;}
    public void disActivateFirstLaver(){firstLever = false;}
    public void activeSecondLaver() { secondLever = true;}
    public void disActivateSecondLaver() { secondLever = false;}
    public void activeThirdLaver() { thirdLever = true;}
    public void disActivateThirdLaver() { thirdLever = false;}
    public void activeFourthLaver() { fourthLever = true;}
    public void disActivateFourthLaver() { fourthLever = false;}
    public void activeFifthLaver() { fifthLever = true;}
    public void disActivateFifthLaver() { fifthLever = false;}


    ///<summary> 
    /// Method to set all levers to active at the start.
    ///</summary
    private void Start()
    {
        firstLever = true;
        secondLever = true;
        thirdLever = true;
        fourthLever = true;
        fifthLever = true;

    }

    ///<summary> 
    /// Method to check the lever sequence at every update.
    ///</summary
    private void Update()
    {
        checkSequence();
    }

    ///<summary> 
    /// Method to compare the current state of the levers to the expected sequence.
    /// If the sequence is correct, it sets the result text to "Cabinet Open!" and enables the XRGrabInteractable components on the hands.
    /// If the sequence is incorrect, it sets the result text to "Sequence Incorrect!".
    ///</summary>
    public void checkSequence()
    {
        if (firstLever == expectedSequence[0] && secondLever == expectedSequence[1] && thirdLever == expectedSequence[2] && fourthLever == expectedSequence[3] && fifthLever == expectedSequence[4])
        {
            resultText.text = "Cabinet Open!";
            XRGrabInteractable grabInteractable = hand1.GetComponent<XRGrabInteractable>();
            XRGrabInteractable grabInteractable1 = hand2.GetComponent<XRGrabInteractable>();

            if (grabInteractable != null && grabInteractable1 != null)
            {
                grabInteractable.enabled = true;
                grabInteractable1.enabled = true;
            }
        }
        else
        {
            resultText.text = "Sequence Incorrect!";
        }
    }
}
