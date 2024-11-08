using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowNormalState : IState
{
    //static reference to dialogue 
    private ShadowDialogue dialogue;

    //pass the dialogue instace to the constructor
    public ShadowNormalState(ShadowDialogue dialogue)
    {
        this.dialogue = dialogue;
    }

    public void EnterState()
    {
        dialogue.DialogueLine = "Wassup I'm Shudow in normal state. Did you want something?";
    }

    public void ProcessChoice(int choice)
    {
        if(choice == 1){
            //best choice +20
            dialogue.affectionManager.ChangeShadowAffectionPoints(20);
        }
        else if(choice == 2)
        {
            //bad choice
            dialogue.affectionManager.ChangeShadowAffectionPoints(-5);
        }

        //check affection points / date
        // If affection points are -10 or lower, lockout
        if (AffectionManager.GetShadowAffectionPoints() <= -10)
        {
            dialogue.TransistionToState(new ShadowLockoutState(dialogue));
            return;   
        } 
        
        //check date condition
        if(AffectionManager.GetShadowAffectionPoints() == 100)
        {
            dialogue.TransistionToState(new ShadowMiniGameState(dialogue));
            return;
        }

        //Otherwise: do normal dialogue
        dialogue.currentDialogueIndex++;
        //check if there is a next dialogue before incrementing
        if(dialogue.currentDialogueIndex < dialogue.shadowLines.Count)
        {
            dialogue.DialogueLine = dialogue.shadowLines[dialogue.currentDialogueIndex];
        } else {
            dialogue.EndConversation();
            ShadowDialogue.lockoutShadow = true;
        }
    }
}
