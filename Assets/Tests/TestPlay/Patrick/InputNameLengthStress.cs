using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TMPro;
using UnityEngine.UI;  // For Canvas, CanvasScaler, and GraphicRaycaster
using UnityEngine.SceneManagement;



public class PatrickSubmitNameButtonStress
{
    [UnityTest]
    public IEnumerator StressTest_SimulateInputNamePressButtonRapid()
    {
        // Arrange: Create a Canvas to host the input field.
        var canvasObject = new GameObject("Canvas");
        var canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;  // Ensure the Canvas is rendered correctly.
        canvasObject.AddComponent<CanvasScaler>();  // Optional: For scaling UI elements.
        canvasObject.AddComponent<GraphicRaycaster>();  // Required for UI interaction.

        // Create the InputField GameObject.
        var inputFieldObject = new GameObject("InputField");
        inputFieldObject.transform.SetParent(canvas.transform);  // Attach to Canvas.

        // Add the TMP_InputField component.
        var inputField = inputFieldObject.AddComponent<TMP_InputField>();

        // Create a TextMeshProUGUI component for displaying the input text.
        var textComponentObject = new GameObject("TextComponent");
        var textComponent = textComponentObject.AddComponent<TextMeshProUGUI>();
        textComponentObject.transform.SetParent(inputFieldObject.transform);  // Attach to InputField.

        // Assign the TextMeshProUGUI component to the input field.
        inputField.textComponent = textComponent;

        // Set up the InputName and SubmitButton.
        var inputName = new InputName(inputFieldObject);
        var submitButton = new UISubmitButton(new GameObject(), inputName);

        int iteration = 0;
        bool testFailed = false;  // Track if the game breaks.

        // Act: Continuously increase input size and submit.
        while (!testFailed)
        {
            // Add 1000 'A's to the input field text each iteration.
            inputField.text += new string('A', 100);
            iteration++;

            try
            {
                // Simulate clicking the submit button.
                submitButton.onClick();

                MainPlayer.SetPlayerName(inputField.text);

                // Verify the input was stored in MainPlayer.
                string storedName = MainPlayer.GetPlayerName();

                // Log the progress for tracking.
                Debug.Log($"Iteration {iteration}: Stored name length = {storedName.Length}, {storedName}");

                // Ensure the stored name matches the input field text.
                if (storedName.Length != inputField.text.Length)
                {
                    throw new System.Exception("Stored name length does not match input field length.");
                }
            }
            catch (System.Exception e)
            {
                // Log the error and mark the test as failed.
                Debug.LogError($"Game broke at iteration {iteration} with input length {inputField.text.Length}.");
                Debug.LogError($"Exception: {e.Message}");
                testFailed = true;
                break;
            }

            // Yield to let Unity process the frame.
            yield return null;
        }

        // Assert: If the game didn't crash, mark the test as failed.
        if (!testFailed)
        {
            Assert.Fail($"Test ended without breaking after {iteration} iterations. Final input length: {inputField.text.Length}.");
        }
    }
}