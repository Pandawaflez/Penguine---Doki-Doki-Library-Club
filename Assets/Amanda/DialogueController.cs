using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController 
{
    private HedgehogDialogue currentDialogue;

    public DialogueController(HedgehogDialogue dialogue){
        currentDialogue = dialogue;
    }

    public string GetCurrentDialogueLine(){
        return currentDialogue.DialogueLine;
    }

    public string[] GetCurrentResponses(){
        return currentDialogue.GetCurrentResponses();
    }

    public void HandlePlayerChoice(int choice){
        currentDialogue.ProcessChoice(choice);
    }
}
