using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoobBoundaryTest2
{
    // A Test behaves as an ordinary method
    [Test]
    public void ScoobBoundaryTest2SimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ScoobBoundaryTest2WithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}

public class DialogueBoundary
{
    private DialogueSystem dialogueSystem;
    public Text dialoguesingle;
    public Button[] responseButtons;

    [SetUp]
    public void SetUp(){
        dialogueSystem = new DialogueSystem();
        // error dialoguesingle = new GameObject("DialogueText").AddComponent<dialoguesingle>();
        responseButtons = new Button[2];

        for (int i = 0; i < responseButtons.Length; i++){
            responseButtons[i] = new GameObject($"ResponseButton{i}").AddComponent<Button>();
            responseButtons[i].gameObject.AddComponent<Text>().text = "";
        }

        //error dialogueSystem.DialogueText = dialoguesingle;
        dialogueSystem.ResponseButtons = responseButtons;
    }

    [Test]
    public void TestInitialDialogue(){

        string expectedDialogue = "Welcome";
        string[] expectedResponses = {"Hello", "How are you"};

        dialogueSystem.LoadDialogue(0);

        Assert.AreEqual(expectedDialogue, dialogueSystem.DialogueText.text, "The initla dialogue text did not load correctly");

        /*for (int i = 0; i < expectedResponses.Length; i++){
          // error  Assert.AreEqual(expectedResponses[i], dialogueSystem.ResponseButtons[i].GetComponent<dialoguesingle>().text, $"The response button {i} text did not load corrently");
        }*/
    }

    [Test]
    public void TestEmptyDialogue(){
        dialogueSystem.LoadDialogue(-1);

        Assert.AreEqual("", dialogueSystem.DialogueText.text, "Dialogue text should be empty when no valid dialogue is loaded");

        /* for (int i = 0; i < responseButtons.Length; i++){
            erro Assert.AreEqual("", dialogueSystem.ResponseButtons[i].GetComponent<dialoguesingle>().text, $"Response button {i} text should be empty when no valid dialogue is laoded");
        } */
    }

    [Test]
    public void TestLongDialogue(){
        string longDialogue = new string('A', 1000);
        string [] longResponses = { new string('B', 500), new string('C', 500), new string ('D', 500)};

        dialogueSystem.SetDialogueText(longDialogue);
        dialogueSystem.SetResponseOptions(longResponses);

        Assert.AreEqual(longDialogue, dialogueSystem.DialogueText.text, "The long dialogue text did not load correctly");

        /*for (int i = 0; i < longResponses.Length; i++){
            error Assert.AreEqual(longResponses[i], dialogueSystem.ResponseButtons[i].GetComponent<dialoguesingle>().text, $"The long response button {i} text did not load correctly.");
        }*/
    }
}

public class DialogueSystem
{
    public Text DialogueText;
    public Button[] ResponseButtons;

    public void LoadDialogue(int index)
    {
        if (index == 0)
        {
            SetDialogueText("Welcome to the game!");
            SetResponseOptions(new string[] { "Hello!", "Who are you?", "Goodbye!" });
        }
        else
        {
            SetDialogueText("");  // Simulate empty dialogue for invalid indexes
            SetResponseOptions(new string[] { "", "", "" });
        }
    }

    public void SetDialogueText(string text)
    {
        if (DialogueText != null)
        {
            DialogueText.text = text;
        }
    }

    public void SetResponseOptions(string[] responses)
    {
        for (int i = 0; i < responses.Length; i++)
        {
            if (ResponseButtons[i] != null)
            {
                ResponseButtons[i].GetComponent<Text>().text = responses[i];
            }
        }
    }
}