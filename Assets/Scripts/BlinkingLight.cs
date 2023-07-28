using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls a light source to create a blinking effect.
/// </summary>
public class BlinkingLight : MonoBehaviour
{
    /// <summary>
    /// The Light source component that will be controlled by this script.
    /// </summary>
    public Light lightSource;

    /// <summary>
    /// The speed at which the blinking effect takes place.
    /// </summary>
    public float speed = 2f;

    /// <summary>
    /// The minimum intensity for the light during the blinking effect.
    /// </summary>
    public float minIntensity = 0f;

    /// <summary>
    /// The maximum intensity for the light during the blinking effect.
    /// </summary>
    public float maxIntensity = 1f;

    /// <summary>
    /// Random offset to differentiate blinking pattern from other blinking lights.
    /// </summary>
    private float randomOffset;

    /// <summary>
    /// Called before the first frame update.
    /// Initializes the random offset for the blinking effect.
    /// </summary>
    void Start()
    {
        randomOffset = Random.value * 100f;
    }

    /// <summary>
    /// Called once per frame.
    /// Updates the light intensity to create a blinking effect.
    /// </summary>
    void Update()
    {
        if (lightSource != null)
        {
            float noise = Mathf.PerlinNoise(randomOffset, Time.time * speed);
            lightSource.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        }
    }
}
