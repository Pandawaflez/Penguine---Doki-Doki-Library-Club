using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using ScoobyObserver;
using UnityEngine.UI;

public class ShaggyTests
{
    private Scooby scoobyScript = new ShaggyScript();
    
    //minimum shaggy affection points
    [UnityTest]
    public IEnumerator MinShaggyLove()
    {
        ShaggyScript.ShagSCAP = 0;
        ShaggyScript.ShaggyAffectionPointsMonitor(ShaggyScript.ShagSCAP, -10);
        yield return null;
        Assert.GreaterOrEqual(ShaggyScript.ShagSCAP, 0, "Shaggy's affection points should not go below 0");
    }

    //max shaggy affection points
    [UnityTest]
    public IEnumerator MaxShaggyLove()
    {
        ShaggyScript.ShagSCAP = 95;
        ShaggyScript.ShaggyAffectionPointsMonitor(ShaggyScript.ShagSCAP, 10);
        yield return null;
        Assert.LessOrEqual(ShaggyScript.ShagSCAP, 100, "Shaggy's affection points should not go above 100");
    }

    //testing bcmode preventing negatives
    [UnityTest]
    public IEnumerator TestBCModePreventingNegativeAffection()
    {
        ShaggyScript.BCModeOn = true;
        ShaggyScript.ShagSCAP = 50;
        ShaggyScript.ShaggyAffectionPointsMonitor(ShaggyScript.ShagSCAP,-10);
        yield return null;
        Assert.AreEqual(50, ShaggyScript.ShagSCAP, "BC mode should prevent affection going down");
    }

    //testing bcmode positively incrementing
    [UnityTest]
    public IEnumerator TestBCModePositiveIncrementing()
    {
        ShaggyScript.BCModeOn = true;
        ShaggyScript.ShagSCAP = 20;
        ShaggyScript.ShaggyAffectionPointsMonitor(ShaggyScript.ShagSCAP, 10);
        yield return null;
        Assert.AreEqual(30, ShaggyScript.ShagSCAP, "BC Mode should correctly increment affection");
    }

    //testing losing the minigame condition
    [UnityTest]
    public IEnumerator TestLoseConditionforMinigame()
    {
        MainPlayer.SetMiniGameStatus(0);
        ShaggyScript.BCModeOn = false;
        ShaggyScript.UpdateAffectionAfterMinigame();
        yield return null;
        Assert.Less(ShaggyScript.ShagSCAP, 100, "losing minigame should reduce affection points");
        Assert.IsTrue(ShaggyScript.isShaggyLockedOut(), "losing should trigger lockout");
    }

    //testing lockout usage
    [UnityTest]
    public IEnumerator TestLockoutUsage()
    {
        ShaggyScript.ShagSCAP = 10;
        ShaggyScript.ShagLockout = false;
        scoobyScript.EndConversation(true, ShaggyScript.ShagSCAP);
        yield return null;
        Assert.IsTrue(ShaggyScript.isShaggyLockedOut(), "Shaggy should be locked out now");
    }

    

    //test dialogue tracking
    [UnityTest]
    public IEnumerator TestDialogueTracking()
    {
        ((ShaggyScript)scoobyScript).SCdialogueNum = 0;
        ((ShaggyScript)scoobyScript).HandlePlayerResponse(1);
        yield return null;
        Assert.AreEqual(1, ((ShaggyScript)scoobyScript).SCdialogueNum, "dialogue number should track responses correctly");
    }

    
    //test that buttons are disabled during lockout
    [UnityTest]
    public IEnumerator TestButtonsDisabledDuringLockout()
    {
        ShaggyScript.ShagLockout = true;
        GameObject buttonObject = new GameObject();
        Button button = buttonObject.AddComponent<Button>();
        button.interactable = !ShaggyScript.isShaggyLockedOut();
        yield return null;
        Assert.IsFalse(button.interactable, "Buttons should be disabled when Shaggy is locked out");
    }

    //testing observers
    [UnityTest]
    public IEnumerator TestObserverFunctionality()
    {
        var affectionPoints = 50;
        var lockoutStatus = true;
        var Shaginteraction = true;
        var Daphinteraction = false;
        var Fredinteraction = false;
        ((ShaggyScript)scoobyScript).Update(affectionPoints, lockoutStatus, Shaginteraction, Daphinteraction, Fredinteraction);
        yield return null;
        Assert.AreEqual(50, ShaggyScript.ShagSCAP, "Observer should correctly update affection points");
        Assert.IsTrue(ShaggyScript.isShaggyLockedOut(), "Observer should correctly update lockout status");
    }

    //testing when button is pressed multiple times
    [UnityTest]
    public IEnumerator TestSpamButtonPresses()
    {
        ShaggyScript.ShagSCAP = 50;
        ((ShaggyScript)scoobyScript).hitShagResponse1();
        ((ShaggyScript)scoobyScript).hitShagResponse1();
        ((ShaggyScript)scoobyScript).hitShagResponse1();
        yield return null;
        Assert.AreEqual(70, ShaggyScript.ShagSCAP, "repeated button presses should affect affection points only once per valid response");
    }

   

    //testing affection points after the minigame ends
    [UnityTest]
    public IEnumerator UpdateAffectionAfterMinigame_CorrectlyAdjustsAffectionPoints_Win()
    {
        ShaggyScript.ShagSCAP = 50;
        ShaggyScript.ShagLockout = false;
        
        MainPlayer.SetMiniGameStatus(1);
        ShaggyScript.UpdateAffectionAfterMinigame();
        yield return null;
        Assert.AreEqual(100, ShaggyScript.ShagSCAP, "Minigame win should increase affection points by 50");
    }

    //affection points after minigame ends and loses without BC mode deducts points
    [UnityTest]
    public IEnumerator UpdateAffectionAfterMinigame_CorrectlyAdjustsAffectionPoints_Lose()
    {
        ShaggyScript.ShagSCAP = 50;
        MainPlayer.SetMiniGameStatus(0);
        ShaggyScript.BCModeOn = false;
        ShaggyScript.UpdateAffectionAfterMinigame();
        yield return null;
        Assert.AreEqual(20, ShaggyScript.ShagSCAP, "Minigame loss should decrease affection points");
        Assert.IsTrue(ShaggyScript.ShagLockout, "Minigame loss without BC mode should lose points");
    }

    //affection points after minigame ends and loses with BC should gain points
    [UnityTest]
    public IEnumerator UpdateAffectionAfterMinigame_CorrectlyAdjustsAffectionPoints_Lose_BC()
    {
        ShaggyScript.ShagSCAP = 50;
        MainPlayer.SetMiniGameStatus(0);
        ShaggyScript.BCModeOn = true;
        ShaggyScript.UpdateAffectionAfterMinigame();
        yield return null;
        Assert.AreEqual(55, ShaggyScript.ShagSCAP, "minigame loss in BC mode increases SCAP by 5");
        Assert.IsFalse(ShaggyScript.ShagLockout, "minigame loss in BC mode should not lower SCAP");
    }

}
