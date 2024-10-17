using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioLibrary audioLibrary;

    private AudioSource audioSource;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("AudioManager");
                    instance = obj.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate AudioManager
            return;
        }

        instance = this; // Set as the singleton instance
        DontDestroyOnLoad(gameObject);

        audioLibrary = gameObject.AddComponent<AudioLibrary>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(string soundID)
    {
        AudioClip clip = audioLibrary.GetAudioClip(soundID);
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound ID not found: " + soundID);
        }
    }

    public void StopSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    /*

        Might need to change this, look for delaying as well

    */

    // Play audio for a specific duration
    public void PlayForDuration(DialogueSound dialogueSound, float duration)
    {
        dialogueSound.PlayForDuration(duration);
    }

    // Delegate fadeOut handling to BackgroundMusic class
    public void FadeOutMusic(BackgroundMusic backgroundMusic, float duration)
    {
        backgroundMusic.FadeOut(duration);
    }
}
    