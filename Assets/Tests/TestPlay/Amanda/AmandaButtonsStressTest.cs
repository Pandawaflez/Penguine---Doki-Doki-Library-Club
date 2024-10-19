/*
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AmandaButtonsStressTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void AmandaButtonsStressTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AmandaButtonsStressTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}

public class ButtonStressTest 
{
   public Button response1Button; //attach to button 1 in scene
    public Button response2Button; // attaach to button 2 in scene

    
    public AffectionManager affectionManager = new AffectionManager();
    //public ShadowDialogue shadowDialogue = new ShadowDialogue(affectionManager);
    //StartCoroutine(RapidInteractionTest());
    
    private System.Collections.IEnumerator RapidInteractionTest(){
        Debug.Log("Starting stress test: ");
        
        //rapidly press response 1 20 times
        for(int i = 0; i < 20; i++){
            response1Button.onClick.Invoke();
            //wait until next frame
            yield return null;
        }

        //test response 2 20 times
        for(int i = 0; i < 20; i++){
            response2Button.onClick.Invoke();
            yield return null;
        }
        Debug.Log("Stress Test Completed");
    }
}

public class AffectionManager 
{
    private const int MAX_AFFECTION = 100;
    private const int MIN_AFFECTION = -10;
    
    private int affectionPoints;
    
    private List<IAffectionObserver> observers = new List<IAffectionObserver>();

    public void changeAffectionPoints(int points){
        affectionPoints += points;

        //clamp affection points to the limits
        affectionPoints = Mathf.Clamp(affectionPoints, MIN_AFFECTION, MAX_AFFECTION);
        
        NotifyChangedAffection();
    }

    public int GetAffectionPoints(){
        return affectionPoints;
    }
    
    public void RegisterObserver(IAffectionObserver observer){
        observers.Add(observer);
    }

    private void NotifyChangedAffection(){
        foreach (IAffectionObserver observer in observers){
            observer.OnAffectionChanged(affectionPoints);
        }
    }

    public void GameOver(){
        if(affectionPoints < 0){
            Debug.Log("Affection Points Below 0: Lock Shadow Out");
        } else {
            Debug.Log("You're okay for now");
        }
    }
}

public class ShadowDialogue : HedgehogDialogue
{
    private AffectionManager affectionManager;

    private List<string> shadowLines = new List<string>(){
        "Wassup, I'm Shadow. Did you want something?",
        "You think you can keep up with me? I'd like to see you try.",
        "I am the ultimate life form. ",
        "If you want to stay close, just don't hold me back.",
        "How about we test your abilities? This isn't about friendship... it's about power."

    };

    private List<string[]> playerResponses = new List<string[]>(){
        new string[] {"I'm here to talk to you, you seem pretty cool.", "I was just curious how they allowed you in here."},
        new string[] {"Oh really? What makes you so special?", "Maybe I'm not cut out for this"},
        new string[] {"You surely seem impressive.", "I don't know, I think Sonic is a pretty nice guy."},
        new string[] {"I won't hold you back.", "Wow you are so egotistical."},
        new string[] {"I'll try my best." , "Why would I ever want to play a game against you?"}
    };

    private int currentDialogueIndex = 0;

    public ShadowDialogue(AffectionManager affectionManager)
        : base("Shadow the Hedgehog" , "Wassup I'm Shadow. Did you want something?")
    {
        this.affectionManager = affectionManager;
    }

    public override void ProcessChoice(int choice){
        if(choice == 1){
            //best choice +20
            affectionManager.changeAffectionPoints(20);
        }
        else if(choice == 2){
            //bad choice
            affectionManager.changeAffectionPoints(-10);
        }

        //check if there is a next dialogue before incrementing
        if(currentDialogueIndex + 1 < shadowLines.Count){
            currentDialogueIndex++;
            DialogueLine = shadowLines[currentDialogueIndex];
        } else {
            EndConversation();
            affectionManager.GameOver();
        }
    
    }

    private void EndConversation(){
        DialogueLine = "Bye. See you never.";
    
        //DialogueLine = "Hmph. You might be worth keeping around.";
        //initate the mini game date if player has enough affection points.

        
    }
    
    public override string[] GetCurrentResponses(){
        if(currentDialogueIndex < playerResponses.Count){
        return playerResponses[currentDialogueIndex];
        }
        return new string[0]; // return an empty array if out of bounds
    }
}

*/

