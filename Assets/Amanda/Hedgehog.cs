using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class HedgehogDialogue
{
    public string CharacterName {get; private set;}
    public string DialogueLine{ get; private set;}

    protected HedgehogDialogue(string characterName, string dialogueLine){
        CharacterName = characterName;
        DialogueLine = dialogueLine;
    }
    
    //method that will be overridden in derived classes. 
    //public abstract void ProcessPlayerChoice(int choice);
    
}
