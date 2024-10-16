using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

/*  Joe's Structure for tests
 *  1. Arrange
 *  2. Act
 *  3. Assert
 *
 *  Notes:
 *  If your test fails from another persons test, then remember it for the oral exam.
 *  BC wants a full test plan and how it integrates with our entire program. Integration testing, unit testing, functional testing
 *  Oral exam will require us to all explain exactly why we are performing each test.
 *  Beta testing might be required (?); Get another person to play the game before oral exam with no instruction on how to play before.
 */

public class New
{
    private bool sceneLoaded;
    [OneTimeSetUp]
    public void OneTimeSetUp() {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Pong", LoadSceneMode.Single);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg) {
        sceneLoaded = true;
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewWithEnumeratorPasses()
    {
        yield return new WaitWhile(() => sceneLoaded == false); 

        // Set the game objects up for the test, in Joe's example it is setting the player speed
        // get all the game objects in the scene
        var paddle = GameObject.Find("Player Paddle").GetComponent<PlayerPaddle>();


        // Now go into the act stage and actually run the tests
        
        // for (int i = 0; i < 100; i++) {
            // do the testing stuff here
            // yield return null;
        // }

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
