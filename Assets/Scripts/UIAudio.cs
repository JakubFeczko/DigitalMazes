using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// The UIAudio class is used to play specific audio clips in response to user interactions with the UI.
/// </summary>
public class UIAudio : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// The name of the audio clip to play when the UI element is clicked.
    /// </summary>
    public string clickAudioName;

    /// <summary>
    /// The name of the audio clip to play when the mouse pointer enters the UI element.
    /// </summary>
    public string hoverEnterAudioName;

    /// <summary>
    /// The name of the audio clip to play when the mouse pointer exits the UI element.
    /// </summary>
    public string hoverExitAudioName;

    /// <summary>
    /// Called when the UI element is clicked. Plays the click audio clip.
    /// </summary>
    /// <param name="eventData">Data associated with the PointerClick event.</param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if(clickAudioName != "")
        {
            AudioManager.instance.Play(clickAudioName);
        }
    }

    /// <summary>
    /// Called when the mouse pointer enters the UI element. Plays the hover enter audio clip.
    /// </summary>
    /// <param name="eventData">Data associated with the PointerEnter event.</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverEnterAudioName != "")
        {
            AudioManager.instance.Play(hoverEnterAudioName);
        }
    }

    /// <summary>
    /// Called when the mouse pointer exits the UI element. Plays the hover exit audio clip.
    /// </summary>
    /// <param name="eventData">Data associated with the PointerExit event.</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverExitAudioName != "")
        {
            AudioManager.instance.Play(hoverExitAudioName);
        }
    }
}
