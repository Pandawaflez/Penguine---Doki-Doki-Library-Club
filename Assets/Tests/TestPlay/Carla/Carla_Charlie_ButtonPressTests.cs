using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Carla_Charlie_ButtonPressTests
{
     private bool sceneLoaded;
    [OneTimeSetUp]
    public void OneTimeSetUp() 
    //public void SetUp()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Level1", LoadSceneMode.Single);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg) {
        sceneLoaded = true;
    }

    [UnityTest]
    //this tests that unity can handle quick button presses, and will still go to the next correct dialogue
    public IEnumerator ButtonPressTestWithEnumeratorPasses()
    {
        yield return new WaitUntil(() => GameObject.Find("Charlie") != null);

        var charlie = GameObject.Find("Charlie").GetComponent<CharlieBrown>();
        charlie.setDialogueNum(0);
        charlie.hitResponse1();
        charlie.hitResponse2();
        yield return new WaitForSeconds(0.1f);
        //dialogue should be 3 (it registered hitting 1 and then hitting 2 FROM the dialogue that 1 yielded)
        Assert.IsTrue(charlie.getDialogueNum() == 2, "Dialogue num is not what response 2 should yield");
        Assert.IsTrue( charlie.getResponseNum() == 0, "Response was not reset to 0");
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
    }

    [UnityTest]
    //this tests that the affection points are correctly updated after hitting a response button
    public IEnumerator ButtonPressTestAffection()
    {
        yield return new WaitUntil(() => GameObject.Find("Charlie") != null);

        Debug.Log("Point 1");
        var charlie = GameObject.Find("Charlie").GetComponent<CharlieBrown>();
        charlie.setDialogueNum(0);
        int prePts = charlie.getAffectionPoints();
        Debug.Log("Point 2");
        charlie.hitResponse1();
        //charlie.hitResponse2();
        Debug.Log("Point 3");
        yield return new WaitForSeconds(0.1f);
        Debug.Log(charlie.getDialogueNum().ToString());
        Debug.Log(charlie.getAffectionPoints().ToString());
        Assert.IsTrue(charlie.getDialogueNum() == 1, "Dialogue num is not right");
        Assert.IsTrue( (charlie.getAffectionPoints()-prePts) == -5, "affection points not right");
        Debug.Log("Point 4 - test passed");
    }

    [UnityTest]
    public IEnumerator LastDialogueLoop()
    {
        yield return new WaitUntil(() => GameObject.Find("Charlie") != null);
        var charlie = GameObject.Find("Charlie").GetComponent<CharlieBrown>();
        int last = 7;
        var r1 = GameObject.Find("Response1");
        var r2 = GameObject.Find("Response2");
        charlie.setDialogueNum(last);
        charlie.onDialogue(last);
        charlie.hitResponse1();    //'hit' a response even though there should not be buttons to hit
        Assert.IsTrue(charlie.getDialogueNum() == last, "Dialogue changed");
        Debug.Log("point 1");
        Assert.IsTrue(r1.gameObject.activeSelf == false && r1.gameObject.activeSelf == false, "buttons are present and shouldn't be");
        Debug.Log("success");
        //yield return null;
    }

    [UnityTest]
    public IEnumerator AfterGame(){
        yield return new WaitUntil(() => GameObject.Find("Charlie") != null);
        MainPlayer.SetMiniGameStatus(0);
        var charlie = GameObject.Find("Charlie").GetComponent<CharlieBrown>();
        int prePts = charlie.getAffectionPoints();
        charlie.setDialogueNum(-1);
        charlie.onDialogue(-1);
        yield return new WaitForSeconds(0.1f);
        Debug.Log(charlie.getDialogueNum().ToString());
        //charlie.hitResponse1();    //'hit' a response even though there should not be buttons to hit
        Assert.IsTrue(charlie.getDialogueNum() == 8, "Dialogue not on postgame dialogue");
        Assert.IsTrue( (charlie.getAffectionPoints() - prePts) == 30, "affection not updated right");
    }


    [UnityTest]
    public IEnumerator ReturnToScene()
    {
        yield return new WaitUntil(() => GameObject.Find("Charlie") != null);
        var charlie = GameObject.Find("Charlie").GetComponent<CharlieBrown>();
        charlie.setDialogueNum(0);
        var r1 = GameObject.Find("Response1");
        var r2 = GameObject.Find("Response2");
        charlie.hitResponse1();    //hit a response
        int prePts = charlie.getAffectionPoints();
        int preDnum = charlie.getDialogueNum();
        //Assert.IsTrue(preDnum == 1 && prePts == -5, "Dialogue on 1 and afpts -5");
        SceneManager.LoadScene("Scenes/Overworld");
        SceneManager.LoadScene("Scenes/Level1");
        PeanutsDB.CharlieAffectionPts = prePts;
        PeanutsDB.CharlieDialogueNum = preDnum;
        yield return new WaitForSeconds(0.1f);
        charlie = GameObject.Find("Charlie").GetComponent<CharlieBrown>();
        r1 = GameObject.Find("Response1");
        r2 = GameObject.Find("Response2");
        Assert.IsTrue(charlie.getDialogueNum() == 1, "Dialogue not 1");
        Assert.IsTrue(charlie.getAffectionPoints() == prePts, "affection pts not right");
        Assert.IsTrue(r1.gameObject.activeSelf == true && r1.gameObject.activeSelf == true, "buttons are not present");
        Debug.Log("success");
    }

    [UnityTest]
    public IEnumerator BCModeNegativePts()
    {
        yield return new WaitUntil(() => GameObject.Find("Charlie") != null);
        MainPlayer.SetBCMode(true);
        var charlie = GameObject.Find("Charlie").GetComponent<CharlieBrown>();
        charlie.setDialogueNum(0);
        int prePts = charlie.getAffectionPoints();
        charlie.hitResponse1();
        Assert.IsTrue((charlie.getAffectionPoints() - prePts) == 0, "affection went down");
        MainPlayer.SetBCMode(false);

    }

    [UnityTest]
    public IEnumerator BCModePositivePts()
    {
        yield return new WaitUntil(() => GameObject.Find("Charlie") != null);
        MainPlayer.SetBCMode(true);
        var charlie = GameObject.Find("Charlie").GetComponent<CharlieBrown>();
        charlie.setDialogueNum(0);
        int prePts = charlie.getAffectionPoints();
        charlie.hitResponse2();
        Debug.Log(charlie.getAffectionPoints().ToString());
        Assert.IsTrue((charlie.getAffectionPoints() - prePts) == 40, "affection didn't double");
        MainPlayer.SetBCMode(false);

    }
}

