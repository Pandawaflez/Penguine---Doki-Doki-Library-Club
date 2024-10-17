using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TMPro;

public class PatrickInputNameBreakStressTest
{
    [UnityTest]
    public IEnumerator StressTest_InputFieldOverflow()
    {
        // Arrange: Create the input field GameObject and setup components.
        var inputFieldObject = new GameObject("InputField");
        inputFieldObject.AddComponent<RectTransform>();  // Needed for UI elements.

        var inputField = inputFieldObject.AddComponent<TMP_InputField>();  // Add TMP InputField.
        var textComponent = new GameObject("Text").AddComponent<TextMeshProUGUI>();  // Text component.
        inputField.textComponent = textComponent;  // Assign the text component.

        var inputName = new InputName(inputFieldObject);  // Create InputName instance.
        var submitButton = new UISubmitButton(new GameObject(), inputName);  // Create submit button.

        int iteration = 0;
        bool testFailed = false;  // Track if the game "breaks" or an error is thrown.

        // Act: Perform stress test with large input sizes.
        while (!testFailed)
        {
            // Increase input length with 1000 'A's per iteration.
            inputField.text += new string('A', 1000);
            iteration++;

            try
            {
                // Call submit button's onClick to simulate input submission.
                submitButton.onClick();
            }
            catch (System.Exception e)
            {
                // Catch any exceptions and mark the test as failed.
                Debug.LogError($"Game broke on iteration {iteration} with input length {inputField.text.Length}.");
                Debug.LogError($"Exception: {e.Message}");
                testFailed = true;
                break;
            }

            // Log the progress to track iterations.
            Debug.Log($"Iteration {iteration}: Input length = {inputField.text.Length}");

            // Yield to the next frame to allow Unity to process the input.
            yield return null;
        }

        // Assert: If the game didn't crash, mark the test as failed.
        if (!testFailed)
        {
            Assert.Fail($"Test ended without breaking the game after {iteration} iterations. Final input length: {inputField.text.Length}.");
        }
    }
}