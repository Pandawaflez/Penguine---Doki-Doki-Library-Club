using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class CarsonOverworldDebugMenuSceneChangeTests
{
    private overworldDebugMenu debugMenu;

    [SetUp]
    public void Setup()
    {
        debugMenu = new GameObject().AddComponent<overworldDebugMenu>();
        SceneManager.LoadScene("Overworld"); // Load a dummy scene to avoid errors.
    }

    [UnityTest]
    public IEnumerator TalkToCharlieTest()
    {
        // Arrange
        string character = "Charlie";

        // Act
        debugMenu.talkTo(character);

        // Wait for the scene change to take effect
        yield return null;

        // Assert
        Assert.AreEqual("Level1", SceneManager.GetActiveScene().name); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator TalkToLucyTest()
    {
        // Arrange
        string character = "Lucy";

        // Act
        debugMenu.talkTo(character);

        // Wait for the scene change to take effect
        yield return null;

        // Assert
        Assert.AreEqual("Lucy", SceneManager.GetActiveScene().name); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator TalkToSchroederTest()
    {
        // Arrange
        string character = "Schroeder";

        // Act
        debugMenu.talkTo(character);

        // Wait for the scene change to take effect
        yield return null;

        // Assert
        Assert.AreEqual("Schroeder", SceneManager.GetActiveScene().name); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator TalkToSnoopyTest()
    {
        // Arrange
        string character = "Snoopy";

        // Act
        debugMenu.talkTo(character);

        // Wait for the scene change to take effect
        yield return null;

        // Assert
        Assert.AreEqual("Snoopy", SceneManager.GetActiveScene().name); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator TalkToShaggyTest()
    {
        // Arrange
        string character = "Shaggy";

        // Act
        debugMenu.talkTo(character);

        // Wait for the scene change to take effect
        yield return null;

        // Assert
        Assert.AreEqual("Shaggy", SceneManager.GetActiveScene().name); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator TalkToDaphneTest()
    {
        // Arrange
        string character = "Daphne";

        // Act
        debugMenu.talkTo(character);

        // Wait for the scene change to take effect
        yield return null;

        // Assert
        Assert.AreEqual("Daphne", SceneManager.GetActiveScene().name); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator TalkToFredTest()
    {
        // Arrange
        string character = "Fred";

        // Act
        debugMenu.talkTo(character);

        // Wait for the scene change to take effect
        yield return null;

        // Assert
        Assert.AreEqual("Fred", SceneManager.GetActiveScene().name); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator TalkToSonicTest()
    {
        // Arrange
        string character = "Sonic";

        // Act
        debugMenu.talkTo(character);

        // Wait for the scene change to take effect
        yield return null;

        // Assert
        Assert.AreEqual("Sonic", SceneManager.GetActiveScene().name); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator TalkToShadowTest()
    {
        // Arrange
        string character = "Shadow";

        // Act
        debugMenu.talkTo(character);

        // Wait for the scene change to take effect
        yield return null;

        // Assert
        Assert.AreEqual("Shadow", SceneManager.GetActiveScene().name); // Check that the scene has changed
    }

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
