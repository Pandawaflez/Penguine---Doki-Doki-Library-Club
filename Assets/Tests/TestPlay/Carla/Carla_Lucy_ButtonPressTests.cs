using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor.Compilation;

public class Carla_Lucy_ButtonPressTest
{
    private bool sceneLoaded;
    [OneTimeSetUp]
    public void OneTimeSetUp() 
    //public void SetUp()
    {
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
    //this tests that unity can handle quick button presses, and will still go to the next correct dialogue
    public IEnumerator ButtonPressTestWithEnumeratorPasses()
    {
        yield return new WaitUntil(() => GameObject.Find("Lucy") != null);

        var lucy = GameObject.Find("Lucy").GetComponent<Lucy>();
        lucy.setDialogueNum(0);
        lucy.hitResponse1();
        lucy.hitResponse2();
        yield return new WaitForSeconds(0.1f);
        //dialogue should be 3 (it registered hitting 1 and then hitting 2 FROM the dialogue that 1 yielded)
        Assert.IsTrue(lucy.getDialogueNum() == 3, "Dialogue num is not what response 2 should yield");
        Assert.IsTrue( lucy.getResponseNum() == 0, "Response was not reset to 0");
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    //this tests that the affection points are correctly updated after hitting a response button
    public IEnumerator ButtonPressTestAffection()
    {
        yield return new WaitUntil(() => GameObject.Find("Lucy") != null);

        Debug.Log("Point 1");
        var lucy = GameObject.Find("Lucy").GetComponent<Lucy>();
        lucy.setDialogueNum(0);
        int prePts = lucy.getAffectionPoints();
        Debug.Log("Point 2");
        lucy.hitResponse1();
        //lucy.hitResponse2();
        Debug.Log("Point 3");
        yield return new WaitForSeconds(0.1f);
        Debug.Log(lucy.getDialogueNum().ToString());
        Debug.Log(lucy.getAffectionPoints().ToString());
        Assert.IsTrue(lucy.getDialogueNum() == 1, "Dialogue num is not right");
        Assert.IsTrue( (lucy.getAffectionPoints()-prePts) == -5, "affection points not right");
        Debug.Log("Point 4 - test passed");
        yield return null;
    }

    [UnityTest]
    public IEnumerator LastDialogueLoop()
    {
        yield return new WaitUntil(() => GameObject.Find("Lucy") != null);
        var lucy = GameObject.Find("Lucy").GetComponent<Lucy>();
        //GameObject ins = GameObject.Instantiate(lucyy);
        //Lucy lucy = ins.GetComponentInChildren<Lucy>();
        //Transform r1 = lucy.GetComponentInChildren<"Response1">();
        //Transform r1 = lucy.transform.Find("Response1");
        var r1 = GameObject.Find("Response1");
        var r2 = GameObject.Find("Response2");
        lucy.setDialogueNum(15);
        lucy.onDialogue(15);
        lucy.hitResponse1();    //'hit' a response even though there should not be buttons to hit
        Assert.IsTrue(lucy.getDialogueNum() == 15, "Dialogue changed");
        Debug.Log("point 1");
        Assert.IsTrue(r1.gameObject.activeSelf == false && r1.gameObject.activeSelf == false, "buttons are present and shouldn't be");
        Debug.Log("success");
        //yield return null;
    }

    [UnityTest]
    public IEnumerator AfterWonGame(){
        yield return new WaitUntil(() => GameObject.Find("Lucy") != null);
        var lucy = GameObject.Find("Lucy").GetComponent<Lucy>();
        int prePts = lucy.getAffectionPoints();
        MainPlayer.SetMiniGameStatus(1);
        Debug.Log(MainPlayer.GetMiniGameStatus().ToString());
        lucy.setDialogueNum(-1);
        lucy.onDialogue(-1);
        //lucy.hitResponse1();    //'hit' a response even though there should not be buttons to hit
        Assert.IsTrue(lucy.getDialogueNum() == 16, "Dialogue not on winning dialogue");
        Assert.IsTrue( (lucy.getAffectionPoints() - prePts) == -10, "affection not updated right");
    }

    [UnityTest]
    public IEnumerator AfterLoseGame(){
        yield return new WaitUntil(() => GameObject.Find("Lucy") != null);
        var lucy = GameObject.Find("Lucy").GetComponent<Lucy>();
        int prePts = lucy.getAffectionPoints();
        MainPlayer.SetMiniGameStatus(0);
        Debug.Log(MainPlayer.GetMiniGameStatus().ToString());
        lucy.setDialogueNum(-1);
        lucy.onDialogue(-1);
        Assert.IsTrue(lucy.getDialogueNum() == 17, "Dialogue not on losing dialogue");
        Assert.IsTrue( (lucy.getAffectionPoints() - prePts) == 25, "affection not updated right");
    }

    [UnityTest]
    public IEnumerator ReturnToScene()
    {
        yield return new WaitUntil(() => GameObject.Find("Lucy") != null);
        var lucy = GameObject.Find("Lucy").GetComponent<Lucy>();
        lucy.setDialogueNum(0);
        var r1 = GameObject.Find("Response1");
        var r2 = GameObject.Find("Response2");
        lucy.hitResponse1();    //hit a response
        int prePts = lucy.getAffectionPoints();
        int preDnum = lucy.getDialogueNum();
        //Assert.IsTrue(preDnum == 1 && prePts == -5, "Dialogue on 1 and afpts -5");
        SceneManager.LoadScene("Scenes/Overworld");
        SceneManager.LoadScene("Scenes/Lucy");
        PeanutsDB.LucyAffectionPts = prePts;
        PeanutsDB.LucyDialogueNum = preDnum;
        yield return new WaitForSeconds(0.1f);
        lucy = GameObject.Find("Lucy").GetComponent<Lucy>();
        r1 = GameObject.Find("Response1");
        r2 = GameObject.Find("Response2");
        Assert.IsTrue(lucy.getDialogueNum() == 1, "Dialogue not 1");
        Assert.IsTrue(lucy.getAffectionPoints() == prePts, "affection pts not right");
        Assert.IsTrue(r1.gameObject.activeSelf == true && r1.gameObject.activeSelf == true, "buttons are not present");
        Debug.Log("success");
    }

    [UnityTest]
    public IEnumerator BCModeNegativePts()
    {
        yield return new WaitUntil(() => GameObject.Find("Lucy") != null);
        MainPlayer.SetBCMode(true);
        var lucy = GameObject.Find("Lucy").GetComponent<Lucy>();
        lucy.setDialogueNum(0);
        int prePts = lucy.getAffectionPoints();
        lucy.hitResponse1();
        Assert.IsTrue((lucy.getAffectionPoints() - prePts) == 0, "affection went down");
        MainPlayer.SetBCMode(false);

    }

    [UnityTest]
    public IEnumerator BCModePositivePts()
    {
        yield return new WaitUntil(() => GameObject.Find("Lucy") != null);
        MainPlayer.SetBCMode(true);
        var lucy = GameObject.Find("Lucy").GetComponent<Lucy>();
        lucy.setDialogueNum(0);
        int prePts = lucy.getAffectionPoints();
        lucy.hitResponse2();
        Debug.Log(lucy.getAffectionPoints().ToString());
        Assert.IsTrue((lucy.getAffectionPoints() - prePts) == 40, "affection didn't double");
        MainPlayer.SetBCMode(false);

    }
}
