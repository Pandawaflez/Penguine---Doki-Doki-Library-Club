using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonicDialogue : HedgehogDialogue
{
    public AffectionManager affectionManager;
    public static bool lockoutSonic = false;
    public string game = "Math";
    private bool isFinished = false;

    public string playerName = MainPlayer.GetPlayerName();

    private List<string> sonicLines = new List<string>(){
        "Hey I'm Sonic! Fastest hedgehog alive! Need anything?",
        "What really? I am the best hedgehog around.",
        "There's still a long way to go if you wanna match my speed!",
        "How about a game? I love video games. I'll go easy on you, maybe.",
        "Here we go! Let's keep the good times rollin'!"
    };

    private List<string[]> playerResponses = new List<string[]>(){
        new string[] {"I think Shadow is faster than you.", "Sonic! I'm your #1 fan!"},
        new string[] {"No, lol. Shadow is definitely cooler than you.", "You can say that again."},
        new string[] {"I think I could outrun you...", "You're the best, Sonic!"},
        new string[] {"You're so cocky, I thought Shadow was the confident one", "Hit me with your best shot."},
        new string[] {"...I don't really want to play with you." , "omg I'm really about to play against sonic right now"}
    };

    private int sonicCurrentDialogueIndex = 0;
    private int sonicResponseIndex = 0;

    public SonicDialogue(AffectionManager affectionManager)
        : base("Sonic the Hedgehog" , "Hey I'm Sonic. Did you need any help?")
    {
        this.affectionManager = affectionManager;

        DialogueLine = sonicLines[sonicCurrentDialogueIndex];
    
        //check sonic's current affection points and lock out if needed
        if(AffectionManager.GetSonicAffectionPoints() <= -10){
            DialogueLine = "You're not as cool as I thought. I gotta go fast...";
            EndConversation();
            lockoutSonic = true;
        //check sonic points and win case
        } else if(AffectionManager.GetSonicAffectionPoints() == 100 ){
            DialogueLine = $"Oh nice, you're back. I'm glad to see you, {playerName}!";
            EndConversation();
            UpdateDialogueAfterMinigame();
        }
    }

    public override void ProcessChoice(int choice){
        if(choice == 2){
            //best choice +20
            affectionManager.ChangeSonicAffectionPoints(20);
        }
        else if(choice == 1){
            //bad choice
            affectionManager.ChangeSonicAffectionPoints(-10);
        }

        //check for neg affectoin points then end convo 
        if(AffectionManager.GetSonicAffectionPoints() <= -10){
            DialogueLine = "You're not as cool as I thought... Leave me alone.";
            EndConversation();
            lockoutSonic = true;
            return;
        }

        //check max affection points
        if(AffectionManager.GetSonicAffectionPoints() == 100){
            DialogueLine = "Let's really test your speed. Hope you can keep up!.";
            startMiniGameDate(game);
            return;
            UpdateDialogueAfterMinigame();
        }

        sonicCurrentDialogueIndex++;
        //check if there is a next dialogue before incrementing
        if(sonicCurrentDialogueIndex < sonicLines.Count){
            sonicResponseIndex++;
            DialogueLine = sonicLines[sonicCurrentDialogueIndex];
        } else {
            EndConversation();
        }
    }

    //endconversation will lock out the response buttons by sending bool to UImanager
    private void EndConversation(){
        isFinished = true; 
    }
    
    public override string[] GetCurrentResponses(){
        //public string[] GetCurrentResponses(){
        if(sonicCurrentDialogueIndex < playerResponses.Count){
        return playerResponses[sonicResponseIndex];
        }
        return new string[0]; // return an empty array if out of bounds
    }

    public override bool IsConversationFinished(){
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
        }
        EndConversation();
    }
}
