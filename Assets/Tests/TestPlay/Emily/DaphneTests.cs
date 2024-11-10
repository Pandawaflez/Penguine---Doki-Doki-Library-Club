using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using ScoobyObserver;
using UnityEngine.UI;

public class DaphneTests
{
    private Scooby scoobyScript = new DaphneScript();
    
    //minimum daphne affection points
    [UnityTest]
    public IEnumerator MinDaphneLove()
    {
        DaphneScript.DaphSCAP = 0;
        ((DaphneScript)scoobyScript).DaphneAffectionPointsMonitor(DaphneScript.DaphSCAP, -10);
        yield return null;
        Assert.GreaterOrEqual(DaphneScript.DaphSCAP, 0, "Daphne's affection points should not go below 0");
    }

    //max shaggy affection points
    [UnityTest]
    public IEnumerator MaxDaphneLove()
    {
        DaphneScript.DaphSCAP = 95;
        ((DaphneScript)scoobyScript).DaphneAffectionPointsMonitor(DaphneScript.DaphSCAP, 10);
        yield return null;
        Assert.LessOrEqual(DaphneScript.DaphSCAP, 100, "Daphne's affection points should not go above 100");
    }

    //testing bcmode preventing negatives
    [UnityTest]
    public IEnumerator TestBCModePreventingNegativeAffection()
    {
        DaphneScript.BCModeOn = true;
        DaphneScript.DaphSCAP = 50;
        ((DaphneScript)scoobyScript).DaphneAffectionPointsMonitor(DaphneScript.DaphSCAP,-10);
        yield return null;
        Assert.AreEqual(50, DaphneScript.DaphSCAP, "BC mode should prevent affection going down");
    }

    //testing bcmode positively incrementing
    [UnityTest]
    public IEnumerator TestBCModePositiveIncrementing()
    {
        DaphneScript.BCModeOn = true;
        DaphneScript.DaphSCAP = 20;
        ((DaphneScript)scoobyScript).DaphneAffectionPointsMonitor(DaphneScript.DaphSCAP, 10);
        yield return null;
        Assert.AreEqual(30, DaphneScript.DaphSCAP, "BC Mode should correctly increment affection");
    }

    //testing losing the minigame condition
    [UnityTest]
    public IEnumerator TestLoseConditionforMinigame()
    {
        MainPlayer.SetMiniGameStatus(0);
        DaphneScript.BCModeOn = false;
        DaphneScript.UpdateAffectionAfterMinigame();
        yield return null;
        Assert.Less(DaphneScript.DaphSCAP, 100, "losing minigame should reduce affection points");
        Assert.IsTrue(DaphneScript.isDaphneLockedOut(), "losing should trigger lockout");
    }

    //testing lockout usage
    [UnityTest]
    public IEnumerator TestLockoutUsage()
    {
        DaphneScript.DaphSCAP = 10;
        DaphneScript.DaphLockout = false;
        scoobyScript.EndConversation(true, DaphneScript.DaphSCAP);
        yield return null;
        Assert.IsTrue(DaphneScript.isDaphneLockedOut(), "Daphne should be locked out now");
    }

    

    //test dialogue tracking
    [UnityTest]
    public IEnumerator TestDialogueTracking()
    {
        ((DaphneScript)scoobyScript).SCdialogueNum = 0;
        ((DaphneScript)scoobyScript).HandlePlayerResponse(1);
        yield return null;
        Assert.AreEqual(1, ((DaphneScript)scoobyScript).SCdialogueNum, "dialogue number should track responses correctly");
    }

    
    //test that buttons are disabled during lockout
    [UnityTest]
    public IEnumerator TestButtonsDisabledDuringLockout()
    {
        DaphneScript.DaphLockout = true;
        GameObject buttonObject = new GameObject();
        Button button = buttonObject.AddComponent<Button>();
        button.interactable = !DaphneScript.isDaphneLockedOut();
        yield return null;
        Assert.IsFalse(button.interactable, "Buttons should be disabled when Daphne is locked out");
    }

    //testing observers
    [UnityTest]
    public IEnumerator TestObserverFunctionality()
    {
        var affectionPoints = 50;
        var lockoutStatus = true;
        var Shaginteraction = false;
        var Daphinteraction = true;
        var Fredinteraction = false;
        ((DaphneScript)scoobyScript).Update(affectionPoints, lockoutStatus, Shaginteraction, Daphinteraction, Fredinteraction);
        yield return null;
        Assert.AreEqual(50, DaphneScript.DaphSCAP, "Observer should correctly update affection points");
        Assert.IsTrue(DaphneScript.isDaphneLockedOut(), "Observer should correctly update lockout status");
    }

    //testing when button is pressed multiple times
    [UnityTest]
    public IEnumerator TestSpamButtonPresses()
    {
        DaphneScript.DaphSCAP = 50;
        ((DaphneScript)scoobyScript).hitDaphResponse1();
        ((DaphneScript)scoobyScript).hitDaphResponse1();
        ((DaphneScript)scoobyScript).hitDaphResponse1();
        yield return null;
        Assert.AreEqual(70, DaphneScript.DaphSCAP, "repeated button presses should affect affection points only once per valid response");
    }
}

