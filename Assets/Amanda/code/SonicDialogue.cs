using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonicDialogue : HedgehogDialogue
{
    public AffectionManager affectionManager;
    public string game = "Math";

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
        new string[] {"Let's see what you got." , "omg I'm really about to play against sonic right now"}
    };

    private int sonicCurrentDialogueIndex = 0;
    private int sonicResponseIndex = 0;

    public SonicDialogue(AffectionManager affectionManager)
        : base("Sonic the Hedgehog" , "Hey I'm Sonic. Did you need any help?")
    {
        this.affectionManager = affectionManager;

        DialogueLine = sonicLines[StartGameData.sonicCurrentDialogueIndex];
    
        //check sonic's current affection points and lock out if needed
        if(AffectionManager.GetSonicAffectionPoints() <= -10){
            DialogueLine = "You're not as cool as I thought. I gotta go fast...";
        } else if(AffectionManager.GetSonicAffectionPoints() == 100){
            DialogueLine = "Oh nice, you're back. I'm glad to see you!";
        }
    }

    public override void ProcessChoice(int choice){
        if(choice == 2){
            //best choice +20
            //swapped from shadow's options
            //StartGameData.sonicAffectionPoints += 20;
            affectionManager.ChangeSonicAffectionPoints(20);
        }
        else if(choice == 1){
            //bad choice
            //StartGameData.sonicAffectionPoints -= 10;
            affectionManager.ChangeSonicAffectionPoints(-10);
        }

        sonicCurrentDialogueIndex++;
        sonicResponseIndex++;
        StartGameData.sonicCurrentDialogueIndex++;

        //load library and leave conversation if -10 affection
        if(AffectionManager.GetSonicAffectionPoints() <= -10){
            DialogueLine = "Please don't talk to me again.";
            //lockout character here? 
            UnityEngine.SceneManagement.SceneManager.LoadScene("Overworld");
            return;
        } else if(AffectionManager.GetSonicAffectionPoints() == 100){
            DialogueLine = "Wanna play a game with me? Let's really test your speed.";
            //SceneChanger.saveScene();
            //SceneManager.LoadScene(Math);
            //return;
            startMiniGameDate(game);
            //UnityEngine.SceneManagement.SceneManager.LoadScene("Math");
            //return;
        }
        
        //check if there is a next dialogue before incrementing
        if(sonicCurrentDialogueIndex + 1 < sonicLines.Count){
            StartGameData.sonicResponseIndex++;
            DialogueLine = sonicLines[sonicCurrentDialogueIndex];
        } else {
            EndConversation();
        }
    
    }

    private void EndConversation(){
        DialogueLine = "Gotta go fast!";
        //initate the mini game date if player has enough affection points.
    }
    
    public override string[] GetCurrentResponses(){
        //public string[] GetCurrentResponses(){
        if(sonicCurrentDialogueIndex < playerResponses.Count){
        return playerResponses[sonicResponseIndex];
        }
        return new string[0]; // return an empty array if out of bounds
    }
}
