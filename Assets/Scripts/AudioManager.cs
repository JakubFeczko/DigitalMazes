using UnityEngine.Audio;
using System;
using UnityEngine;

/// <summary>
/// Serializable class that represents a sound clip with some properties.
/// </summary>
[System.Serializable]
public class Sound
{
    /// <summary>
    /// Name of the sound.
    /// </summary>
    public string name;

    /// <summary>
    /// The actual AudioClip that represents the sound.
    /// </summary>
    public AudioClip clip;

    /// <summary>
    /// The volume level of the sound, ranging from 0 to 1.
    /// </summary>
    [Range(0,1)]
    public float volume = 1;

    /// <summary>
    /// The pitch level of the sound, ranging from -3 to 3.
    /// </summary>
    [Range(-3,3)]
    public float pitch = 1;

    /// <summary>
    /// Whether the sound should loop or not.
    /// </summary>
    public bool loop = false;

    /// <summary>
    /// AudioSource component that plays the sound.
    /// </summary>
    public AudioSource source;

    /// <summary>
    /// Constructor that initializes the default values for volume, pitch and loop.
    /// </summary>
    public Sound()
    {
        volume = 1;
        pitch = 1;
        loop = false;
    }
}

/// <summary>
/// Singleton class that manages audio playback.
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Array of Sound objects to manage.
    /// </summary>
    public Sound[] sounds;

    /// <summary>
    /// Static instance of the AudioManager.
    /// </summary>
    public static AudioManager instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// It initializes the AudioManager and its sounds.
    /// </summary>
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            if(!s.source)
                s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    /// <summary>
    /// Play a sound with the given name.
    /// If the sound does not exist, it will log a warning.
    /// </summary>
    /// <param name="name">Name of the sound to play.</param>
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    /// <summary>
    /// Stop the sound with the given name.
    /// </summary>
    /// <param name="name">Name of the sound to stop.</param>
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }
}