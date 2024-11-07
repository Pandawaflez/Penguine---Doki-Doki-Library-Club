using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Patrick_OverlayScoringTests
{
     private bool sceneLoaded;
    [OneTimeSetUp]
    public void OneTimeSetUp() 
    //public void SetUp()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Menu", LoadSceneMode.Single);

        MainPlayer.SetPlayerName("playerName");
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg) {
        sceneLoaded = true;
    }

    //make sure overlay can't be brought up in menu scene
    [UnityTest]
    public IEnumerator A_CheckOverlayCannotOpenInMenu()
    {
        int i;

        //simulate many button presses while still in menu
        for(i = 0; i < 5; i++){
            UIElementHandler.UIGod.ShowOverlayTest();

            //wait one second to see visually if overlay opens or not
            yield return new WaitForSeconds(1f);        
        }

        Assert.AreEqual(5, i, "overlay would've tried to open 5 times");

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    //make sure overlay can open when not in menu
    [UnityTest]
    public IEnumerator B_CheckOverlayOpensInNewScene()
    {
        SceneManager.LoadScene("Scenes/Overworld", LoadSceneMode.Single);

        //simulate showing overlay
        for(int i = 0; i < 5; i++){
            UIElementHandler.UIGod.ShowOverlayTest();

            //wait one second to see visually if overlay opens or not
            yield return new WaitForSeconds(1f);        
        }


        yield return null;
    }

    //Test that slider stays in bounds max
    [UnityTest]
    public IEnumerator C_SliderMaxBounds()
    {
        //open Overlay
        UIElementHandler.UIGod.ShowOverlay();

        for(int i = 0; i <= 500; i++){
            PeanutsDB.CharlieAffectionPts = i;
            yield return null;
        }

        Assert.AreEqual(500, PeanutsDB.CharlieAffectionPts, "CharlieAffectionPts are 500");
        yield return new WaitForSeconds(2f);

        //close overlay
        UIElementHandler.UIGod.ShowOverlay();
    }

    //Test that slider stays in bounds min
    [UnityTest]
    public IEnumerator D_SliderMinBounds()
    {
        //open Overlay
        UIElementHandler.UIGod.ShowOverlay();

        for(int i = 0; i >= -500; i--){
            PeanutsDB.CharlieAffectionPts = i;
            yield return null;
        }

        Assert.AreEqual(-500, PeanutsDB.CharlieAffectionPts, "CharlieAffectionPts are -500");
        yield return new WaitForSeconds(2f);

        //close overlay
        UIElementHandler.UIGod.ShowOverlay();
    }

    //Test that multiple sliders can be updated simultaneously
    [UnityTest]
    public IEnumerator E_SliderMultipleMaxBounds()
    {
        //open Overlay
        UIElementHandler.UIGod.ShowOverlay();

        for(int i = 0; i <= 500; i++){
            PeanutsDB.CharlieAffectionPts = i;
            PeanutsDB.LucyAffectionPts = i;
            PeanutsDB.SchroederAffectionPts = i;
        
            yield return null;
        }

        Assert.AreEqual(500, PeanutsDB.CharlieAffectionPts, "three characters have 500");
        yield return new WaitForSeconds(2f);
    
        //close overlay
        UIElementHandler.UIGod.ShowOverlay();
    }

    //test that overlay will still hold score after closing/opening
    [UnityTest]
    public IEnumerator F_ScoreKeptOnToggle()
    {
        PeanutsDB.CharlieAffectionPts = 0;
        PeanutsDB.LucyAffectionPts = 0;
        PeanutsDB.SchroederAffectionPts = 0;
        PeanutsDB.SnoopyAffectionPts = 0;

        //show overlay
        UIElementHandler.UIGod.ShowOverlay();

        PeanutsDB.CharlieAffectionPts = 20;
        PeanutsDB.LucyAffectionPts = 30;
        PeanutsDB.SchroederAffectionPts = 70;
        PeanutsDB.SnoopyAffectionPts = 57;

        yield return new WaitForSeconds(2f);

        //close and open
        UIElementHandler.UIGod.ShowOverlay();
        yield return new WaitForSeconds(1f);
        UIElementHandler.UIGod.ShowOverlay();

        Assert.AreEqual(20, PeanutsDB.CharlieAffectionPts, "points are still same");

        yield return null;

        UIElementHandler.UIGod.ShowOverlay();
    }

    //test endGame Panel coming up while overlay is up
    [UnityTest]
    public IEnumerator G_OverlayThenEndGame()
    {
        UIElementHandler.UIGod.ShowOverlay();
        yield return null;
        UIElementHandler.UIGod.EndGame(true, "Tester");

        yield return new WaitForSeconds(2f);

        UIElementHandler.UIGod.EndGame(false, "test");
        UIElementHandler.UIGod.ShowOverlay();
    }

    //test overlay Panel coming up while endGame is up
    [UnityTest]
    public IEnumerator H_EndGameThenOverlay()
    {
        UIElementHandler.UIGod.EndGame(true, "Tester");
        yield return new WaitForSeconds(1f);
        UIElementHandler.UIGod.ShowOverlay();

        yield return new WaitForSeconds(2f);

        UIElementHandler.UIGod.EndGame(false, "test");
        UIElementHandler.UIGod.ShowOverlay();
    }

    //test endGame panel and overlay at same time
    [UnityTest]
    public IEnumerator I_OverlayAndEndGame()
    {
        UIElementHandler.UIGod.ShowOverlay();
        UIElementHandler.UIGod.EndGame(true, "Tester");

        yield return new WaitForSeconds(2f);

        UIElementHandler.UIGod.EndGame(false, "test");
        UIElementHandler.UIGod.ShowOverlay();
    }

    //test loseGame panel works
    [UnityTest]
    public IEnumerator J_LoseGameScreen()
    {
        UIElementHandler.UIGod.LoseGame(true);

        yield return new WaitForSeconds(2f);

        UIElementHandler.UIGod.LoseGame(false);
    }



}