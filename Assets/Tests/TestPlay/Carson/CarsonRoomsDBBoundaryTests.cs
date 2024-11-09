using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class CarsonRoomsDBBoundaryTests
{
    public GameObject overworldObject;
    public GameObject debugMenuObject;
    public overworldDebugMenu debugMenu;
    public OverworldManagement overworld;

    [SetUp]
    public void Setup()
    {
        overworldObject = Resources.Load<GameObject>("Assets/Carson/Prefabs/Overworld.prefab");
        Assert.IsNotNull(overworldObject, "Overworld prefab not assigned in the Resources folder.");
        overworld = overworldObject.GetComponent<OverworldManagement>();
        Assert.IsNotNull(overworldObject, "Overworld prefab does not have proper component");
        debugMenuObject = Resources.Load<GameObject>("Assets/Carson/Prefabs/OverworldDebugMenu.prefab");
        Assert.IsNotNull(overworldObject, "Debugmenu prefab not assigned in the Resources folder.");
        debugMenu = debugMenuObject.GetComponent<overworldDebugMenu>();
        Assert.IsNotNull(overworldObject, "Debug Menu prefab does not have proper component");
    }

    //boundary test:
    [UnityTest]
    public IEnumerator characterReturnsToRoom0()
    {
        // Arrange
        string character = "Charlie";
        int startingRoom = 0;
        RoomsDB.setCurrentRoom(startingRoom);

        // Act
        debugMenu.talkTo(character);
        SceneManager.LoadScene("Overworld");

        // Wait for the scene changes to take effect
        yield return null;

        int currentRoom = RoomsDB.getCurrentRoom();

        Debug.Log( currentRoom );
        Debug.Log( startingRoom );

        // Assert
        Assert.AreEqual( startingRoom, currentRoom , "Expected character to return to room " + startingRoom + ", got " + currentRoom + " instead." ); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator characterReturnsToRoom1()
    {
        // Arrange
        string character = "Charlie";
        int startingRoom = 1;
        RoomsDB.setCurrentRoom(startingRoom);

        // Act
        debugMenu.talkTo(character);
        SceneManager.LoadScene("Overworld");

        // Wait for the scene changes to take effect
        yield return null;

        int currentRoom = RoomsDB.getCurrentRoom();

        // Assert
        Assert.AreEqual( startingRoom, currentRoom , "Expected character to return to room " + startingRoom + ", got " + currentRoom + " instead." ); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator characterReturnsToRoom2()
    {
        // Arrange
        string character = "Charlie";
        int startingRoom = 2;
        RoomsDB.setCurrentRoom(startingRoom);

        // Act
        debugMenu.talkTo(character);
        SceneManager.LoadScene("Overworld");

        // Wait for the scene changes to take effect
        yield return null;

        int currentRoom = RoomsDB.getCurrentRoom();

        // Assert
        Assert.AreEqual( startingRoom, currentRoom , "Expected character to return to room " + startingRoom + ", got " + currentRoom + " instead." ); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator characterReturnsToRoom3()
    {
        // Arrange
        string character = "Charlie";
        int startingRoom = 3;
        RoomsDB.setCurrentRoom(startingRoom);

        // Act
        debugMenu.talkTo(character);
        SceneManager.LoadScene("Overworld");

        // Wait for the scene changes to take effect
        yield return null;

        int currentRoom = RoomsDB.getCurrentRoom();

        // Assert
        Assert.AreEqual( startingRoom, currentRoom , "Expected character to return to room " + startingRoom + ", got " + currentRoom + " instead." ); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator characterReturnsToRoom4()
    {
        // Arrange
        string character = "Charlie";
        int startingRoom = 4;
        RoomsDB.setCurrentRoom(startingRoom);

        // Act
        debugMenu.talkTo(character);
        SceneManager.LoadScene("Overworld");

        // Wait for the scene changes to take effect
        yield return null;

        int currentRoom = RoomsDB.getCurrentRoom();

        // Assert
        Assert.AreEqual( startingRoom, currentRoom , "Expected character to return to room " + startingRoom + ", got " + currentRoom + " instead." ); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator characterReturnsToRoom5()
    {
        // Arrange
        string character = "Charlie";
        int startingRoom = 5;
        RoomsDB.setCurrentRoom(startingRoom);

        // Act
        debugMenu.talkTo(character);
        SceneManager.LoadScene("Overworld");

        // Wait for the scene changes to take effect
        yield return null;

        int currentRoom = RoomsDB.getCurrentRoom();

        // Assert
        Assert.AreEqual( startingRoom, currentRoom , "Expected character to return to room " + startingRoom + ", got " + currentRoom + " instead." ); // Check that the scene has changed
    }

    [UnityTest]
    public IEnumerator characterReturnsToRoom6()
    {
        // Arrange
        string character = "Charlie";
        int startingRoom = 6;
        RoomsDB.setCurrentRoom(startingRoom);

        // Act
        debugMenu.talkTo(character);
        SceneManager.LoadScene("Overworld");

        // Wait for the scene changes to take effect
        yield return null;

        int currentRoom = RoomsDB.getCurrentRoom();

        // Assert
        Assert.AreEqual( startingRoom, currentRoom , "Expected character to return to room " + startingRoom + ", got " + currentRoom + " instead." ); // Check that the scene has changed
    }

    //boundary test:
    [UnityTest]
    public IEnumerator characterReturnsToRoom7()
    {
        // Arrange
        string character = "Charlie";
        int startingRoom = 6;
        RoomsDB.setCurrentRoom(startingRoom);

        // Act
        debugMenu.talkTo(character);
        SceneManager.LoadScene("Overworld");

        // Wait for the scene changes to take effect
        yield return null;

        int currentRoom = RoomsDB.getCurrentRoom();

        // Assert
        Assert.AreEqual( startingRoom, currentRoom , "Expected character to return to room " + startingRoom + ", got " + currentRoom + " instead." ); // Check that the scene has changed
    }

}
