using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;

    void Start()
    {
        Play("BGM");
    }

    
    void Awake()
    {

        // makes audio manager persist between scenes
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;

        }


        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
        
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + s + "is Invalid!");
            return;
        }
        s.source.Play();
    }
}
