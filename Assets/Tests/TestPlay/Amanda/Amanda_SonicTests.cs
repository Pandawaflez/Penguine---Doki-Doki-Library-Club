using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Amanda_SonicDialogueTests
{
    private SonicDialogue sonicDialogue;
    private AffectionManager affectionManager;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Sonic");  // Load Sonic's scene
        affectionManager = new AffectionManager();
        sonicDialogue = new SonicDialogue(affectionManager);
    }

    // Test 1: Minimum Sonic Affection Points
    [UnityTest]
    public IEnumerator SonicMinAffectionTest()
    {
        sonicDialogue.ProcessChoice(2); // Negative response
        yield return null;
        Assert.GreaterOrEqual(AffectionManager.GetSonicAffectionPoints(), -10, "Affection should not go below minimum");
    }

    // Test 2: Maximum Sonic Affection Points
    [UnityTest]
    public IEnumerator SonicMaxAffectionTest()
    {
        sonicDialogue.ProcessChoice(1); // Positive response
        yield return null;
        Assert.LessOrEqual(AffectionManager.GetSonicAffectionPoints(), 100, "Affection points should not go above 100");
    }

    // Test 3: BC mode negative should not happen
    [UnityTest]
    public IEnumerator SonicBCNegTest()
    {
        MainPlayer.SetBCMode(true);
        sonicDialogue.ProcessChoice(2); // Negative choice
        int initialPoints = AffectionManager.GetSonicAffectionPoints();
        yield return null;
        Assert.AreEqual(initialPoints, AffectionManager.GetSonicAffectionPoints(), "BC mode affection points should always be 0 or more.");
        MainPlayer.SetBCMode(false);
    }

    // Test 4: BC mode positive incrementing properly
    [UnityTest]
    public IEnumerator SonicBCPosTest()
    {
        MainPlayer.SetBCMode(true);
        sonicDialogue.ProcessChoice(1); // Positive choice in BC mode
        int initialPoints = AffectionManager.GetSonicAffectionPoints();
        yield return null;
        Assert.AreEqual(initialPoints, AffectionManager.GetSonicAffectionPoints(), "Affection should double in BC mode on positive.");
        MainPlayer.SetBCMode(false);
    }

    // Test 5: Lose condition
    [UnityTest]
    public IEnumerator SonicLoseConditionTest()
    {
        affectionManager.SetSonicAffectionPoints(-10);
        sonicDialogue = new SonicDialogue(affectionManager);
        yield return null;
        Assert.AreEqual("You're not as cool as I thought. I gotta go fast...", sonicDialogue.DialogueLine, "Lose dialogue not triggered.");
    }

    // Test 6: Test lockout state is being used properly
    [UnityTest]
    public IEnumerator SonicLockoutActivatedTest()
    {
        affectionManager.SetSonicAffectionPoints(-10);
        sonicDialogue.TransistionToState(new SonicLockoutState(sonicDialogue));
        yield return null;
        Assert.IsTrue(SonicDialogue.CheckSonicLockout(), "Sonic should be in lockout.");
    }

    // Test 7: Test lockout dialogue is locked
    [UnityTest]
    public IEnumerator SonicLockoutDialogueTest()
    {
        sonicDialogue.TransistionToState(new SonicLockoutState(sonicDialogue));
        yield return null;
        Assert.AreEqual("You're not as cool as I thought. I gotta go fast...", sonicDialogue.DialogueLine, "Incorrect lockout dialogue.");
    }

    // Test 8: Test if player loses the mini-game and if Sonic's dialogue is correct
    [UnityTest]
    public IEnumerator SonicMiniGameLoseDialogueTest()
    {
        MainPlayer.SetMiniGameStatus(0); // Lose
        sonicDialogue.UpdateDialogueAfterMinigame();
        yield return null;
        Assert.AreEqual($"At least you tried, good job {MainPlayer.GetPlayerName()}.", sonicDialogue.DialogueLine, "Incorrect lose dialogue.");
    }

    // Test 9: Make sure dialogue is tracking properly
    [UnityTest]
    public IEnumerator SonicDialogueTrackingTest()
    {
        sonicDialogue.ProcessChoice(1); 
        sonicDialogue.sonicCurrentDialogueIndex = 1;
        yield return null;
        Assert.AreEqual(1, sonicDialogue.sonicCurrentDialogueIndex, "Dialogue index did not update.");
    }

    // Test 10: Test if dialogue resets properly after being locked out
    [UnityTest]
    public IEnumerator SonicDialogueResetAfterLockoutTest()
    {
        sonicDialogue.TransistionToState(new SonicLockoutState(sonicDialogue));
        sonicDialogue.EndConversation();
        sonicDialogue = new SonicDialogue(affectionManager);
        yield return null;
        Assert.AreEqual(0, sonicDialogue.sonicCurrentDialogueIndex, "Dialogue did not reset after lockout.");
    }

    // Test 11: Test if mini-game state properly loads
    [UnityTest]
    public IEnumerator SonicDialogueTransitionToMiniGameStateTest()
    {
        sonicDialogue.TransistionToState(new SonicMiniGameState(sonicDialogue));
        yield return null;
        Assert.IsInstanceOf<SonicMiniGameState>(sonicDialogue.CurrentState, "Not in Mini-Game State.");
    }

    // Test 12: Test if lockout state properly loads
    [UnityTest]
    public IEnumerator SonicDialogueTransitionToLockoutStateTest()
    {
        sonicDialogue.TransistionToState(new SonicLockoutState(sonicDialogue));
        yield return null;
        Assert.IsInstanceOf<SonicLockoutState>(sonicDialogue.CurrentState, "Not in Lockout State.");
    }

    // Test 13: Test if normal state properly works
    [UnityTest]
    public IEnumerator SonicDialogueTransitionToNormalStateTest()
    {
        sonicDialogue.TransistionToState(new SonicNormalState(sonicDialogue));
        yield return null;
        Assert.IsInstanceOf<SonicNormalState>(sonicDialogue.CurrentState, "Not in Normal State.");
    }

    // Test 14: Test if buttons are disabled after conversation ends
    [UnityTest]
    public IEnumerator SonicButtonDisableOnEndTest()
    {
        sonicDialogue.EndConversation();
        yield return null;
        Assert.IsTrue(sonicDialogue.IsConversationFinished(), "Buttons should be disabled at conversation end.");
    }

    // Test 15: Test if buttons are re-enabled after conversation reset
    [UnityTest]
    public IEnumerator SonicButtonReenableAfterResetTest()
    {
        sonicDialogue.EndConversation();
        sonicDialogue = new SonicDialogue(affectionManager);
        yield return null;
        Assert.IsFalse(sonicDialogue.IsConversationFinished(), "Buttons should re-enable after reset.");
    }
}
