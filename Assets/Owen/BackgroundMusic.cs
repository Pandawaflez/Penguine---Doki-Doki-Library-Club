using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : Audio
{
    public string CharacterID { get; private set; }
    public string BackgroundID { get; private set; }

    public BackgroundMusic(string id, AudioClip clip, string characterID, string backgroundID, AudioSource source) 
        : base(id, clip, 1f, true, false, source)
    {
        CharacterID = characterID;
        BackgroundID = backgroundID;
    }

    public void Loop()
    {
        IsLooping = true;
        Play();
    }
    // Use of dynamic binding to fade out background music over 1 second.
    public override BackgroundMusic Stop()
    {
        AudioManager.Instance.StartCoroutine(FadeOutCoroutine(1f));
    }

    // Handle fading out in this class
    public void FadeOut(float duration)
    {
        AudioManager.Instance.StartCoroutine(FadeOutCoroutine(duration));
    }

    private IEnumerator FadeOutCoroutine(float duration)
    {
        float startVolume = Source.volume;

        while (Source.volume > 0)
        {
            Source.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        Source.Stop();
        Source.volume = startVolume; // Reset volume for future playbacks
    }
}

