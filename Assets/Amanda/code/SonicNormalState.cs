using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicNormalState : IState
{
    //static reference to dialogue 
    private SonicDialogue dialogue;

    //pass the dialogue instace to the constructor
    public SonicNormalState(SonicDialogue dialogue)
    {
        this.dialogue = dialogue;
    }

    public void EnterState()
    {
        dialogue.DialogueLine = "Hey I'm Sonic! Fastest hedgehog to ever exist!";
    }

    public void ProcessChoice(int choice)
    {
        if(choice == 2)
        {
            //good choice
            dialogue.affectionManager.ChangeSonicAffectionPoints(20);

        }
        else if(choice == 1)
        {
            //bad choice 
            dialogue.affectionManager.ChangeSonicAffectionPoints(-5);
        }

        //check affection points and lockout condition
        if(AffectionManager.GetSonicAffectionPoints() <= -10)
        {
            dialogue.TransistionToState(new SonicLockoutState(dialogue));
            return;
        }
        //check date condition
        if(AffectionManager.GetSonicAffectionPoints() == 100)
        {
            dialogue.TransistionToState(new SonicMiniGameState(dialogue));
            return;
        }

        //act regularly if conditions were not met
        dialogue.sonicCurrentDialogueIndex++;
        if(dialogue.sonicCurrentDialogueIndex < dialogue.sonicLines.Count)
        {
            dialogue.DialogueLine = dialogue.sonicLines[dialogue.sonicCurrentDialogueIndex];
        }
        else
        {
            dialogue.EndConversation();
            SonicDialogue.lockoutSonic = true;

        }
    }
}
