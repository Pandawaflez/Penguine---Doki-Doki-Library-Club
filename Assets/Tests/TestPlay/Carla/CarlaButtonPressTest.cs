using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarlaButtonPressTest
{

    private bool sceneLoaded;
    [OneTimeSetUp]
    public void OneTimeSetUp() {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Lucy", LoadSceneMode.Single);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg) {
        sceneLoaded = true;
    }

/*
    // A Test behaves as an ordinary method
    [Test]
    public void ButtonPressTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }
    */

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    //this tests that unity can handle quick button presses
    public IEnumerator ButtonPressTestWithEnumeratorPasses()
    {
        yield return new WaitUntil(() => GameObject.Find("Lucy") != null);

        Debug.Log("Point 1");
        var lucy = GameObject.Find("Lucy").GetComponent<Lucy>();
        Debug.Log(lucy.getDialogueNum().ToString());
        Debug.Log("Point 2");
        lucy.hitResponse1();
        lucy.hitResponse2();
        Debug.Log("Point 3");
        yield return new WaitForSeconds(0.1f);
        Debug.Log(lucy.getResponseNum().ToString());
        Debug.Log(lucy.getDialogueNum().ToString());
        //dialogue should be 3 (it registered hitting 1 and then hitting 2 FROM the dialogue that 1 yielded)
        Assert.IsTrue(lucy.getDialogueNum() == 3, "Dialogue num is not what response 2 should yield");
        Assert.IsTrue( lucy.getResponseNum() == 0, "Response is not 0");
        Debug.Log("Point 4 - test passed");
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    //this tests that unity can handle quick button presses
    public IEnumerator ButtonPressTestAffection()
    {
        yield return new WaitUntil(() => GameObject.Find("Lucy") != null);

        Debug.Log("Point 1");
        var lucy = GameObject.Find("Lucy").GetComponent<Lucy>();
        //Debug.Log(lucy.getDialogueNum().ToString());
        Debug.Log("Point 2");
        lucy.hitResponse1();
        //lucy.hitResponse2();
        Debug.Log("Point 3");
        yield return new WaitForSeconds(0.1f);
        //Debug.Log(lucy.getResponseNum().ToString());
        //Debug.Log(lucy.getDialogueNum().ToString());
        //dialogue should be 3 (it registered hitting 1 and then hitting 2 FROM the dialogue that 1 yielded)
        Assert.IsTrue(lucy.getDialogueNum() == 1, "Dialogue num is not right");
        Assert.IsTrue( lucy.getAffectionPoints() == -1, "affection points not right");
        Debug.Log("Point 4 - test passed");
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
