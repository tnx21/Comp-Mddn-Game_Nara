using UnityEngine.Audio;
using System;
using UnityEngine;

// manages sounds, can be called from all over to play a sound file within its storage
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;  // stores all the sounds that this audio manager will be using

    public static AudioManager instance;    // used for carrying over audioManagers between scenes
    public bool game = false;   // set true on audioManager in the main game, so that the previous one can be destroyed

    void Awake()
    {
        if (instance == null)
        {
            // first audio manager will be set here, and once instance is destroyed, the next one to come up will be set here again
            instance = this;
        }
        else if (game)
        {
            // once main game starts, instance is destroyed
            Destroy(instance.gameObject);
        }
        else {
            // manager is carried over, we don't need this new one
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

    // play first song which is background music and is looped
    void Start()
    {
        Play("Song1");
    }

    // play specific sound
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { Debug.LogWarning("Sound: " + name + " is not valid!"); return; }   // incorrect sound name being called
        s.source.Play();
    }
}
