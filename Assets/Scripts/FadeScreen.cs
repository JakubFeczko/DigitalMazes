using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to manage screen fading effects.
/// </summary>
public class FadeScreen : MonoBehaviour
{
    /// <summary>
    /// Flag to determine whether to fade in at the start.
    /// </summary>
    public bool fadeOnStart = true;

    /// <summary>
    /// Duration of the fade effect in seconds.
    /// </summary>
    public float fadeDuration = 2;

    /// <summary>
    /// Color of the fade effect.
    /// </summary>
    public Color fadeColor;

    /// <summary>
    /// Animation curve to control the progression of the fade effect.
    /// </summary>
    public AnimationCurve fadeCurve;

    /// <summary>
    /// The name of the color property of the Renderer's material.
    /// </summary>
    public string colorPropertyName = "_Color";

    /// <summary>
    /// The Renderer component attached to the GameObject.
    /// </summary>
    private Renderer rend;

    /// <summary>
    /// Called before the first frame update.
    /// Gets the Renderer component and initializes the fade effect.
    /// </summary>
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;

        if (fadeOnStart)
            FadeIn();
    }

    /// <summary>
    /// Fades in from the fade color to transparent.
    /// </summary>
    public void FadeIn()
    {
        Fade(1, 0);
    }

    /// <summary>
    /// Fades out from transparent to the fade color.
    /// </summary>
    public void FadeOut()
    {
        Fade(0, 1);
    }

    /// <summary>
    /// Triggers a fade effect from a given initial alpha value to a final alpha value.
    /// </summary>
    /// <param name="alphaIn">Initial alpha value.</param>
    /// <param name="alphaOut">Final alpha value.</param>
    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn,alphaOut));
    }

    /// <summary>
    /// Coroutine that performs the fade effect from a given initial alpha value to a final alpha value.
    /// </summary>
    /// <param name="alphaIn">Initial alpha value.</param>
    /// <param name="alphaOut">Final alpha value.</param>
    /// <returns>IEnumerator for coroutine.</returns>
    public IEnumerator FadeRoutine(float alphaIn,float alphaOut)
    {
        rend.enabled = true;

        float timer = 0;
        while(timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, fadeCurve.Evaluate(timer / fadeDuration));

            rend.material.SetColor(colorPropertyName, newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor(colorPropertyName, newColor2);

        if(alphaOut == 0)
            rend.enabled = false;
    }
}
