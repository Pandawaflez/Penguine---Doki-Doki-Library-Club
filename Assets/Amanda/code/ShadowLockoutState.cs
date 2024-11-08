using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLockoutState : IState
{
    public string playerName = MainPlayer.GetPlayerName();
    private ShadowDialogue dialogue;
    //playerName should be public from shadow dialogue class

    public ShadowLockoutState(ShadowDialogue dialogue)
    {
        this.dialogue = dialogue;
    }
    public void EnterState()
    {
        dialogue.DialogueLine = $"Lockout: I don't wnat to see you again {playerName}, get outta my face.";
        ShadowDialogue.lockoutShadow = true;
        dialogue.EndConversation();
    }

    public void ProcessChoice(int choice)
    {
        // lockout = no choice 
    }
}
