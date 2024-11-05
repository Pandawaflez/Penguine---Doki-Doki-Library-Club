using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor.Compilation;

public class Carla_SnoopyButtonPressTest
{
    private bool sceneLoaded;
    [OneTimeSetUp]
    public void OneTimeSetUp() 
    //public void SetUp()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Snoopy", LoadSceneMode.Single);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg) {
        sceneLoaded = true;
    }

    [UnityTest]
    //this tests that unity can handle quick button presses, and will still go to the next correct dialogue
    public IEnumerator ButtonPressTestWithEnumeratorPasses()
    {
        yield return new WaitUntil(() => GameObject.Find("Snoopy") != null);

        var snoopy = GameObject.Find("Snoopy").GetComponent<Snoopy>();
        snoopy.setDialogueNum(0);
        snoopy.hitResponse1();
        snoopy.hitResponse2();
        yield return new WaitForSeconds(0.1f);
        //dialogue should be 3 (it registered hitting 1 and then hitting 2 FROM the dialogue that 1 yielded)
        Assert.IsTrue(snoopy.getDialogueNum() == 4, "Dialogue num is not what response 2 should yield");
        Assert.IsTrue( snoopy.getResponseNum() == 0, "Response was not reset to 0");
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
    }

    [UnityTest]
    //this tests that the affection points are correctly updated after hitting a response button
    public IEnumerator ButtonPressTestAffection()
    {
        yield return new WaitUntil(() => GameObject.Find("Snoopy") != null);

        Debug.Log("Point 1");
        var snoopy = GameObject.Find("Snoopy").GetComponent<Snoopy>();
        snoopy.setDialogueNum(0);
        int prePts = snoopy.getAffectionPoints();
        Debug.Log("Point 2");
        snoopy.hitResponse1();
        //snoopy.hitResponse2();
        Debug.Log("Point 3");
        yield return new WaitForSeconds(0.1f);
        Debug.Log(snoopy.getDialogueNum().ToString());
        Debug.Log(snoopy.getAffectionPoints().ToString());
        Assert.IsTrue(snoopy.getDialogueNum() == 1, "Dialogue num is not right");
        Assert.IsTrue( (snoopy.getAffectionPoints()-prePts) == 20, "affection points not right");
        Debug.Log("Point 4 - test passed");
    }

    [UnityTest]
    public IEnumerator LastDialogueLoop()
    {
        yield return new WaitUntil(() => GameObject.Find("Snoopy") != null);
        var snoopy = GameObject.Find("Snoopy").GetComponent<Snoopy>();
        int last = 12;
        var r1 = GameObject.Find("Response1");
        var r2 = GameObject.Find("Response2");
        snoopy.setDialogueNum(last);
        snoopy.onDialogue(last);
        snoopy.hitResponse1();    //'hit' a response even though there should not be buttons to hit
        Assert.IsTrue(snoopy.getDialogueNum() == last, "Dialogue changed");
        Debug.Log("point 1");
        Assert.IsTrue(r1.gameObject.activeSelf == false && r1.gameObject.activeSelf == false, "buttons are present and shouldn't be");
        Debug.Log("success");
        //yield return null;
    }

    [UnityTest]
    public IEnumerator AfterWonGame(){
        yield return new WaitUntil(() => GameObject.Find("Snoopy") != null);
        var snoopy = GameObject.Find("Snoopy").GetComponent<Snoopy>();
        int prePts = snoopy.getAffectionPoints();
        MainPlayer.SetMiniGameStatus(1);
        Debug.Log(MainPlayer.GetMiniGameStatus().ToString());
        snoopy.setDialogueNum(-1);
        snoopy.onDialogue(-1);
        //snoopy.hitResponse1();    //'hit' a response even though there should not be buttons to hit
        Assert.IsTrue(snoopy.getDialogueNum() == 13, "Dialogue not on winning dialogue");
        Assert.IsTrue( (snoopy.getAffectionPoints() - prePts) == 15, "affection not updated right");
    }

    [UnityTest]
    public IEnumerator AfterLoseGame(){
        yield return new WaitUntil(() => GameObject.Find("Snoopy") != null);
        var snoopy = GameObject.Find("Snoopy").GetComponent<Snoopy>();
        int prePts = snoopy.getAffectionPoints();
        MainPlayer.SetMiniGameStatus(0);
        Debug.Log(MainPlayer.GetMiniGameStatus().ToString());
        snoopy.setDialogueNum(-1);
        snoopy.onDialogue(-1);
        Assert.IsTrue(snoopy.getDialogueNum() == 14, "Dialogue not on losing dialogue");
        Assert.IsTrue( (snoopy.getAffectionPoints() - prePts) == 30, "affection not updated right");
        yield return null;
    }

    [UnityTest]
    public IEnumerator ReturnToScene()
    {
        yield return new WaitUntil(() => GameObject.Find("Snoopy") != null);
        var snoopy = GameObject.Find("Snoopy").GetComponent<Snoopy>();
        snoopy.setDialogueNum(0);
        var r1 = GameObject.Find("Response1");
        var r2 = GameObject.Find("Response2");
        snoopy.hitResponse1();    //hit a response
        int prePts = snoopy.getAffectionPoints();
        int preDnum = snoopy.getDialogueNum();
        //Assert.IsTrue(preDnum == 1 && prePts == -5, "Dialogue on 1 and afpts -5");
        SceneManager.LoadScene("Scenes/Overworld");
        SceneManager.LoadScene("Scenes/Snoopy");
        PeanutsDB.SnoopyAffectionPts = prePts;
        PeanutsDB.SnoopyDialogueNum = preDnum;
        yield return new WaitForSeconds(0.1f);
        snoopy = GameObject.Find("Snoopy").GetComponent<Snoopy>();
        r1 = GameObject.Find("Response1");
        r2 = GameObject.Find("Response2");
        Assert.IsTrue(snoopy.getDialogueNum() == 1, "Dialogue not 1");
        Assert.IsTrue(snoopy.getAffectionPoints() == prePts, "affection pts not right");
        Assert.IsTrue(r1.gameObject.activeSelf == true && r1.gameObject.activeSelf == true, "buttons are not present");
        Debug.Log("success");
    }

    [UnityTest]
    public IEnumerator BCModeNegativePts()
    {
        yield return new WaitUntil(() => GameObject.Find("Snoopy") != null);
        MainPlayer.SetBCMode(true);
        var snoopy = GameObject.Find("Snoopy").GetComponent<Snoopy>();
        snoopy.setDialogueNum(0);
        int prePts = snoopy.getAffectionPoints();
        snoopy.hitResponse2();
        Assert.IsTrue((snoopy.getAffectionPoints() - prePts) == 0, "affection went down");
        MainPlayer.SetBCMode(false);

    }

    [UnityTest]
    public IEnumerator BCModePositivePts()
    {
        yield return new WaitUntil(() => GameObject.Find("Snoopy") != null);
        MainPlayer.SetBCMode(true);
        var snoopy = GameObject.Find("Snoopy").GetComponent<Snoopy>();
        snoopy.setDialogueNum(0);
        int prePts = snoopy.getAffectionPoints();
        snoopy.hitResponse1();
        Debug.Log(snoopy.getAffectionPoints().ToString());
        Assert.IsTrue((snoopy.getAffectionPoints() - prePts) == 40, "affection didn't double");
        MainPlayer.SetBCMode(false);

    }
}
