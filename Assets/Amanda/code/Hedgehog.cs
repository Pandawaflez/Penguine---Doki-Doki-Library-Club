using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public abstract class HedgehogDialogue
{
    public string CharacterName {get; set;}
    public string DialogueLine{ get; set;}
    protected bool isFinished;
    public IState CurrentState{ get; private set;}
    private string game = "Pong";

    protected HedgehogDialogue(string characterName, string initialDialogue)
    {
        CharacterName = characterName;
        DialogueLine = initialDialogue;
    }
    
        public virtual string[] GetCurrentResponses(){
         //public string[] GetCurrentResponses(){
        return (new string [] {"wow! did you comment out virtual? this is exactly what you need for the oral exam!"});

    }

    //method that will be overridden in derived classes. 
    public abstract void ProcessChoice(int choice);

    public void startMiniGameDate(string game)
    {
        SceneChanger.saveScene();
        SceneManager.LoadScene(game);
    }

    public virtual bool IsConversationFinished()
    {
        return isFinished;
    }

    //add transistion method for state changes
    public void TransistionToState(IState newState)
    {
        CurrentState = newState;
        CurrentState.EnterState();
    }
    
    
}
