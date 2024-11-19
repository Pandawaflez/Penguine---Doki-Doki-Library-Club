using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicMiniGameState : IState
{
    private SonicDialogue dialogue;

    public SonicMiniGameState(SonicDialogue dialogue)
    {
        this.dialogue = dialogue;
    }

    public void EnterState()
    {
        dialogue.DialogueLine = $"Let's test your speed, {dialogue.playerName}! Get ready for the game!";
        dialogue.startMiniGameDate(dialogue.game);
    }

    public void ProcessChoice(int choice){
        //no choice needed
    }
}
