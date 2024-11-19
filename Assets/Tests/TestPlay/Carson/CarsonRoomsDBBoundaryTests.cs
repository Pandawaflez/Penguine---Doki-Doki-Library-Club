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
        // Instantiate and set DontDestroyOnLoad to keep objects across scene changes
        overworldObject = GameObject.Instantiate(Resources.Load<GameObject>("Carson/Overworld"));
        Assert.IsNotNull(overworldObject, "Overworld prefab not found in Resources.");
        overworld = overworldObject.GetComponent<OverworldManagement>();
        Assert.IsNotNull(overworld, "Overworld prefab does not contain OverworldManagement component.");
        Object.DontDestroyOnLoad(overworldObject);

        debugMenuObject = GameObject.Instantiate(Resources.Load<GameObject>("Carson/OverworldDebugMenu"));
        Assert.IsNotNull(debugMenuObject, "DebugMenu prefab not found in Resources.");
        debugMenu = debugMenuObject.GetComponent<overworldDebugMenu>();
        Assert.IsNotNull(debugMenu, "Debug Menu prefab does not contain overworldDebugMenu component.");
        Object.DontDestroyOnLoad(debugMenuObject);

        // Load the initial scene
        SceneManager.LoadScene("Overworld");
    }

    //tests that the player returns to the room that they were in after they finish talking to a character:
    [UnityTest]
    public IEnumerator TalkToCharlieBoundaryTest([Values(0, 1, 2, 3, 4, 5, 6)] int startingRoom)
    {
        // Arrange
        string character = "Charlie";
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        debugMenu.talkTo(character);  // Trigger interaction with character
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Level1");  // Wait for scene transition

        // Return to Overworld scene
        SceneManager.LoadScene("Overworld");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Overworld");

        // Assert: Ensure that the character returned to the correct room
        int currentRoom = RoomsDB.getCurrentRoom();
        Assert.AreEqual(startingRoom, currentRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
    }

    [UnityTest]
    public IEnumerator TalkToLucyBoundaryTest([Values(0, 1, 2, 3, 4, 5, 6)] int startingRoom)
    {
        // Arrange
        string character = "Lucy";
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        debugMenu.talkTo(character);  // Trigger interaction with character
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == character);  // Wait for scene transition

        // Return to Overworld scene
        SceneManager.LoadScene("Overworld");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Overworld");

        // Assert: Ensure that the character returned to the correct room
        int currentRoom = RoomsDB.getCurrentRoom();
        Assert.AreEqual(startingRoom, currentRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
    }

    [UnityTest]
    public IEnumerator TalkToSchroederBoundaryTest([Values(0, 1, 2, 3, 4, 5, 6)] int startingRoom)
    {
        // Arrange
        string character = "Schroeder";
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        debugMenu.talkTo(character);  // Trigger interaction with character
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == character);  // Wait for scene transition

        // Return to Overworld scene
        SceneManager.LoadScene("Overworld");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Overworld");

        // Assert: Ensure that the character returned to the correct room
        int currentRoom = RoomsDB.getCurrentRoom();
        Assert.AreEqual(startingRoom, currentRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
    }

    [UnityTest]
    public IEnumerator TalkToSnoopyBoundaryTest([Values(0, 1, 2, 3, 4, 5, 6)] int startingRoom)
    {
        // Arrange
        string character = "Snoopy";
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        debugMenu.talkTo(character);  // Trigger interaction with character
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == character);  // Wait for scene transition

        // Return to Overworld scene
        SceneManager.LoadScene("Overworld");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Overworld");

        // Assert: Ensure that the character returned to the correct room
        int currentRoom = RoomsDB.getCurrentRoom();
        Assert.AreEqual(startingRoom, currentRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
    }

    [UnityTest]
    public IEnumerator TalkToShaggyBoundaryTest([Values(0, 1, 2, 3, 4, 5, 6)] int startingRoom)
    {
        // Arrange
        string character = "Shaggy";
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        debugMenu.talkTo(character);  // Trigger interaction with character
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == character);  // Wait for scene transition

        // Return to Overworld scene
        SceneManager.LoadScene("Overworld");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Overworld");

        // Assert: Ensure that the character returned to the correct room
        int currentRoom = RoomsDB.getCurrentRoom();
        Assert.AreEqual(startingRoom, currentRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
    }

    [UnityTest]
    public IEnumerator TalkToFredBoundaryTest([Values(0, 1, 2, 3, 4, 5, 6)] int startingRoom)
    {
        // Arrange
        string character = "Fred";
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        debugMenu.talkTo(character);  // Trigger interaction with character
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == character);  // Wait for scene transition

        // Return to Overworld scene
        SceneManager.LoadScene("Overworld");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Overworld");

        // Assert: Ensure that the character returned to the correct room
        int currentRoom = RoomsDB.getCurrentRoom();
        Assert.AreEqual(startingRoom, currentRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
    }

    [UnityTest]
    public IEnumerator TalkToDaphneBoundaryTest([Values(0, 1, 2, 3, 4, 5, 6)] int startingRoom)
    {
        // Arrange
        string character = "Daphne";
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        debugMenu.talkTo(character);  // Trigger interaction with character
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == character);  // Wait for scene transition

        // Return to Overworld scene
        SceneManager.LoadScene("Overworld");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Overworld");

        // Assert: Ensure that the character returned to the correct room
        int currentRoom = RoomsDB.getCurrentRoom();
        Assert.AreEqual(startingRoom, currentRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
    }

    [UnityTest]
    public IEnumerator TalkToSonicBoundaryTest([Values(0, 1, 2, 3, 4, 5, 6)] int startingRoom)
    {
        // Arrange
        string character = "Sonic";
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        debugMenu.talkTo(character);  // Trigger interaction with character
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == character);  // Wait for scene transition

        // Return to Overworld scene
        SceneManager.LoadScene("Overworld");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Overworld");

        // Assert: Ensure that the character returned to the correct room
        int currentRoom = RoomsDB.getCurrentRoom();
        Assert.AreEqual(startingRoom, currentRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
    }

    [UnityTest]
    public IEnumerator TalkToShadowBoundaryTest([Values(0, 1, 2, 3, 4, 5, 6)] int startingRoom)
    {
        // Arrange
        string character = "Shadow";
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        debugMenu.talkTo(character);  // Trigger interaction with character
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == character);  // Wait for scene transition

        // Return to Overworld scene
        SceneManager.LoadScene("Overworld");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Overworld");

        // Assert: Ensure that the character returned to the correct room
        int currentRoom = RoomsDB.getCurrentRoom();
        Assert.AreEqual(startingRoom, currentRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
    }

    [TearDown]
    public void TearDown()
    {
        // Destroy objects after all tests are completed
        if (overworldObject != null) Object.Destroy(overworldObject);
        if (debugMenuObject != null) Object.Destroy(debugMenuObject);
    }

    [UnityTest]
    public IEnumerator testWraparoundRight()
    {
        // Arrange
        //string character = "Charlie";
        int startingRoom = 6;
        int targetRoom = 0;
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        overworld.goRight();
        int currentRoom = RoomsDB.getCurrentRoom();
        
        // Assert: Ensure that the character returned to the correct room
        Assert.AreEqual(currentRoom, targetRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator testWraparoundLeft()
    {
        // Arrange
        //string character = "Charlie";
        int startingRoom = 0;
        int targetRoom = 6;
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        overworld.goLeft();
        int currentRoom = RoomsDB.getCurrentRoom();
        
        // Assert: Ensure that the character returned to the correct room
        Assert.AreEqual(currentRoom, targetRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator goLeftBoundaryTest([Values( 1, 2, 3, 4, 5, 6 )] int startingRoom)
    {
        // Arrange
        int targetRoom = startingRoom-1;
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        overworld.goLeft();
        int currentRoom = RoomsDB.getCurrentRoom();
        
        // Assert: Ensure that the character returned to the correct room
        Assert.AreEqual(currentRoom, targetRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator goRightBoundaryTest([Values( 0, 1, 2, 3, 4, 5 )] int startingRoom)
    {
        // Arrange
        int targetRoom = startingRoom+1;
        RoomsDB.setCurrentRoom(startingRoom);  // Set the room in RoomsDB
        overworld.loadRoom(startingRoom);  // Load the room in OverworldManagement

        // Act
        overworld.goRight();
        int currentRoom = RoomsDB.getCurrentRoom();
        
        // Assert: Ensure that the character returned to the correct room
        Assert.AreEqual(currentRoom, targetRoom, $"Expected character to return to room {startingRoom}, but was in room {currentRoom}.");
        yield return null;
    }


}


    /*[TearDown]
    public void TearDown()
    {
        // Clean up instantiated objects after each test
        Object.Destroy(overworldObject);
        Object.Destroy(debugMenuObject);
    }
}


/*using System.Collections;
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
        overworldObject = Resources.Load<GameObject>("Carson/Overworld");
        Assert.IsNotNull(overworldObject, "Overworld prefab not assigned in the Resources folder.");
        overworld = overworldObject.GetComponent<OverworldManagement>();
        Assert.IsNotNull(overworld, "Overworld prefab does not have proper component");
        debugMenuObject = Resources.Load<GameObject>("Carson/OverworldDebugMenu");
        Assert.IsNotNull(debugMenuObject, "Debugmenu prefab not assigned in the Resources folder.");
        debugMenu = debugMenuObject.GetComponent<overworldDebugMenu>();
        Assert.IsNotNull(debugMenu, "Debug Menu prefab does not have proper component");
        SceneManager.LoadScene("Overworld"); // Load a dummy scene to avoid errors.
    }

    [UnityTest]
    public IEnumerator TalkToCharlieTest()
    {
        // Arrange
        string character = "Charlie";
        int startingRoom = 0;
        RoomsDB.setCurrentRoom(startingRoom);
        overworld.loadRoom(startingRoom);

        // Act
        debugMenu.talkTo(character);
        // Wait for the scene change to take effect
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Level1");
        
        //SceneManager.LoadScene("Overworld");

        //yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Overworld");

        int currentRoom = RoomsDB.getCurrentRoom();

        // Assert
        Assert.AreEqual( startingRoom, currentRoom ); // Check we returned to the correct room
    }*/
    
    /*[SetUp]
    public void Setup()
    {
        overworldObject = Resources.Load<GameObject>("Carson/Prefabs/Overworld");
        Assert.IsNotNull(overworldObject, "Overworld prefab not assigned in the Resources folder.");
        overworld = overworldObject.GetComponent<OverworldManagement>();
        Assert.IsNotNull(overworld, "Overworld prefab does not have proper component");
        debugMenuObject = Resources.Load<GameObject>("Carson/Prefabs/OverworldDebugMenu");
        Assert.IsNotNull(debugMenuObject, "Debugmenu prefab not assigned in the Resources folder.");
        debugMenu = debugMenuObject.GetComponent<overworldDebugMenu>();
        Assert.IsNotNull(debugMenu, "Debug Menu prefab does not have proper component");
        SceneManager.LoadScene("Overworld"); // Load a dummy scene to avoid errors.
    }


    //boundary test:
    [UnityTest]
    public IEnumerator characterReturnsToRoom0()
    {
        Debug.Log( "Starting Test" );
        // Arrange
        string character = "Charlie";
        int startingRoom = 0;
        RoomsDB.setCurrentRoom(startingRoom);

        // Act
        debugMenu.talkTo(character);

        // Wait for the scene changes to take effect
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Level1");

        SceneManager.LoadScene("Overworld");

        // Wait for the scene changes to take effect
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Overworld");

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

}*/
