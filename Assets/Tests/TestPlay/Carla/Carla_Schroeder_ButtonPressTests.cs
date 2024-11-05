using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Carla_Schroeder_ButtonPressTests
{
    private bool sceneLoaded;
    [OneTimeSetUp]
    public void OneTimeSetUp() 
    //public void SetUp()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Schroeder", LoadSceneMode.Single);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg) {
        sceneLoaded = true;
    }

    [UnityTest]
    //this tests that unity can handle quick button presses, and will still go to the next correct dialogue
    public IEnumerator ButtonPressTestWithEnumeratorPasses()
    {
        yield return new WaitUntil(() => GameObject.Find("Schroeder") != null);

        var schroeder = GameObject.Find("Schroeder").GetComponent<Schroeder>();
        schroeder.setDialogueNum(0);
        schroeder.hitResponse1();
        schroeder.hitResponse2();
        yield return new WaitForSeconds(0.1f);
        //dialogue should be 3 (it registered hitting 1 and then hitting 2 FROM the dialogue that 1 yielded)
        Assert.IsTrue(schroeder.getDialogueNum() == 4, "Dialogue num is not what response 2 should yield");
        Assert.IsTrue( schroeder.getResponseNum() == 0, "Response was not reset to 0");
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
    }

    [UnityTest]
    //this tests that the affection points are correctly updated after hitting a response button
    public IEnumerator ButtonPressTestAffection()
    {
        yield return new WaitUntil(() => GameObject.Find("Schroeder") != null);

        Debug.Log("Point 1");
        var schroeder = GameObject.Find("Schroeder").GetComponent<Schroeder>();
        schroeder.setDialogueNum(0);
        int prePts = schroeder.getAffectionPoints();
        Debug.Log("Point 2");
        schroeder.hitResponse1();
        //schroeder.hitResponse2();
        Debug.Log("Point 3");
        yield return new WaitForSeconds(0.1f);
        Debug.Log(schroeder.getDialogueNum().ToString());
        Debug.Log(schroeder.getAffectionPoints().ToString());
        Assert.IsTrue(schroeder.getDialogueNum() == 1, "Dialogue num is not right");
        Assert.IsTrue( (schroeder.getAffectionPoints()-prePts) == 20, "affection points not right");
        Debug.Log("Point 4 - test passed");
    }

    [UnityTest]
    public IEnumerator LastDialogueLoop()
    {
        yield return new WaitUntil(() => GameObject.Find("Schroeder") != null);
        var schroeder = GameObject.Find("Schroeder").GetComponent<Schroeder>();
        int last = 12;
        var r1 = GameObject.Find("Response1");
        var r2 = GameObject.Find("Response2");
        schroeder.setDialogueNum(last);
        schroeder.onDialogue(last);
        schroeder.hitResponse1();    //'hit' a response even though there should not be buttons to hit
        Assert.IsTrue(schroeder.getDialogueNum() == last, "Dialogue changed");
        Debug.Log("point 1");
        Assert.IsTrue(r1.gameObject.activeSelf == false && r1.gameObject.activeSelf == false, "buttons are present and shouldn't be");
        Debug.Log("success");
        //yield return null;
    }

    [UnityTest]
    public IEnumerator AfterWonGame(){
        yield return new WaitUntil(() => GameObject.Find("Schroeder") != null);
        var schroeder = GameObject.Find("Schroeder").GetComponent<Schroeder>();
        int prePts = schroeder.getAffectionPoints();
        MainPlayer.SetMiniGameStatus(1);
        Debug.Log(MainPlayer.GetMiniGameStatus().ToString());
        schroeder.setDialogueNum(-1);
        schroeder.onDialogue(-1);
        //schroeder.hitResponse1();    //'hit' a response even though there should not be buttons to hit
        Assert.IsTrue(schroeder.getDialogueNum() == 13, "Dialogue not on winning dialogue");
        Assert.IsTrue( (schroeder.getAffectionPoints() - prePts) == 25, "affection not updated right");
    }

    [UnityTest]
    public IEnumerator AfterLoseGame(){
        yield return new WaitUntil(() => GameObject.Find("Schroeder") != null);
        var schroeder = GameObject.Find("Schroeder").GetComponent<Schroeder>();
        int prePts = schroeder.getAffectionPoints();
        MainPlayer.SetMiniGameStatus(0);
        Debug.Log(MainPlayer.GetMiniGameStatus().ToString());
        schroeder.setDialogueNum(-1);
        schroeder.onDialogue(-1);
        Assert.IsTrue(schroeder.getDialogueNum() == 14, "Dialogue not on losing dialogue");
        Assert.IsTrue( (schroeder.getAffectionPoints() - prePts) == -5, "affection not updated right");
        yield return null;
    }

    [UnityTest]
    public IEnumerator ReturnToScene()
    {
        yield return new WaitUntil(() => GameObject.Find("Schroeder") != null);
        var schroeder = GameObject.Find("Schroeder").GetComponent<Schroeder>();
        schroeder.setDialogueNum(0);
        var r1 = GameObject.Find("Response1");
        var r2 = GameObject.Find("Response2");
        schroeder.hitResponse1();    //hit a response
        int prePts = schroeder.getAffectionPoints();
        int preDnum = schroeder.getDialogueNum();
        //Assert.IsTrue(preDnum == 1 && prePts == -5, "Dialogue on 1 and afpts -5");
        SceneManager.LoadScene("Scenes/Overworld");
        SceneManager.LoadScene("Scenes/Schroeder");
        PeanutsDB.SchroederAffectionPts = prePts;
        PeanutsDB.SchroederDialogueNum = preDnum;
        yield return new WaitForSeconds(0.1f);
        schroeder = GameObject.Find("Schroeder").GetComponent<Schroeder>();
        r1 = GameObject.Find("Response1");
        r2 = GameObject.Find("Response2");
        Assert.IsTrue(schroeder.getDialogueNum() == 1, "Dialogue not 1");
        Assert.IsTrue(schroeder.getAffectionPoints() == prePts, "affection pts not right");
        Assert.IsTrue(r1.gameObject.activeSelf == true && r1.gameObject.activeSelf == true, "buttons are not present");
        Debug.Log("success");
    }

    [UnityTest]
    public IEnumerator BCModeNegativePts()
    {
        yield return new WaitUntil(() => GameObject.Find("Schroeder") != null);
        MainPlayer.SetBCMode(true);
        var schroeder = GameObject.Find("Schroeder").GetComponent<Schroeder>();
        schroeder.setDialogueNum(0);
        int prePts = schroeder.getAffectionPoints();
        schroeder.hitResponse2();
        Assert.IsTrue((schroeder.getAffectionPoints() - prePts) == 0, "affection went down");
        MainPlayer.SetBCMode(false);

    }

    [UnityTest]
    public IEnumerator BCModePositivePts()
    {
        yield return new WaitUntil(() => GameObject.Find("Schroeder") != null);
        MainPlayer.SetBCMode(true);
        var schroeder = GameObject.Find("Schroeder").GetComponent<Schroeder>();
        schroeder.setDialogueNum(0);
        int prePts = schroeder.getAffectionPoints();
        schroeder.hitResponse1();
        Debug.Log(schroeder.getAffectionPoints().ToString());
        Assert.IsTrue((schroeder.getAffectionPoints() - prePts) == 40, "affection didn't double");
        MainPlayer.SetBCMode(false);

    }
}
