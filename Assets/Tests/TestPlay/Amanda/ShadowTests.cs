using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Amanda_ShadowDialogueTests
{
    private ShadowDialogue shadowDialogue;
    private AffectionManager affectionManager;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Shadow");
        affectionManager = new AffectionManager();
        shadowDialogue = new ShadowDialogue(affectionManager);
    }

    //Test 1: Minimum Shadow Affection Points
    [UnityTest]
    public IEnumerator ShadowMinAffectionTest()
    {
        shadowDialogue.ProcessChoice(2); //negative response
        yield return null;
        Assert.GreaterOrEqual(AffectionManager.GetShadowAffectionPoints(), -10, "Affection should not go below minimum");
    }

    //Test 2: Max shadow affection pts
    [UnityTest]
    public IEnumerator ShadowMaxAffectionTest()
    {
        shadowDialogue.ProcessChoice(1); //positive
        yield return null;
        Assert.LessOrEqual(AffectionManager.GetShadowAffectionPoints(), 100, "Affection points should not go above 100");
    }

    //Test 3: BC mode negative should not happen
    [UnityTest]
    public IEnumerator ShadowBCNegTest()
    {
        MainPlayer.SetBCMode(true);
        shadowDialogue.ProcessChoice(2); //negative choice
        int initialPoints = AffectionManager.GetShadowAffectionPoints();
        yield return null;
        Assert.AreEqual(initialPoints, AffectionManager.GetShadowAffectionPoints(), "BC mode affection points should be always 0 or more.");
        MainPlayer.SetBCMode(false);
    }

    //test 4: BC mode positive incrementing properly
    [UnityTest]
    public IEnumerator ShadowBCPosTest()
    {
        MainPlayer.SetBCMode(true);
        shadowDialogue.ProcessChoice(1); // Positive choice in BC mode
        int initialPoints = AffectionManager.GetShadowAffectionPoints();
        yield return null;
        Assert.AreEqual(initialPoints, AffectionManager.GetShadowAffectionPoints(), "Affection should double in BC mode on positive.");
        MainPlayer.SetBCMode(false);
    }

    //Test 6: Lose condition
    [UnityTest]
    public IEnumerator ShadowLoseConditionTest()
    {
        affectionManager.SetShadowAffectionPoints(-10);
        shadowDialogue = new ShadowDialogue(affectionManager);
        yield return null;
        Assert.AreEqual("I don't want to see you again, get outta my face.", shadowDialogue.DialogueLine, "Lose dialogue not triggered.");
    }

    //Test 7: Test lockout state is being used properly
    [UnityTest]
    public IEnumerator ShadowLockoutActivatedTest()
    {
        affectionManager.SetShadowAffectionPoints(-10);
        shadowDialogue.TransistionToState(new ShadowLockoutState(shadowDialogue));
        yield return null;
        Assert.IsTrue(ShadowDialogue.CheckShadowLockout(), "Shadow should be in lockout.");
    }

    //Test 8: test lockout dialogue is locked
    [UnityTest]
    public IEnumerator ShadowLockoutDialogueTest()
    {
        shadowDialogue.TransistionToState(new ShadowLockoutState(shadowDialogue));
        yield return null;
        Assert.AreEqual("I don't want to see you again, get outta my face.", shadowDialogue.DialogueLine, "Incorrect lockout dialogue.");
    }

    //Test 9:  Test if player wins the minigame if shadow dialogue is correct
    [UnityTest]
    public IEnumerator ShadowMiniGameWinDialogueTest()
    {
        MainPlayer.SetMiniGameStatus(1);
        shadowDialogue.UpdateDialogueAfterMinigame();
        yield return null;
        //added the extra space because I have an extra space for the player name 
        Assert.AreEqual("Okay way to show off. I guess nice job.", shadowDialogue.DialogueLine, "Incorrect win dialogue.");
    }


    //Test 11: make sure dialogue is tracking properly
    [UnityTest]
    public IEnumerator ShadowDialogueTrackingTest()
    {
        shadowDialogue.ProcessChoice(1); 
        shadowDialogue.currentDialogueIndex = 1;
        yield return null;
        Assert.AreEqual(1, shadowDialogue.currentDialogueIndex, "Dialogue index did not update.");
    }

    //Test 12: test if dialogue resets properly after being locked out
    [UnityTest]
    public IEnumerator ShadowDialogueResetAfterLockoutTest()
    {
        shadowDialogue.TransistionToState(new ShadowLockoutState(shadowDialogue));
        shadowDialogue.EndConversation();
        shadowDialogue = new ShadowDialogue(affectionManager);
        yield return null;
        Assert.AreEqual(0, shadowDialogue.currentDialogueIndex, "Dialogue did not reset after lockout.");
    }


    //Test 13: test if each state properly loads - minigame state
    [UnityTest]
    public IEnumerator ShadowDialogueTransitionToMiniGameStateTest()
    {
    // Transition to Mini-Game State
    shadowDialogue.TransistionToState(new ShadowMiniGameState(shadowDialogue));
    yield return null;

    // Assert that the current state is ShadowMiniGameState
    Assert.IsInstanceOf<ShadowMiniGameState>(shadowDialogue.CurrentState, "Not in Mini-Game State.");
    }

    //Test __ : test if lockout state properly loads
    [UnityTest]
    public IEnumerator ShadowDialogueTransitionToLockoutStateTest()
    {
    // Transition to Lockout State
    shadowDialogue.TransistionToState(new ShadowLockoutState(shadowDialogue));
    yield return null;

    // Assert that the current state is ShadowLockoutState
    Assert.IsInstanceOf<ShadowLockoutState>(shadowDialogue.CurrentState, "Not in Lockout State.");
    }

    //Test ___ : test if normal state properly works
    [UnityTest]
    public IEnumerator ShadowDialogueTransitionToNormalStateTest()
    {
    // Transition to Normal State
    shadowDialogue.TransistionToState(new ShadowNormalState(shadowDialogue));
    yield return null;

    // Assert that the current state is ShadowNormalState
    Assert.IsInstanceOf<ShadowNormalState>(shadowDialogue.CurrentState, "Not in Normal State.");
    }

    //Test 14: Test if buttons are disabled
    [UnityTest]
    public IEnumerator ShadowButtonDisableOnEndTest()
    {
        shadowDialogue.EndConversation();
        yield return null;
        Assert.IsTrue(shadowDialogue.IsConversationFinished(), "Buttons should be disabled at conversation end.");
    }

    // Test 15: see if buttons are able to work after re-enabling
    [UnityTest]
    public IEnumerator ShadowButtonReenableAfterResetTest()
    {
        shadowDialogue.EndConversation();
        shadowDialogue = new ShadowDialogue(affectionManager);
        yield return null;
        Assert.IsFalse(shadowDialogue.IsConversationFinished(), "Buttons should re-enable after reset.");
    }
}
