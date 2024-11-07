using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TMPro;

public class PatrickValidNameInputBoundary
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ValidPlayerNameInput_ShouldSetPlayerName()
    {
        //Arrange
        var inputFieldObject = new GameObject("InputField");
        inputFieldObject.AddComponent<RectTransform>(); // Necessary for UI elements

        //Add TextMeshPro Input Field
        var inputField = inputFieldObject.AddComponent<TMP_InputField>();

        //Create InputName and UISubmitButton
        var inputName = new InputName(inputFieldObject);
        var submitButton = new UISubmitButton(new GameObject(), inputName);

        // Set player name
        inputField.text = "Alice";

        //Act: ensure that valid names that are not empty and in range of input field are valid
        submitButton.v_onClick();

        //Assert
        yield return null; // Wait a frame
        Assert.AreEqual("Alice", MainPlayer.GetPlayerName());
    }
}