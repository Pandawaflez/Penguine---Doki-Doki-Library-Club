using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OwenTestAudioVolumeAboveOne
{
    private AudioManager audioManager;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        // Create the AudioManager GameObject for the test
        var audioManagerObj = new GameObject("AudioManager");
        audioManager = audioManagerObj.AddComponent<AudioManager>();

        // Add an AudioListener to the GameObject if none exists
        if (GameObject.FindObjectOfType<AudioListener>() == null)
        {
            audioManagerObj.AddComponent<AudioListener>();
        }
    }

    [UnityTest]
    public IEnumerator TestAudioVolumeAboveOne()
    {
        // Load the peanuts_teacher.mp3 file
        AudioClip peanutsClip = Resources.Load<AudioClip>("Owen/Peanuts/peanuts_teacher");

        // Ensure the clip is found
        Assert.IsNotNull(peanutsClip, "Audio file not found: Owen/Peanuts/peanuts_teacher");

        // Create an AudioSource and attach the AudioClip
        GameObject audioSourceObject = new GameObject("TestAudioSource");
        AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
        audioSource.clip = peanutsClip;

        // Set a negative volume and verify the behavior
        audioSource.volume = 2f;

        // Create a DialogueSound and set it with a volume of 2
        DialogueSound dialogueSound = new DialogueSound("Peanuts_Teacher", peanutsClip, "CharlieBrown", "Classroom", audioSource);

        // Play the sound
        dialogueSound.Play();

        // Wait for a short duration to ensure the sound plays or fails to play
        yield return new WaitForSeconds(0.5f);

        // Check that the volume is clamped to 0 or higher
        Assert.LessOrEqual(audioSource.volume, 1f, "Volume should not be above 1.");

        // Optionally, check if the audio is playing (or stopped due to invalid volume)
        Assert.IsTrue(audioSource.isPlaying, "Audio should play even if the volume was set to a value greater than 1, but clamped.");
    }
}