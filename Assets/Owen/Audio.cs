using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio
{
    public string ID { get; private set; }
    public AudioClip Clip { get; private set; }
    public float Volume { get; set; }
    public bool IsLooping { get; set; }

    protected AudioSource Source { get; set; }

    public Audio(string id, AudioClip clip, float volume = 1f, bool isLooping = false, bool playOnAwake = false, AudioSource source = null)
    {
        ID = id;
        Clip = clip;
        Volume = volume;
        IsLooping = isLooping;
        Source = source;

        if (playOnAwake && Source != null)
        {
            Play();
        }
    }

    public virtual void Play()
    {
        if (Source != null && Clip != null)
        {
            Source.clip = Clip;
            Source.volume = Volume;
            Source.loop = IsLooping;
            Source.Play();
        }
    }

    public virtual void Stop()
    {
        if (Source != null)
        {
            Source.Stop();
        }
    }
}
