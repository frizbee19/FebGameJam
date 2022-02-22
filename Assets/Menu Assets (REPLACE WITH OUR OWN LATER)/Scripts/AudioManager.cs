using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer theMixer;
    public Sound[] sounds;
    

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            theMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
        }
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
        }
        if (PlayerPrefs.HasKey("SFXVol"))
        {
            theMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }
}
