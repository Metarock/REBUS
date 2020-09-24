using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundArray;

    public static AudioManager instance;

    // Awake Function
    void Awake()
    {
        //For having only one instance of AudioManager
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in soundArray)
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
        Play("mainMenuTheme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(soundArray, sound => sound.name == name);

        //Error checking
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + "was not found.");
            return;
        }

        s.source.Play();

        //ADD THE CODE BELOW TO OTHER SCRIPTS TO PLAY SOUND
        //FindObjectOfType<AudioManager>().Play("InsertAudioNameHere");
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(soundArray, sound => sound.name == name);

        //Error checking
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "was not found.");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volume / 2f, s.volume / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitch / 2f, s.pitch / 2f));

        s.source.Stop();
    }
}
