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
        IsLooping = true;  // Set looping via the property in audio
        Play();            // Use the inherited play method
    }

    public override void Stop()
    {
        AudioManager.Instance.StartCoroutine(FadeOutCoroutine(1f));
    }

    public void FadeOut(float duration)
    {
        AudioManager.Instance.StartCoroutine(FadeOutCoroutine(duration));
    }

    private IEnumerator FadeOutCoroutine(float duration)
    {
        float startVolume = Volume; // Access volume via the audio property

        while (Volume > 0)
        {
            Volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        Stop();                      // Use the inherited Stop method
        Volume = startVolume;        // Reset volume for future playbacks
    }
}
