using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class CarsonTalkToInvalidCharacterStressTest : MonoBehaviour
{
    private overworldDebugMenu debugMenu;

    [SetUp]
    public void Setup()
    {
        debugMenu = new GameObject().AddComponent<overworldDebugMenu>();
        SceneManager.LoadScene("Overworld"); // Load scene
    }

    [UnityTest]
    public IEnumerator TalkToInvalidCharactersStressTest()
    {
        // Arrange
        string characterName = "InvalidCharacter";
        int counter = 0; //number of attempted character interactions

        // Stress Test:
        for (int i = 0; i < 10000; i++)
        {
            counter++;
            debugMenu.talkTo(characterName);
            yield return null; // Allow the system to process the call
        }

        // Assert
        Assert.AreEqual(debugMenu.numberOfAttemptedInteractions, counter, "Overworld Panel did not track all attempted interactions with characters.");
    }
}
