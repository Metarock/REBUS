using UnityEngine.Audio;
<<<<<<< HEAD
using System;
using UnityEngine;
using UnityEngine.UI;
=======
using UnityEngine.SceneManagement;
using System;
using UnityEngine;
>>>>>>> 1bf3c182e37c7f006a66bf03a16fc9015e9ea5ee

public class AudioManager : MonoBehaviour
{
    public Sound[] soundArray;

    public static AudioManager instance;

<<<<<<< HEAD
    /*--------SANGGY NEW WORK -----------*/
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectSlider;
    private float backgroundFloat, soundEffectFloat;


    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    /*--------------------------*/
=======
>>>>>>> 1bf3c182e37c7f006a66bf03a16fc9015e9ea5ee
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
<<<<<<< HEAD
        Play("mainMenuTheme");

        /*-----------NEW THINGG---------------*/ 
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backgroundFloat = .125f;
            soundEffectFloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectSlider.value = soundEffectFloat;
            //PlayerPrefs save values through different scenes and play session 
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectSlider.value = soundEffectFloat;
        }
        /*--------------------------*/
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        backgroundSlider.value = backgroundFloat;
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectSlider.value);
        soundEffectSlider.value = soundEffectFloat;
    }

    //SAVES SLIDER VALUE 
    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            SaveSoundSettings();
        }
    }
    //UPDATES Slider value
    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectSlider.value;
        }
    }

    /*--------------------------*/
=======
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            Play("mainMenuTheme");
        }
        else
        {
            Play("levelTheme");
        }
    }

>>>>>>> 1bf3c182e37c7f006a66bf03a16fc9015e9ea5ee
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
<<<<<<< HEAD


/*public Sound[] soundArray;

public static AudioManager instance;

// Awake Function
void Awake()
{
    //For having only one instance of AudioManager
    if (instance == null)
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
    if (s == null)
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
}*/
=======
>>>>>>> 1bf3c182e37c7f006a66bf03a16fc9015e9ea5ee
