using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class OverworldDebugMenuTests : MonoBehaviour
{
    private overworldDebugMenu debugMenu;

    [SetUp]
    public void Setup()
    {
        debugMenu = new GameObject().AddComponent<overworldDebugMenu>();
        SceneManager.LoadScene("Overworld"); // Load a dummy scene to avoid errors.
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

}
