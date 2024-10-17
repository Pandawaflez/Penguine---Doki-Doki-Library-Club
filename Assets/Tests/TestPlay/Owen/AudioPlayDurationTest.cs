using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OwenTestAudioShortDuration
{
    private AudioManager audioManager;
    private DialogueSound dialogueSound;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        // Setup the AudioManager instance
        var audioManagerObj = new GameObject("AudioManager");
        audioManager = audioManagerObj.AddComponent<AudioManager>();

        // Ensure there is an AudioListener in the scene
        if (GameObject.FindObjectOfType<AudioListener>() == null)
        {
            audioManagerObj.AddComponent<AudioListener>();
        }
    }

    [UnityTest]
    public IEnumerator TestAudioShortDuration()
    {
        // Load the peanuts_teacher audio clip from Resources
        AudioClip peanutsClip = Resources.Load<AudioClip>("Owen/Peanuts/peanuts_teacher");
        Assert.IsNotNull(peanutsClip, "Failed to load peanuts_teacher audio clip.");

        // Create a DialogueSound instance with the loaded clip
        dialogueSound = new DialogueSound("peanuts_teacher", peanutsClip, "CharlieBrown", "Peanuts", audioManager.gameObject.AddComponent<AudioSource>());

        // Call PlayForDuration with 0.01f seconds
        dialogueSound.PlayForDuration(0.1f);

        // Wait for the clip to finish playing
        yield return new WaitForSeconds(0.1f); // Might need to adjust higher due to timing issues

       // Check if the sound has stopped after the duration using IsPlaying method
        Assert.IsFalse(dialogueSound.IsPlaying(), "The sound did not stop after the short duration.");
    }
}