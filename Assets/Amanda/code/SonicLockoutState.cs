using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicLockoutState : IState
{
    private SonicDialogue dialogue;

    public SonicLockoutState(SonicDialogue dialogue)
    {
        this.dialogue = dialogue;
    }
    public void EnterState()
    {
        dialogue.DialogueLine = "You're not as cool as I thought. I gotta go fast...";
        SonicDialogue.lockoutSonic = true;
        dialogue.EndConversation();
    }

    public void ProcessChoice(int choice)
    {
        // lockout = no choice 
    }
}
