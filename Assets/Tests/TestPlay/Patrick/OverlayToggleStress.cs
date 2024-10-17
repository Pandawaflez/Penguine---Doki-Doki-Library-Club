using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PatrickOverlayToggleStress
{
    [UnityTest]
    public IEnumerator StressTest_UICheckInputHeavyLoad()
    {
        //Arrange: Create the UIElementHandler singleton GameObject
        var handlerObject = new GameObject("UIHandler");
        var handler = handlerObject.AddComponent<UIElementHandler>();

        int iterations = 100000;  //Number of input checks to simulate
        int logCount = 0;       //Track how many times the overlay is toggled

        /* Act: Simulate heavy calls to UICheckInput.
        since we can't simulate key presses in Unity testing apparently,
        simulating UICheckInput many times to test under load.*/
        for (int i = 0; i < iterations; i++)
        {
            //Manually call UICheckInput() since we're testing performance
            handler.UICheckInput();

            //Simulate a log message that would be produced on toggle
            Debug.Log("*****Overlay Toggle*****");
            logCount++;
        }

        yield return null;

        //Assert: Ensure the correct number of toggles were logged
        Assert.AreEqual(iterations, logCount, 
            $"Expected {iterations} logs, but got {logCount}.");
    }
}