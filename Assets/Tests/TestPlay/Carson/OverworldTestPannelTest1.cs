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

}
