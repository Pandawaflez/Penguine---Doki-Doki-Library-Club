using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using ScoobyObserver;
using UnityEngine.UI;

public class FredTests
{
    private Scooby scoobyScript = new FredScript();
    
    //minimum daphne affection points
    [UnityTest]
    public IEnumerator MinFredLove()
    {
        FredScript.FredSCAP = 0;
        ((FredScript)scoobyScript).FredAffectionPointsMonitor(FredScript.FredSCAP, -10);
        yield return null;
        Assert.GreaterOrEqual(FredScript.FredSCAP, 0, "Fred's affection points should not go below 0");
    }

    //max shaggy affection points
    [UnityTest]
    public IEnumerator MaxFredLove()
    {
        FredScript.FredSCAP = 95;
        ((FredScript)scoobyScript).FredAffectionPointsMonitor(FredScript.FredSCAP, 10);
        yield return null;
        Assert.LessOrEqual(FredScript.FredSCAP, 100, "Fred's affection points should not go above 100");
    }

    //testing bcmode preventing negatives
    [UnityTest]
    public IEnumerator TestBCModePreventingNegativeAffection()
    {
        FredScript.BCModeOn = true;
        FredScript.FredSCAP = 50;
        ((FredScript)scoobyScript).FredAffectionPointsMonitor(FredScript.FredSCAP,-10);
        yield return null;
        Assert.AreEqual(50, FredScript.FredSCAP, "BC mode should prevent affection going down");
    }

    //testing bcmode positively incrementing
    [UnityTest]
    public IEnumerator TestBCModePositiveIncrementing()
    {
        FredScript.BCModeOn = true;
        FredScript.FredSCAP = 20;
        ((FredScript)scoobyScript).FredAffectionPointsMonitor(FredScript.FredSCAP, 10);
        yield return null;
        Assert.AreEqual(30, FredScript.FredSCAP, "BC Mode should correctly increment affection");
    }

    //testing losing the minigame condition
    [UnityTest]
    public IEnumerator TestLoseConditionforMinigame()
    {
        MainPlayer.SetMiniGameStatus(0);
        FredScript.BCModeOn = false;
        FredScript.UpdateAffectionAfterMinigame();
        yield return null;
        Assert.Less(FredScript.FredSCAP, 100, "losing minigame should reduce affection points");
        Assert.IsTrue(FredScript.isFredLockedOut(), "losing should trigger lockout");
    }

    //testing lockout usage
    [UnityTest]
    public IEnumerator TestLockoutUsage()
    {
        FredScript.FredSCAP = 10;
        FredScript.FredLockout = false;
        scoobyScript.EndConversation(true, FredScript.FredSCAP);
        yield return null;
        Assert.IsTrue(FredScript.isFredLockedOut(), "Fred should be locked out now");
    }

    

    //test dialogue tracking
    [UnityTest]
    public IEnumerator TestDialogueTracking()
    {
        ((FredScript)scoobyScript).SCdialogueNum = 0;
        ((FredScript)scoobyScript).HandlePlayerResponse(1);
        yield return null;
        Assert.AreEqual(1, ((FredScript)scoobyScript).SCdialogueNum, "dialogue number should track responses correctly");
    }

    
    //test that buttons are disabled during lockout
    [UnityTest]
    public IEnumerator TestButtonsDisabledDuringLockout()
    {
        FredScript.FredLockout = true;
        GameObject buttonObject = new GameObject();
        Button button = buttonObject.AddComponent<Button>();
        button.interactable = !FredScript.isFredLockedOut();
        yield return null;
        Assert.IsFalse(button.interactable, "Buttons should be disabled when Fred is locked out");
    }

    //testing observers
    [UnityTest]
    public IEnumerator TestObserverFunctionality()
    {
        var affectionPoints = 50;
        var lockoutStatus = true;
        var Shaginteraction = false;
        var Daphinteraction = false;
        var Fredinteraction = true;
        ((FredScript)scoobyScript).Update(affectionPoints, lockoutStatus, Shaginteraction, Daphinteraction, Fredinteraction);
        yield return null;
        Assert.AreEqual(50, FredScript.FredSCAP, "Observer should correctly update affection points");
        Assert.IsTrue(FredScript.isFredLockedOut(), "Observer should correctly update lockout status");
    }

    //testing when button is pressed multiple times
    [UnityTest]
    public IEnumerator TestSpamButtonPresses()
    {
        FredScript.FredSCAP = 50;
        ((FredScript)scoobyScript).hitFredResponse1();
        ((FredScript)scoobyScript).hitFredResponse1();
        ((FredScript)scoobyScript).hitFredResponse1();
        yield return null;
        Assert.AreEqual(70, FredScript.FredSCAP, "repeated button presses should affect affection points only once per valid response");
    }

    //testing affection points after the minigame ends
    [UnityTest]
    public IEnumerator UpdateAffectionAfterMinigame_CorrectlyAdjustsAffectionPoints_Win()
    {
        FredScript.FredSCAP = 50;
        FredScript.FredLockout = false;
        
        MainPlayer.SetMiniGameStatus(1);
        FredScript.UpdateAffectionAfterMinigame();
        yield return null;
        Assert.AreEqual(100, FredScript.FredSCAP, "Minigame win should increase affection points by 50");
    }

    //affection points after minigame ends and loses without BC mode deducts points
    [UnityTest]
    public IEnumerator UpdateAffectionAfterMinigame_CorrectlyAdjustsAffectionPoints_Lose()
    {
        FredScript.FredSCAP = 50;
        MainPlayer.SetMiniGameStatus(0);
        FredScript.BCModeOn = false;
        FredScript.UpdateAffectionAfterMinigame();
        yield return null;
        Assert.AreEqual(20, FredScript.FredSCAP, "Minigame loss should decrease affection points");
        Assert.IsTrue(FredScript.FredLockout, "Minigame loss without BC mode should lose points");
    }

    //affection points after minigame ends and loses with BC should gain points
    [UnityTest]
    public IEnumerator UpdateAffectionAfterMinigame_CorrectlyAdjustsAffectionPoints_Lose_BC()
    {
        FredScript.FredSCAP = 50;
        MainPlayer.SetMiniGameStatus(0);
        FredScript.BCModeOn = true;
        FredScript.UpdateAffectionAfterMinigame();
        yield return null;
        Assert.AreEqual(55, FredScript.FredSCAP, "minigame loss in BC mode increases SCAP by 5");
        Assert.IsFalse(FredScript.FredLockout, "minigame loss in BC mode should not lower SCAP");
    }
}

