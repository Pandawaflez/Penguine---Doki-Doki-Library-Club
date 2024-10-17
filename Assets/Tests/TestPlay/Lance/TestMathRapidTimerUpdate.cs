using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using TMPro; 

public class Lance_TestMathRapidTimerUpdate
{
    private bool sceneLoaded;
    [OneTimeSetUp]
    public void OneTimeSetUp() {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Math", LoadSceneMode.Single);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg) {
        sceneLoaded = true;
    }

    // Test rapidly changing the timer updates
    [UnityTest]
    public IEnumerator TestRapidTimerUpdates()
    {
        // Wait until the Math GameObject is available
        yield return new WaitUntil(() => GameObject.Find("Math") != null);

        var mathMiniGame = GameObject.Find("Math").GetComponent<Math>();

        // Start the game with a regular timer
        mathMiniGame.SetTimeRemaining(15.0f); 

        // Perform rapid timer updates
        for (int i = 0; i < 100; i++)
        {
            // Randomly set the timer to a new value between 2 and 15 seconds
            float newTime = Random.Range(2f, 15f);
            mathMiniGame.SetTimeRemaining(newTime);
            yield return null; 
        }

        yield return new WaitForSeconds(0.1f); 

        // After the rapid updates, check if the game over screen is not prematurely activated
        Assert.IsFalse(mathMiniGame.GetGameOverScreenShowing(), "Game should not have ended unexpectedly.");
    }
}
