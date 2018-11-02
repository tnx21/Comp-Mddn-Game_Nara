using UnityEngine.Audio;
using UnityEngine;

// used to store a sound and the settings for volume and pitch and if it loops or not
[System.Serializable]
public class Sound {

    public string name; // reference so that the audioManager knows what to play

    public AudioClip clip;  // sound file

    // settings
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
