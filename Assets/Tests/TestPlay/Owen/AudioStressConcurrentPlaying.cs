using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OwenStressTestConcurrentAudio
{
    private AudioClip clip;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        // Load the audio clip
        clip = Resources.Load<AudioClip>("Owen/Peanuts/peanuts_teacher");
        Assert.IsNotNull(clip, "Audio file not found: Owen/Peanuts/peanuts_teacher");

        // Create the AudioManager GameObject for the test
        var audioManagerObj = new GameObject("AudioManager");
        audioManagerObj.AddComponent<AudioManager>();

        // Add an AudioListener to the GameObject if none exists
        if (GameObject.FindObjectOfType<AudioListener>() == null)
        {
            audioManagerObj.AddComponent<AudioListener>();
        }
    }

    [UnityTest]
    public IEnumerator TestConcurrentAudioPlayback()
    {
        int maxConcurrentAudioSources = 5; 
        bool testFailed = false;

        while (!testFailed)
        {
            // Re-add an AudioListener at the beginning of each iteration
            if (GameObject.FindObjectOfType<AudioListener>() == null)
            {
                var audioManagerObj = new GameObject("AudioManager");
                audioManagerObj.AddComponent<AudioListener>();
            }

            // Create and play multiple audio sources
            for (int i = 0; i < maxConcurrentAudioSources; i++)
            {
                GameObject audioSourceObject = new GameObject($"TestAudioSource_{i}");
                AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
                audioSource.clip = clip;
                audioSource.volume = Random.Range(0.99f, 1f); // Random volume between 0.1 and 1
                audioSource.pitch = Random.Range(0.99f, 1.01f); // Random pitch between 0.5 and 2
                audioSource.Play();

                Debug.Log($"Playing audio source {i}: {audioSource.isPlaying}");

                // Wait a short duration before starting the next audio source
                yield return null; // This allows the next frame to start
            }

            // Allow some time for all audio clips to play
            yield return new WaitForSeconds(1f);

            // Assert that the maximum number of audio sources is reached and playing
            var playingCount = 0;

            // Check how many audio sources are still playing
            foreach (var source in GameObject.FindObjectsOfType<AudioSource>())
            {
                if (source.isPlaying)
                {
                    playingCount++;
                }
            }

            Debug.Log($"Max Concurrent Audio Sources: {maxConcurrentAudioSources}, Playing Count: {playingCount}");

            // If the count is less than expected, we set the test to fail
            if (playingCount < maxConcurrentAudioSources - 5)
            {
                Debug.LogError($"Test failed at {maxConcurrentAudioSources} sources.");
                testFailed = true;

                // Log the failure in the test runner
                Assert.Fail($"Test failed at {maxConcurrentAudioSources} sources. Playing count: {playingCount}");
            }
            else
            {
                // Double the number of sources for the next iteration
                maxConcurrentAudioSources *= 2;

                // Cleanup audio sources
                foreach (var source in GameObject.FindObjectsOfType<AudioSource>())
                {
                    GameObject.Destroy(source.gameObject);
                }
            }

            // Allow some time for cleanup before the next iteration
            yield return new WaitForSeconds(0.5f);
        }

        // If the loop exits, assert failure
        Assert.Fail("Test reached the maximum number of concurrent audio sources without playing.");
    }
}
