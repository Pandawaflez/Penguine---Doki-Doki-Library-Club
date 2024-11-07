using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShadowDialogue : HedgehogDialogue
{
    public AffectionManager affectionManager;
    public string playerName = MainPlayer.GetPlayerName();
    public static bool lockoutShadow = false;
    private bool isFinished = false;
    private string game = "Minesweeper";


    private List<string> shadowLines = new List<string>()
    {
        "Wassup, I'm Shadow. Did you want something?",
        "You think you can keep up with me? I'd like to see you try.",
        "I am the ultimate life form. ",
        "If you want to stay close, just don't hold me back.",
        "How about we test your abilities? This isn't about friendship... it's about power."

    };

    private List<string[]> playerResponses = new List<string[]>()
    {
        new string[] {$"I'm here to talk to you, you seem pretty cool.", "I was just curious how they allowed you in here."},
        new string[] {"Oh really? What makes you so special?", "Maybe I'm not cut out for this"},
        new string[] {"You surely seem impressive.", "I don't know, I think Sonic is a pretty nice guy."},
        new string[] {"I won't hold you back.", "Wow you are so egotistical."},
        new string[] {"I'll try my best." , "Why would I ever want to play a game against you?"}
    };

    private int currentDialogueIndex = 0;
    private int shdaowResponseIndex = 0;

    public ShadowDialogue(AffectionManager affectionManager)
        : base("Shadow the Hedgehog" , "Wassup I'm Shadow. Did you want something?")
    {
        this.affectionManager = affectionManager;
        DialogueLine = shadowLines[currentDialogueIndex];

        //check affection points upon entering - lockout / win cases
        if(AffectionManager.GetShadowAffectionPoints() <= -10)
        {
            DialogueLine = "I don't want to see you again, get outta my face.";
            EndConversation();
            lockoutShadow = true;

        //win case    
        } else if (AffectionManager.GetShadowAffectionPoints() == 100)
        {
            DialogueLine = $"You're back, huh? Looks like you can keep up {playerName}.";
            EndConversation();
            UpdateDialogueAfterMinigame();
        }
    }

    public override void ProcessChoice(int choice)
    {
        if(choice == 1){
            //best choice +20
            affectionManager.ChangeShadowAffectionPoints(20);
        }
        else if(choice == 2)
        {
            //bad choice
            affectionManager.ChangeShadowAffectionPoints(-5);
        }

        //check affection points / date
        // If affection points are -10 or lower, lockout
        if (AffectionManager.GetShadowAffectionPoints() <= -10)
        {
            DialogueLine = "Wow. You are a real piece of work.";
            EndConversation();
            lockoutShadow = true;
            return;   
        } 
        
        if(AffectionManager.GetShadowAffectionPoints() == 100)
        {
            DialogueLine = "Let's play. You're about to get cooked.";
            startMiniGameDate(game);
            return;
            UpdateDialogueAfterMinigame();
        }

        currentDialogueIndex++;
        
        //check if there is a next dialogue before incrementing
        if(currentDialogueIndex < shadowLines.Count)
        {
            shdaowResponseIndex++;
            DialogueLine = shadowLines[currentDialogueIndex];
        } else {
            EndConversation();
        }
    }

    private void EndConversation()
    {
        isFinished = true;
    }
    
    //overridden function for oral exam
    public override string[] GetCurrentResponses()
    {
        //public string[] GetCurrentResponses(){
        if(currentDialogueIndex < playerResponses.Count)
        {
            return playerResponses[currentDialogueIndex];
        }
        return new string[0]; // return an empty array if out of bounds
    }

    public override bool IsConversationFinished()
    {
        return isFinished;
    }

    public static bool CheckShadowLockout()
    {
        return lockoutShadow;
    }

    public void UpdateDialogueAfterMinigame()
    {
        int miniGameStatus = MainPlayer.GetMiniGameStatus();

        //if BC mode - player will win, so shadow must like it when you win in BC mode
        if((MainPlayer.IsBCMode()) && (miniGameStatus == 1)){
            DialogueLine = $"Alright you got me. I love to see you win BC. (get it because you're in BC mode)";
            UIElementHandler.UIGod.EndGame(true, "Shadow");

        } 

        //if player wins minigame shadow doesn't like it UNLESS BC MODE
        if((miniGameStatus == 1) && !(MainPlayer.IsBCMode()))
        {
            DialogueLine = $"Okay way to show off. I guess nice job {playerName}.";
            lockoutShadow = true;
        
        //if player loses shadow thinks ur cute
        } else if(miniGameStatus == 0)
        {
            DialogueLine = "I knew you wouldn't be able to win, but you looked cute while trying. *wink*";
            UIElementHandler.UIGod.EndGame(true, "Shadow");
        }
    }
}
