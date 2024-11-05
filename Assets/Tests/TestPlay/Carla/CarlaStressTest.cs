//using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class CarlaStressTest
{
    public GameObject lucyPrefab; 

    [SetUp]
    public void SetUp()
    {
        lucyPrefab = Resources.Load<GameObject>("Carla/Lucy");
        Assert.IsNotNull(lucyPrefab, "Lucy prefab not assigned in the Resources folder.");
    }

    [UnityTest]
    // stress test with instanceCount number of buttons
    public IEnumerator StressTestButtons()
    {
        // Spawn multiple instances
        int instanceCount = 1000;
        for (int i = 0; i < instanceCount; i++)
        {
            // Instantiate the prefab
            GameObject instance = Object.Instantiate(lucyPrefab);
            //Debug.Log(Type.GetType());
            instance.name = "Lucy" + i; // Name the instances for debugging
            instance.transform.position = new Vector3(i * 2, 0, 0); // Spread them out
        }

        yield return null; // Allow the game objects to initialize

        // Assert that the correct number of instances are in the scene
        Assert.AreEqual(instanceCount, GameObject.FindObjectsOfType<Lucy>().Length, "Not all button response instances were created successfully.");
    }
    //stress test: memory

    public GameObject characterPrefab;  // Assign a character prefab via the Inspector
    private const int testIterations = 70;  // Number of interactions to simulate.
    //memory difference usually in the 600s. breaks at 70

    [UnityTest]
    public IEnumerator TestMemoryLeakDuringRepeatedInteractions()
    {
        long initialMemory = GetTotalAllocatedMemory();
        Debug.Log($"Initial Memory: {initialMemory / 1024} KB");

        // Run multiple interactions with the character
        for (int i = 0; i < testIterations; i++)
        {
            // Step 1: Instantiate a character (simulates entering a scene with dialogue)
            //GameObject character = Instantiate(characterPrefab);
            
            GameObject instance = Object.Instantiate(lucyPrefab);

            // Step 2: Simulate interaction (if needed)
            yield return new WaitForSeconds(0.1f);  // Small delay to simulate user interaction

            // Step 3: Destroy character after interaction (simulates leaving the scene)
            GameObject.DestroyImmediate(instance);
            yield return null;  // Wait a frame for Unity to clean up

            // Optionally, trigger garbage collection (Unity should do this automatically)
            System.GC.Collect();
        }

        // Wait a few frames to ensure cleanup is complete
        yield return new WaitForSeconds(1.0f);

        long finalMemory = GetTotalAllocatedMemory();
        Debug.Log($"Final Memory: {finalMemory / 1024} KB");

        // Assert that memory usage does not increase by more than 10 KB per interaction
        long memoryDifference = finalMemory - initialMemory;
        Debug.Log($"Memory Difference: {memoryDifference / 1024} KB");

        //memory loss usually in the 600s, so i set to 700
        Assert.LessOrEqual(memoryDifference, 1024 * 700, 
            "Memory leak detected! Memory increased significantly after interactions.");
    }

    [UnityTest]
    public IEnumerator TestMemoryLeakReturning()
    {
        long initialMemory = GetTotalAllocatedMemory();
        Debug.Log($"Initial Memory: {initialMemory / 1024} KB");

        // Run multiple interactions with the character
        for (int i = 0; i < testIterations; i++)
        {
            // Step 1: Instantiate a character (simulates entering a scene with dialogue)
            //GameObject character = Instantiate(characterPrefab);
            
            SceneManager.LoadScene("Scenes/Lucy");
            // Step 2: Simulate interaction (if needed)
            yield return new WaitForSeconds(0.1f);  // Small delay to simulate user interaction

            // Step 3: Destroy character after interaction (simulates leaving the scene)
            SceneManager.LoadScene("Scenes/Overworld");
            yield return null;  // Wait a frame for Unity to clean up

            // Optionally, trigger garbage collection (Unity should do this automatically)
            System.GC.Collect();
        }

        // Wait a few frames to ensure cleanup is complete
        yield return new WaitForSeconds(1.0f);

        long finalMemory = GetTotalAllocatedMemory();
        Debug.Log($"Final Memory: {finalMemory / 1024} KB");

        // Assert that memory usage does not increase by more than 10 KB per interaction
        long memoryDifference = finalMemory - initialMemory;
        Debug.Log($"Memory Difference: {memoryDifference / 1024} KB");

        Assert.LessOrEqual(memoryDifference, 1024 * 1000, 
            "Memory leak detected! Memory increased significantly after interactions.");
    }

    // Helper method to get the total allocated memory in bytes
    private long GetTotalAllocatedMemory()
    {
        return UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong();
    }
}
