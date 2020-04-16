using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using SysObj = System.Object;

public class AudioManager : Singleton <AudioManager>
{
    [SerializeField]
    private AudioDatabase audio;

    Dictionary<string, AudioClip> audioDictionary = new Dictionary<string, AudioClip>();

    AudioSource bgmAudio;
    List<AudioSource> sfxAudio = new List<AudioSource>();

    protected override void OnAwake()
    {
        base.OnAwake();
        this.audio = Resources.Load<AudioDatabase>("ScriptableObject/AudioDatabase");

        bgmAudio = GameObject.AddComponent<AudioSource>();

        for (int i = 0; i < 5; i++)
        {
            GameObject obj = new GameObject();
            obj.name = "SFX (" + i + ")";
            AudioSource sfx = obj.AddComponent<AudioSource>();
            sfx.playOnAwake = false;
            sfxAudio.Add(sfx);
            obj.transform.SetParent(Transform);
        }

        for (int i = 0; i < audio.AudioDB.Length; i++)
            audioDictionary.Add(audio.AudioDB[i].Id, audio.AudioDB[i].Audio);
    }


    public void PlaySFX(string id)
    {
        for (int i = 0; i < sfxAudio.Count; i++)
        {
            if (!sfxAudio[i].isPlaying)
            {
                sfxAudio[i].clip = audioDictionary[id];
                sfxAudio[i].Play();

                return;
            }
        }
    }

    public void PlaySFXLoop(string id)
    {
        for (int i = 0; i < sfxAudio.Count; i++)
        {
            if (!sfxAudio[i].isPlaying)
            {
                sfxAudio[i].clip = audioDictionary[id];
                sfxAudio[i].loop = true;
                sfxAudio[i].Play();
                return;
            }
        }
    }

    public void StopSFX(string id)
    {
        for (int i = 0; i < sfxAudio.Count; i++)
        {
            if (sfxAudio[i].isPlaying)
            {
                if (sfxAudio[i].clip.name == audioDictionary[id].name)
                {
                    sfxAudio[i].clip = audioDictionary[id];
                    sfxAudio[i].loop = false;
                    sfxAudio[i].Stop();
                }
                return;
            }
        }
    }
    public void StopSFXAll()
    {
        for (int i = 0; i < sfxAudio.Count; i++)
        {
            if (sfxAudio[i].isPlaying)
            {
                sfxAudio[i].loop = false;
                sfxAudio[i].Stop();

                return;
            }
        }
    }

    public void StopBGM()
    {
        bgmAudio.Stop();
    }

    public void PlayBGM(string p_id = "")
    {
        if (p_id != null)
            bgmAudio.clip = audioDictionary[p_id];
    }
}