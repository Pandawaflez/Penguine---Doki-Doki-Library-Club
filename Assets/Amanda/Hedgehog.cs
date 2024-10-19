using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class HedgehogDialogue
{
    public string CharacterName {get; set;}
    public string DialogueLine{ get; set;}

    protected HedgehogDialogue(string characterName, string initialDialogue){
        CharacterName = characterName;
        DialogueLine = initialDialogue;
    }
    
    //marked as abstract to then implement it in a sub class
    //virtual for get
    //abstract

    //add virtual 
    

    public virtual string[] GetCurrentResponses(){
        // public string[] GetCurrentResponses(){
        return (new string [] {"i am confused"});

    }

    //method that will be overridden in derived classes. 
    public abstract void ProcessChoice(int choice);
    
}
