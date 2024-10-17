using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSound : Audio
{
    public string CharacterID { get; private set; }
    public string BackgroundID { get; private set; }

    public DialogueSound(string id, AudioClip clip, string characterID, string backgroundID, AudioSource source) 
        : base(id, clip, 1f, false, false, source)
    {
        CharacterID = characterID;
        BackgroundID = backgroundID;
    }

    // Play the sound for a specified duration
    public void PlayForDuration(float duration)
    {
        Play();
        AudioManager.Instance.StartCoroutine(StopAfterDurationCoroutine(duration));
    }

    //Coroutine function needed for IEnumerator
    private IEnumerator StopAfterDurationCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        Stop();
    }
}
