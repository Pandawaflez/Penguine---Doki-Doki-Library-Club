using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController 
{
    public HedgehogDialogue currentDialogue;
    public DialogueController(HedgehogDialogue dialogue){
        currentDialogue = dialogue;
        //Debug.Log("This is dialogue controller");
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
