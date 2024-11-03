using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public abstract class HedgehogDialogue
{
    public string CharacterName {get; set;}
    public string DialogueLine{ get; set;}
    private string game = "Minesweeper";

    protected HedgehogDialogue(string characterName, string initialDialogue){
        CharacterName = characterName;
        DialogueLine = initialDialogue;
    }
    
   
        public virtual string[] GetCurrentResponses(){
         //public string[] GetCurrentResponses(){
        return (new string [] {"wow! did you comment out virtual? this is exactly what you need for the oral exam!"});

    }

    //method that will be overridden in derived classes. 
    public abstract void ProcessChoice(int choice);

    protected void startMiniGameDate(string game){
        //SceneManager.LoadScene("Pong", LoadSceneMode.Additive);
        SceneChanger.saveScene();
        SceneManager.LoadScene(game);
        //dialogueNum = 8;
    }
    
}
