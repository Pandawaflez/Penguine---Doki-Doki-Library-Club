using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class CarsonTalkToInvalidCharacter : MonoBehaviour
{
    
    private overworldDebugMenu debugMenu;

    [SetUp]
    public void Setup()
    {
        debugMenu = new GameObject().AddComponent<overworldDebugMenu>();
        SceneManager.LoadScene("Overworld"); // Load a dummy scene to avoid errors.
    }

    [UnityTest]
    public IEnumerator TalkToInvalidCharacter()
    {
        // Arrange
        string character = "UnknownCharacter";

        // Act
        debugMenu.talkTo(character);

        // Wait for the message to be logged
        yield return null;

        // Assert
        LogAssert.Expect(LogType.Log, "Character UnknownCharacter not found");
    }
}
