using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShadowDialogue : HedgehogDialogue
{
    public AffectionManager affectionManager;
    //game
            private string game = "Minesweeper";

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
        //check affection points upon entering
        if (affectionManager.GetShadowAffectionPoints() <= -10)
        {
            DialogueLine = "I don't want to see you again.";
        }
        else if (affectionManager.GetShadowAffectionPoints() == 100)
        {
            DialogueLine = "You're back, huh? Looks like you can keep up.";
        }
    }

    public override void ProcessChoice(int choice){
        if(choice == 1){
            //best choice +20
            affectionManager.ChangeShadowAffectionPoints(20);
        }
        else if(choice == 2){
            //bad choice
            affectionManager.ChangeShadowAffectionPoints(-10);
        }

        //check affection points / date
        // If affection points are -10 or lower, load the main menu
        if (affectionManager.GetShadowAffectionPoints() <= -10)
        {
            DialogueLine = "Wow. You are a real piece of work.";
            UnityEngine.SceneManagement.SceneManager.LoadScene("Overworld");
            return;
        } else if(affectionManager.GetShadowAffectionPoints() == 100){
            DialogueLine = "Let's play. You're about to get cooked.";
            // add carson's function
            //SceneChanger.saveScene();
            startMiniGameDate(game);
            //SceneManager.LoadScene(Math);
            return;
        }
        
        //check if there is a next dialogue before incrementing
        if(currentDialogueIndex + 1 < shadowLines.Count){
            currentDialogueIndex++;
            DialogueLine = shadowLines[currentDialogueIndex];
        } else {
            EndConversation();
            //affectionManager.GameOver();
        }
    
    }

    private void EndConversation(){
        DialogueLine = "Bye. See you never.";
    
        //DialogueLine = "Hmph. You might be worth keeping around.";
        //initate the mini game date if player has enough affection points.
    }
    
    public override string[] GetCurrentResponses(){
        //public string[] GetCurrentResponses(){
        if(currentDialogueIndex < playerResponses.Count){
        return playerResponses[currentDialogueIndex];
        }
        return new string[0]; // return an empty array if out of bounds
    }
}