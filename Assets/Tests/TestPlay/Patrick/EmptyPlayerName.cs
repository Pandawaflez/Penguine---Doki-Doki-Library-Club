using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class PatrickEmptyPlayerNameBoundary
{
    [UnityTest]
    public IEnumerator EmptyPlayerName_ShouldNotSetPlayerName()
    {
        //Create a new GameObject and add the required components.
        var inputFieldObject = new GameObject("InputField");
        inputFieldObject.AddComponent<RectTransform>(); // TMP InputFields need a RectTransform.
        
        var inputField = inputFieldObject.AddComponent<TMP_InputField>(); //Add InputField.

        //create input and submit button
        var inputName = new InputName(inputFieldObject);
        var submitButton = new UISubmitButton(new GameObject(), inputName);

        //Act: Leave the input field empty and click the submit button.
        inputField.text = ""; 
        submitButton.v_onClick();

        //Assert: Ensure the player name remains unset and the log message is correct.
        yield return null; // Wait a frame for Unity’s event loop.

        Assert.AreNotEqual("", MainPlayer.GetPlayerName()); // Assuming the default name is non-empty or unset.
        LogAssert.Expect(LogType.Log, "Please enter a valid name.");
    }
}
