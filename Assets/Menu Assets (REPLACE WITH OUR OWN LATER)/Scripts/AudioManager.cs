using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer theMixer;
    public Sound[] sounds;
    public AudioMixerGroup SFX;
    public AudioMixerGroup Music;
    public AudioMixerGroup Master;
    //public AudioSource.AudioMixerGroup outputAudioMixerGroup;


    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            if (s.output == "SFX")
            {
                s.source.outputAudioMixerGroup = SFX;
            }
            if (s.output == "Music")
            {
                s.source.outputAudioMixerGroup = Music;
            }
            if (s.output == "Master")
            {
                s.source.outputAudioMixerGroup = Master;
            }
            //s.source.outputAudioMixerGroup = s.output;
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
