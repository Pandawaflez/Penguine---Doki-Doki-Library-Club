using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarlaTestPlay
{
    // A Test behaves as an ordinary method
    [Test]
    public void CarlaTestPlaySimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CarlaTestPlayWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

//test for hitting 2 buttons at once
public class ButtonInteractionTest //: MonoBehaviour
{
    public Button button1;  // Assign these buttons via the Unity Inspector or dynamically in the test
    public Button button2;

    private bool button1Clicked = false;
    private bool button2Clicked = false;

    [UnityTest]
    public IEnumerator TestSimultaneousButtonPresses()
    {
        // Step 1: Assign the OnClick listeners (if not done in the editor).
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);

        // Step 2: Simulate "simultaneous" button clicks.
        button1.onClick.Invoke(); // Trigger button 1
        button2.onClick.Invoke(); // Immediately trigger button 2

        // Step 3: Wait one frame to process events.
        yield return null;

        // Step 4: Verify that only one button was processed (adjust logic for your case).
        Assert.IsTrue(button1Clicked ^ button2Clicked, 
            "Only one button should register a click."); // XOR ensures only one is true.

        // Clean up listeners to avoid memory leaks.
        button1.onClick.RemoveListener(OnButton1Click);
        button2.onClick.RemoveListener(OnButton2Click);
    }

    // Button 1 action
    private void OnButton1Click()
    {
        Debug.Log("Button 1 was clicked.");
        button1Clicked = true;
    }

    // Button 2 action
    private void OnButton2Click()
    {
        Debug.Log("Button 2 was clicked.");
        button2Clicked = true;
    }
}

/*
public class ButtonStateTest : MonoBehaviour
{
    public Button button1;  // Assign these via the Inspector
    public Button button2;

    private string button1Key = "Button1Disabled";
    private string button2Key = "Button2Disabled";

    [UnityTest]
    public IEnumerator TestButtonStatePersistence()
    {
        // Step 1: Ensure buttons are initially enabled
        PlayerPrefs.DeleteKey(button1Key);
        PlayerPrefs.DeleteKey(button2Key);
        yield return null; // Wait a frame to update UI

        Assert.IsTrue(button1.interactable, "Button 1 should be enabled initially.");
        Assert.IsTrue(button2.interactable, "Button 2 should be enabled initially.");

        // Step 2: Simulate button clicks to disable them
        button1.onClick.Invoke();
        button2.onClick.Invoke();
        yield return null;

        // Verify buttons are now disabled
        Assert.IsFalse(button1.interactable, "Button 1 should be disabled after clicking.");
        Assert.IsFalse(button2.interactable, "Button 2 should be disabled after clicking.");

        // Step 3: Simulate a revisit by reloading the state
        button1.interactable = true;
        button2.interactable = true;
        yield return null;  // Reset state (simulates scene reload)

        // Reload state using the same logic from the original script
        LoadButtonState();

        // Verify buttons are still disabled after reload
        Assert.IsFalse(button1.interactable, "Button 1 should remain disabled on revisit.");
        Assert.IsFalse(button2.interactable, "Button 2 should remain disabled on revisit.");
    }

    // Helper method to mimic the original LoadButtonState() logic
    private void LoadButtonState()
    {
        if (PlayerPrefs.GetInt(button1Key, 0) == 1)
        {
            button1.interactable = false;
        }
        if (PlayerPrefs.GetInt(button2Key, 0) == 1)
        {
            button2.interactable = false;
        }
    }
}
*/

//stress test: memory

public class MemoryLeakTest //: MonoBehaviour
{
    public GameObject characterPrefab;  // Assign a character prefab via the Inspector
    private const int testIterations = 50;  // Number of interactions to simulate

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
            
            GameObject character = new GameObject();


            // Step 2: Simulate interaction (if needed)
            yield return new WaitForSeconds(0.1f);  // Small delay to simulate user interaction

            // Step 3: Destroy character after interaction (simulates leaving the scene)
            GameObject.DestroyImmediate(character);
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

        Assert.LessOrEqual(memoryDifference, 1024 * 10, 
            "Memory leak detected! Memory increased significantly after interactions.");
    }

    // Helper method to get the total allocated memory in bytes
    private long GetTotalAllocatedMemory()
    {
        return UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong();
    }
}


}
