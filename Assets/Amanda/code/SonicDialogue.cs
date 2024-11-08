using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonicDialogue : HedgehogDialogue
{
    public AffectionManager affectionManager;
    public static bool lockoutSonic = false;
    public string game = "Math";
    public bool isFinished = false;

    public string playerName = MainPlayer.GetPlayerName();

    public List<string> sonicLines = new List<string>()
    {
        "Hey I'm Sanic! Fastest hedgehog alive! Need anything?",
        "What really? I am the best hedgehog around.",
        "Did you know speed is my middle name? Actually... it's Maurice, but don't tell anyone ok?",
        "There's still a long way to go if you wanna match my speed!",
        "How about a game? I love video games. I'll go easy on you, maybe.",
        "Here we go! Let's keep the good times rollin'!",
    };

    public List<string[]> playerResponses = new List<string[]>()
    {
        new string[] {"I think Shadow is faster than you.", "Sanic! I'm your #1 fan!"},
        new string[] {"No, lol. Shadow is definitely cooler than you.", "You can say that again."},
        new string[] {"Did you just try to lie to me? I do not like you.", "Maurice huh? Sanic Maurice Hedgehog? SMH lol. I like that."},
        new string[] {"I think I could outrun you...", "You're the best, Sanic!"},
        new string[] {"You're so cocky, I thought Shadow was the confident one", "Hit me with your best shot."},
        new string[] {"...I don't really want to play with you." , "omg I'm really about to play against Sanic right now"}
        
    };

    public int sonicCurrentDialogueIndex = 0;
    public int sonicResponseIndex = 0;

    public SonicDialogue(AffectionManager affectionManager)
        : base("Sonic the Hedgehog" , "Hey I'm Sanic. Did you need any help?")
    {
        this.affectionManager = affectionManager;
        
        //start in normal state
        TransistionToState(new SonicNormalState(this));

        DialogueLine = sonicLines[sonicCurrentDialogueIndex];
 
        //check sonic's current affection points and lock out if needed
        if(AffectionManager.GetSonicAffectionPoints() <= -10)
        {
            DialogueLine = "You're not as cool as I thought. I gotta go fast...";
            EndConversation();
            lockoutSonic = true;
            
        //check sonic points and win case
        } else if(AffectionManager.GetSonicAffectionPoints() == 100 )
        {
            DialogueLine = $"Oh nice, you're back. I'm glad to see you, {playerName}!";
            EndConversation();
            UpdateDialogueAfterMinigame();
        } 
        
    }

    public override void ProcessChoice(int choice)
    {
        //delegate choice processing to current state
        CurrentState.ProcessChoice(choice);
    }

    //endconversation will lock out the response buttons by sending bool to UImanager
    public void EndConversation(){
        isFinished = true; 
    }
    
    public override string[] GetCurrentResponses(){
        //public string[] GetCurrentResponses(){

        return(sonicCurrentDialogueIndex < playerResponses.Count) ? playerResponses[sonicCurrentDialogueIndex] : new string[0];
    
        //return new string[0]; // return an empty array if out of bounds
    }

    public bool IsConversationFinished(){
        return isFinished;
    }

    public static bool CheckSonicLockout(){
        return lockoutSonic;
    }

    public void UpdateDialogueAfterMinigame(){
        int miniGameStatus = MainPlayer.GetMiniGameStatus();
        
        //if player wins minigame
        if (miniGameStatus == 1) 
        {
            DialogueLine = "Wow you're the fastest of them all! I think you're pretty cool.";
            
            UIElementHandler.UIGod.EndGame(true, "Sonic");
        }
        
        //if player loses
        else if (miniGameStatus == 0)
        {
            DialogueLine = $"At least you tried, good job {playerName}.";
            lockoutSonic = true;
        }

        EndConversation(); 
    } 

}
