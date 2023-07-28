using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for managing the book's open and close mechanism.
/// </summary>
public class OpenBook : MonoBehaviour
{
    /// <summary>
    /// Game object representing the cover of the book.
    /// </summary>
    public GameObject Cover;

    /// <summary>
    /// The HingeJoint component of the book cover which allows it to open and close.
    /// </summary>
    public HingeJoint myHinge;

    /// <summary>
    /// Method called at the start of the first frame, it gets the HingeJoint component of the book cover and disables its motor.
    /// </summary>
    void Start()
    {
        var myHinge = Cover.GetComponent<HingeJoint>();
        myHinge.useMotor = false;
    }

    /// <summary>
    /// Method responsible for opening the book by enabling the motor of the HingeJoint component of the book cover.
    /// </summary>
    public void OpenSesame()
    {
        myHinge.useMotor = true;
        Debug.Log("motor should be true");
    }
}
