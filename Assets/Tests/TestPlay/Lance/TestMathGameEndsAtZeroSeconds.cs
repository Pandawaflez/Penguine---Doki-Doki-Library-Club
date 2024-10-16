using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using TMPro; 

public class LanceMathMiniGameTests
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

    [UnityTest]
    public IEnumerator TestGameEndsAtZeroSeconds()
    {
        // Wait until the Math GameObject is available
        yield return new WaitUntil(() => GameObject.Find("Math") != null);

        var mathMiniGame = GameObject.Find("Math").GetComponent<Math>();

        mathMiniGame.SetTimeRemaining(0.1f);
    
        yield return new WaitForSeconds(0.2f);

        // Check if the game over screen is active
        Assert.IsTrue(mathMiniGame.GetGameOverScreenShowing(), "Game did not end at zero seconds.");
    }
}
