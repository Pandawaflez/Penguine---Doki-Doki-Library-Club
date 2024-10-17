using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoobStressTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ScoobStressTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ScoobStressTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}

//stress test
public class MemoryLeakTest
{
    public GameObject testPrefab;
    private const int testIterations = 39;
    

    [UnityTest]

    public IEnumerator MemoryLeakDuringRepeatSelections()
    {

        long initialMemory = GetTotalAllocatedMemory();
        Debug.Log($"Initial memeory: {initialMemory / 1024} KB");

        for (int i = 0; i < testIterations; i++){
            GameObject character = InstantiateCharacter();

            yield return new WaitForSeconds(0.1f);

            DestroyCharacter(character);

            System.GC.Collect();

            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        long finalMemory = GetTotalAllocatedMemory();
        Debug.Log($"Final Memory: {finalMemory / 1024} KB:");

        long memoryDifference = finalMemory - initialMemory;
        Debug.Log($"Memory Difference: {memoryDifference / 1024} KB");

        Assert.LessOrEqual(memoryDifference, 1024 * 10, "Memory leak detected");

    }

    private GameObject InstantiateCharacter(){
        if (testPrefab != null){
            return Object.Instantiate(testPrefab);
        }

        else{
            return new GameObject("LeakedCharacter");
        }
    }

    private void DestroyCharacter(GameObject character){
        if (character != null){
            Object.DestroyImmediate(character);
        }
    }

    private long GetTotalAllocatedMemory(){
        return UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong();
    }

}