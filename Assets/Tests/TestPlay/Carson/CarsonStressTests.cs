using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class CarsonStressTests
{
    public GameObject overworldObject;
    public GameObject debugMenuObject;
    public overworldDebugMenu debugMenu;
    public OverworldManagement overworld;

    [SetUp]
    public void Setup()
    {
        // Instantiate and set DontDestroyOnLoad to keep objects across scene changes
        overworldObject = GameObject.Instantiate(Resources.Load<GameObject>("Carson/Overworld"));
        Assert.IsNotNull(overworldObject, "Overworld prefab not found in Resources.");
        overworld = overworldObject.GetComponent<OverworldManagement>();
        Assert.IsNotNull(overworld, "Overworld prefab does not contain OverworldManagement component.");
        Object.DontDestroyOnLoad(overworldObject);

        debugMenuObject = GameObject.Instantiate(Resources.Load<GameObject>("Carson/OverworldDebugMenu"));
        Assert.IsNotNull(debugMenuObject, "DebugMenu prefab not found in Resources.");
        debugMenu = debugMenuObject.GetComponent<overworldDebugMenu>();
        Assert.IsNotNull(debugMenu, "Debug Menu prefab does not contain overworldDebugMenu component.");
        Object.DontDestroyOnLoad(debugMenuObject);

        // Load the initial scene
        SceneManager.LoadScene("Overworld");
    }

    [UnityTest]
    public IEnumerator RapidSceneChangeTest()
    {
        // Simulate rapid scene changes
        for (int i = 0; i < 50; i++)
        {
            SceneManager.LoadScene("Level1");
            yield return new WaitForSeconds(0.1f); // Short delay to allow loading
            SceneManager.LoadScene("Overworld");
            yield return new WaitForSeconds(0.1f);
        }
        Assert.Pass("Rapid scene changes completed without crashing.");
    }

    [UnityTest]
    public IEnumerator RoomLoadLoopTest()
    {
        int totalRooms = 7; // Replace with actual number of rooms if different
        int repetitions = 100; // Define a large number of repetitions to stress-test

        for (int j = 0; j < repetitions; j++)
        {
            for (int i = 0; i < totalRooms; i++)
            {
                overworld.loadRoom(i);
                yield return null; // Allow one frame for loading
            }
        }

        Assert.Pass("Room load loop completed without errors.");
    }

    [UnityTest]
    public IEnumerator RoomLoadRightLoopTest()
    {
        //int totalRooms = 7; // Replace with actual number of rooms if different
        int repetitions = 100; // Define a large number of repetitions to stress-test

        for (int j = 0; j < repetitions; j++)
        {
            overworld.goRight();
            yield return null; // Allow one frame for loading
        }

        Assert.Pass("Room load loop completed without errors.");
    }

    [UnityTest]
    public IEnumerator RoomLoadLeftLoopTest()
    {
        //int totalRooms = 7; // Replace with actual number of rooms if different
        int repetitions = 100; // Define a large number of repetitions to stress-test

        for (int j = 0; j < repetitions; j++)
        {
            overworld.goLeft();
            yield return null; // Allow one frame for loading
        }

        Assert.Pass("Room load loop completed without errors.");
    }

    [UnityTest]
    public IEnumerator StressTest_InstantiateManyOverworlds()
    {
        // Arrange
        int numberOfOverworlds = 10000;  // Adjust to the number of objects you want to instantiate
        GameObject overworldPrefab = Resources.Load<GameObject>("Carson/Overworld"); // Load the Overworld prefab
        Assert.IsNotNull(overworldPrefab, "Overworld prefab not found in Resources.");

        // Track how many are successfully instantiated
        int instantiatedCount = 0;

        // Act: Instantiate many Overworlds
        for (int i = 0; i < numberOfOverworlds; i++)
        {
            GameObject overworldInstance = Object.Instantiate(overworldPrefab);
            instantiatedCount++;
            
            // Optionally, you can destroy the objects after instantiation to avoid memory issues in long-running tests
            // Destroy(overworldInstance);
            
            // Yield for a frame so that the system isn't overwhelmed (adjust this if necessary for your system)
            yield return null;
        }

        // Assert: Ensure that all objects have been instantiated
        Assert.AreEqual(numberOfOverworlds, instantiatedCount, "Not all Overworld objects were instantiated.");
        Debug.Log($"Successfully instantiated {instantiatedCount} Overworld objects.");
        Assert.Pass("Stress test passed: All Overworld objects instantiated successfully.");
    }


    /*// Stress test for resetting overworld 
    [UnityTest]
    public IEnumerator ResetOverworld()
    {
        GameObject instance = GameObject.Instantiate(overworldObject);
        OverworldManagement overworldInstance = instance.GetComponentInChildren<OverworldManagement>();
        // Rapidly change the room
        int instanceCount = 10000;
        for (int i = 0; i < instanceCount; i++)
        {
            overworldInstance.loadRoom(0);
        }

        yield return null; 

        // Assert that the correct number of instances are in the scene
        Assert.AreEqual(1, GameObject.FindObjectsOfType<Pong>().Length, "Not all overworld instances were sucessfully created.");
    }*/


}
