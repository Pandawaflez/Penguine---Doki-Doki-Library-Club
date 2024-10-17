using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    private Dictionary<string, AudioClip> audioClips;

    void Awake()
    {
        audioClips = new Dictionary<string, AudioClip>();
        LoadAudioClips();
    }

    private void LoadAudioClips()
    {
        // List of audio files to load (add your file names here)
        string[] audioFiles = { "charliebrown", "lucy", "victory", /* Add more filenames here */ };

        foreach (var file in audioFiles)
        {
            AudioClip clip = Resources.Load<AudioClip>("Audio/" + file);
            if (clip != null)
            {
                audioClips[file] = clip;
            }
            else
            {
                Debug.LogWarning("Audio file not found: " + file);
            }
        }
    }

    public AudioClip GetAudioClip(string id)
    {
        audioClips.TryGetValue(id, out var clip);
        return clip;
    }
}
