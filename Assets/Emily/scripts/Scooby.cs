using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ScoobyObserver;

public abstract class Scooby : ISubject //superclass
{
   //list to hold observers
   private List<IObserver> observers = new List<IObserver>();

    //tracking what number dialogue response
    public int SCdialogueNum = 0;

    //tracking affection points
    public static int interactionPoints = 0; 

    //tracking whether each character has been interacted with or not
    public static bool ShaginteractedWith = false;
    public static bool DaphinteractedWith = false;
    public static bool FredinteractedWith = false;
    public static bool BCModeOn = MainPlayer.IsBCMode();


    //tracking affection points for characters
    public int SCAP;

    //boolean for if a character is locked out to be used in IsConversationLockedOut method
    public bool lockout = false;

    //register an observer
    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    //unregister an observer
    public void UnregisteredObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(SCAP, lockout, ShaginteractedWith, DaphinteractedWith, FredinteractedWith);
        }
    }
    
    //method for starting the date (using Lance's code), using a game name that differs per character
    public void startMiniGameDate(string game){
        SceneChanger.saveScene();
        SceneManager.LoadScene(game);
    }

    // DisplayDialogue method that displays dialogues for characters
    public virtual void DisplayDialogue(List<string> prompts,TextMeshProUGUI dialogueText, TextMeshProUGUI response1Text, TextMeshProUGUI response2Text, List<string> Player_Response_1, List<string> Player_Response_2, int SCAP, bool interactedWith) 
    {
        //checking if the character has been interacted with based on boolean provided when the method is called
        if (interactedWith){
            Debug.Log("THE CHARACTER HAS BEEN INTERACTED WITH");
            dialogueText.text = "It was nice getting to know you";
            response1Text.text = "";
            response2Text.text = "";
            return; //cuts off interaction
        }
        //continues the conversation while there are still prompts
            else if (SCdialogueNum < prompts.Count)
            {
                Debug.Log("Dialogue #: " + SCdialogueNum);
                if (SCdialogueNum > 4){
                    //int TotalPoints = AffectionPointsMonitor(SCAP, 0);
                    if (SCdialogueNum == 5 && SCAP >= 50)
                    {
                        SCdialogueNum = 6;
                        dialogueText.text = prompts[6];
                        response1Text.text = Player_Response_1[5];
                        response2Text.text = Player_Response_2[5];
                    }
                    else if (SCdialogueNum == 5 && SCAP < 50)
                    {
                        interactedWith = true;
                        dialogueText.text = prompts[5];
                        response1Text.text = Player_Response_1[6];
                        response2Text.text = Player_Response_2[6];
                    }
                    else if (SCdialogueNum == 6){
                        dialogueText.text = prompts[SCdialogueNum];
                        response1Text.text = Player_Response_1[6];
                        response2Text.text = Player_Response_2[6];
                        //interactedWith = true;
                    }
                }
                else {
                    dialogueText.text = prompts[SCdialogueNum];
                    response1Text.text = Player_Response_1[SCdialogueNum];
                    response2Text.text = Player_Response_2[SCdialogueNum];
                }
            
            }
            else
            {
                dialogueText.text = "It was nice getting to know you!";
                response1Text.text = "";
                response2Text.text = "";
                interactedWith = true;
            }
       
    }
    public virtual void EndConversation(bool characterValue, int affectionPts)
    {
        if (affectionPts != 0){
            if (characterValue)
            {
                lockout = true; 
                NotifyObservers();
                Debug.Log("Conversation lockout set to " + lockout);
            }
        }
    }
    public bool IsConversationLockedOut(){
        return lockout;
    }
    public virtual void HandlePlayerResponse(int responseNum)
    {
        if (responseNum == 1) SCAP += 10;
        else if (responseNum == 2) SCAP -= 10;

        SCdialogueNum += 1;
    }
    
    public void SetCharacterInteraction(string character, bool hasInteracted)
    {
        switch (character)
        {
            case "Shaggy":
                ShaginteractedWith = hasInteracted;
                break;
            case "Daphne":
                DaphinteractedWith = hasInteracted;
                break;
            case "Fred":
                FredinteractedWith = hasInteracted;
                break;
        }
        NotifyObservers();
    }
}
