﻿using UnityEngine;
using System;
using UnityEngine.Audio;

public class SoundManager : GenericSingleton<SoundManager>
{
    public static SoundManager Instance { get { return _instance; } }
    private static SoundManager _instance;

    public SoundClass[] Sounds;
    // Use this for initialization
    public override void Awake()
    {
        foreach (SoundClass s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.vol;
            s.source.pitch = s.pitch;
            s.source.loop = s.Loop;
            s.source.playOnAwake = s.PlayOnAwake;
        }

        //if (_instance != null && _instance != this)
        //{
        //    Destroy(this.gameObject);
        //    return;//Avoid doing anything else
        //}
        //if (_instance == null)
        //{
        //    _instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}

    }

    public void changePitch(string name, float pitch)
    {
        SoundClass s = Array.Find(Sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found...");
            return;
        }
        if (pitch >= 3.0f)
        {
            pitch = 3.0f;
        }
        s.source.pitch = pitch;
    }

    public void Play(string name)
    {
        SoundClass s = Array.Find(Sounds, Sound => Sound.name == name);
        if (s == null) 
        {
            Debug.LogWarning("Sound: " + name + " not found...");
            return;

        }

        s.source.Play();
    }

    public void Play2(string name)
    {

        SoundClass s = Array.Find(Sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found...");
            return;
        }
        if (s.source.isPlaying == false)
        {
            s.source.Play();
        }

    }

    public void Stop(string name)
    {

        SoundClass s = Array.Find(Sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found...");
            return;
        }
        s.source.Stop();
    }
}
