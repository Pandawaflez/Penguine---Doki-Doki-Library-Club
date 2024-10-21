//using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
            instance.name = "Reponse1_" + i; // Name the instances for debugging
            instance.transform.position = new Vector3(i * 2, 0, 0); // Spread them out
        }

        yield return null; // Allow the game objects to initialize

        // Assert that the correct number of instances are in the scene
        Assert.AreEqual(instanceCount, GameObject.FindObjectsOfType<Lucy>().Length, "Not all button response instances were created successfully.");
    }
}
