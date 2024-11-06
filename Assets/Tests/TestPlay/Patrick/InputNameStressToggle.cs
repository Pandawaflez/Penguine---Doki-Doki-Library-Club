using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TMPro;

public class PatrickInputNameToggleStressTest
{
    [UnityTest]
    public IEnumerator StressTest_FrequentInputFieldToggle()
    {
        // Arrange: Create a GameObject for the input field and set it up.
        var inputFieldObject = new GameObject("InputField");
        inputFieldObject.AddComponent<RectTransform>();  // Needed for UI elements.
        
        var inputField = inputFieldObject.AddComponent<TMP_InputField>();  // Add TMP InputField.
        var textComponent = new GameObject("Text").AddComponent<TextMeshProUGUI>();  // Text component for TMP InputField.
        inputField.textComponent = textComponent;  // Assign text component.

        var inputName = new InputName(inputFieldObject);  // Create InputName instance.

        int toggleCount = 100000;  // Number of show/hide cycles.

        //Rapidly show and hide the input field.
        for (int i = 0; i < toggleCount; i++)
        {
            inputName.Show();  //Show the input field.
            inputName.Hide();  //Hide the input field.
        }

        yield return null;  // Wait a frame for Unity to process.

        // Assert: Ensure the input field is hidden at the end of the test.
        Assert.IsFalse(inputFieldObject.activeSelf, "Input field should be hidden at the end.");
    }
}