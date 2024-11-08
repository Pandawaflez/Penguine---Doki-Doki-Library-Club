using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMiniGameState : IState
{
    private ShadowDialogue dialogue;

    public ShadowMiniGameState(ShadowDialogue dialogue)
    {
        this.dialogue = dialogue;
    }

    public void EnterState()
    {
        dialogue.DialogueLine = "Let's play. You're about to get cooked.";
        dialogue.startMiniGameDate(dialogue.game);
    }

    public void ProcessChoice(int choice){
        //no choice needed
    }
    
    }

