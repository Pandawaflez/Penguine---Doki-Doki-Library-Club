using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Patrick_BCModeWorking
{
    private Button playButton;
    private Button BCButton;
    // private StartButton playButtonScript;
    // private StartButton BCButtonScript;

     private bool sceneLoaded;
    [OneTimeSetUp]
    public void OneTimeSetUp() 
    //public void SetUp()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Menu", LoadSceneMode.Single);



        //Get the script components attached to the buttons
        // playButtonScript = playButton.GetComponent<StartButton>();
        // BCButtonScript = BCButton.GetComponent<StartButton>();
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg) 
    {
        sceneLoaded = true;
    }

    //should start in normal and not bcmode
    [UnityTest]
    public IEnumerator A_NoBCMode()
    {

        playButton = GameObject.Find("Canvas/Start").GetComponent<Button>();

        playButton.onClick.Invoke();

        Assert.IsFalse(MainPlayer.IsBCMode(), "BC Mode should be false");

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    //BCMode should work
    [UnityTest]
    public IEnumerator B_BCMode()
    {
        BCButton = GameObject.Find("Canvas/BC mode").GetComponent<Button>();

        BCButton.onClick.Invoke();

        Assert.IsTrue(MainPlayer.IsBCMode(), "BC Mode should be false");

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}