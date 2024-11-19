using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio
{
    // Private nested AudioData class to hold audio data
    private class AudioData
    {
        public AudioSource Source { get; private set; }
        public AudioClip Clip { get; private set; }
        public float Volume { get; set; }
        public bool IsLooping { get; set; }

        public AudioData(AudioSource source, AudioClip clip, float volume, bool isLooping)
        {
            Source = source;
            Clip = clip;
            Volume = volume;
            IsLooping = isLooping;
        }

        public void Play()
        {
            Source.clip = Clip;
            Source.volume = Volume;
            Source.loop = IsLooping;
            Source.Play();
        }

        public void Stop()
        {
            Source.Stop();
        }

        public bool IsPlaying()
        {
            return Source.isPlaying;
        }
    }

    private AudioData audioData;

    public string ID { get; private set; }

    public Audio(string id, AudioClip clip, float volume = 1f, bool isLooping = false, bool playOnAwake = false, AudioSource source = null)
    {
        ID = id;
        audioData = new AudioData(source, clip, volume, isLooping);

        if (playOnAwake)
        {
            Play();
        }
    }

    public virtual void Play()
    {
        audioData.Play();
    }

    public virtual void Stop()
    {
        audioData.Stop();
    }

    public bool IsPlaying()
    {
        return audioData.IsPlaying();
    }

    // Expose volume and loop settings through public properties if needed
    public float Volume
    {
        get => audioData.Volume;
        set => audioData.Volume = value;
    }

    public bool IsLooping
    {
        get => audioData.IsLooping;
        set => audioData.IsLooping = value;
    }
}