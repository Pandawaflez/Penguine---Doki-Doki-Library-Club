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
    public string game = "Minesweeper";


    public List<string> shadowLines = new List<string>()
    {
        "Wassup, I'm Shadow. Did you want something?",
        "You think you can keep up with me? I'd like to see you try.",
        "I am the ultimate life form. ",
        "If you want to stay close, just don't hold me back.",
        "How about we test your abilities? This isn't about friendship... it's about power."

    };

    public List<string[]> playerResponses = new List<string[]>()
    {
        new string[] {$"I'm here to talk to you, you seem pretty cool.", "I was just curious how they allowed you in here."},
        new string[] {"Oh really? What makes you so special?", "Maybe I'm not cut out for this"},
        new string[] {"You surely seem impressive.", "I don't know, I think Sonic is a pretty nice guy."},
        new string[] {"I won't hold you back.", "Wow you are so egotistical."},
        new string[] {"I'll try my best." , "Why would I ever want to play a game against you?"}
    };

    public int currentDialogueIndex = 0;
    public int shdaowResponseIndex = 0;

    public ShadowDialogue(AffectionManager affectionManager)
        : base("Shadow the Hedgehog" , "Wassup I'm Shadow. Did you want something?")
    {
        this.affectionManager = affectionManager;

        //start in normal state
        TransistionToState(new ShadowNormalState(this));
        DialogueLine = shadowLines[currentDialogueIndex];

        //check affection points upon entering - lockout / win cases
        if(AffectionManager.GetShadowAffectionPoints() <= -10)
        {
            DialogueLine = "I don't want to see you again, get outta my face.";
            EndConversation();
            lockoutShadow = true;

        //win case    
        } 
        else if (AffectionManager.GetShadowAffectionPoints() == 100)
        {
            DialogueLine = $"You're back, huh? Looks like you can keep up {playerName}.";
            EndConversation();
            UpdateDialogueAfterMinigame();
        }
        else if(AffectionManager.GetShadowAffectionPoints() == 99)
        {
            DialogueLine = $"Yeah yeah {playerName} you won fair and square, yet you didn't win all my love.";
            EndConversation();
            lockoutShadow = true;
        }
    }

    public override void ProcessChoice(int choice)
    {
        //delegate choice processing to current state
        CurrentState.ProcessChoice(choice);

    }

    public void EndConversation()
    {
        isFinished = true;
    }
    
    //overridden function for oral exam
    public override string[] GetCurrentResponses()
    {
        //public string[] GetCurrentResponses(){

        return(currentDialogueIndex < playerResponses.Count) ? playerResponses[currentDialogueIndex] : new string[0];
       
    }

    public List<string> GetShadowLines()
    {
        return shadowLines;
    }

    public override bool IsConversationFinished()
    {
        return isFinished;
    }

    //function for patrick 
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
            //Debug.Log($"MiniGameStatus: {miniGameStatus}, Affection: {AffectionManager.GetShadowAffectionPoints()}");


        }
        //if player wins mini game shadow doesn't like it.  
        else if((miniGameStatus == 1))
        {
            affectionManager.ChangeShadowAffectionPoints(-1);
            DialogueLine = "Okay way to show off. I guess nice job.";
            lockoutShadow = true;
            //Debug.Log($"22222MiniGameStatus: {miniGameStatus}, Affection: {AffectionManager.GetShadowAffectionPoints()}");

        
        //if player loses shadow thinks ur cute
        }
        else if(miniGameStatus == 0)
        {
            DialogueLine = "I knew you wouldn't be able to win, but you looked cute while trying. *wink*";
            UIElementHandler.UIGod.EndGame(true, "Shadow");
            //Debug.Log($"3333MiniGameStatus: {miniGameStatus}, Affection: {AffectionManager.GetShadowAffectionPoints()}");

        }
        EndConversation();
    }
}
