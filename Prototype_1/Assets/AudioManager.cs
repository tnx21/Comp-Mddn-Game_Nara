using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;  // stores all the sounds that this audio manager will be using

    public static AudioManager instance;
    public bool game = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (game)
        {
            Destroy(instance.gameObject);
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // initializes each sound clip with 
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Song1");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { Debug.LogWarning("Sound: " + name + " is not valid!"); return; }
        s.source.Play();
    }
}
