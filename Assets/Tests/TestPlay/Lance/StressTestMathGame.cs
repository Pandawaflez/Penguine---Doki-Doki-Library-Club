using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Lance_StressTestMathGame
{
    public GameObject mathPrefab;

    [SetUp]
    public void SetUp()
    {
        mathPrefab = Resources.Load<GameObject>("Lance/MathPrefab");
        Assert.IsNotNull(mathPrefab, "Math prefab not assigned in the Resources folder.");
    }

    [UnityTest]
    public IEnumerator TestMultipleMathGameInstances()
    {
        // Spawn multiple instances
        int instanceCount = 5000;
        for (int i = 0; i < instanceCount; i++)
        {
            // Instantiate the prefab
            GameObject instance = Object.Instantiate(mathPrefab);
            instance.name = "MathInstance_" + i; // Name the instances for debugging
            instance.transform.position = new Vector3(i * 2, 0, 0); // Spread them out
        }

        yield return null; // Allow the game objects to initialize

        // Assert that the correct number of instances are in the scene
        Assert.AreEqual(instanceCount, GameObject.FindObjectsOfType<Math>().Length, "Not all math game instances were created successfully.");
    }
}
