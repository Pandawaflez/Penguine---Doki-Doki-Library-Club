using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Scooby
{
   
    //tracking what number dialogue response
    public int SCdialogueNum = 0;
    //tracking affection points
    //public static bool interactedWith = false;
    public static bool ShaginteractedWith = false;
    public static int interactionPoints = 0; 
    public int SCAP;
    protected bool lockout = false;
    public void startMiniGameDate(string game){
        SceneChanger.saveScene();
        SceneManager.LoadScene(game);
    }

    public virtual void DisplayDialogue(List<string> prompts,TextMeshProUGUI dialogueText, TextMeshProUGUI response1Text, TextMeshProUGUI response2Text, List<string> Player_Response_1, List<string> Player_Response_2, int SCAP, bool interactedWith) 
    {
        //int totalPoints = SCAP;
        if (interactedWith){
            dialogueText.text = "It was nice getting to know you";
            response1Text.text = "";
            response2Text.text = "";
            return;
        }
            if (SCdialogueNum < prompts.Count)
            {
                Debug.Log("Dialogue #: " + SCdialogueNum);
                if (SCdialogueNum > 4){
                    //int TotalPoints = AffectionPointsMonitor(SCAP, 0);
                    if (SCdialogueNum == 5 && SCAP >= 50)
                    {
                        dialogueText.text = prompts[6];
                        response1Text.text = Player_Response_1[5];
                        response2Text.text = Player_Response_2[5];
                    }
                    else if (SCdialogueNum == 5 && SCAP < 50)
                    {
                        dialogueText.text = prompts[5];
                        response1Text.text = Player_Response_1[6];
                        response2Text.text = Player_Response_2[6];
                        interactedWith = true;
                    }
                    else if (SCdialogueNum == 6){
                        dialogueText.text = prompts[SCdialogueNum];
                        response1Text.text = Player_Response_1[6];
                        response2Text.text = Player_Response_2[6];
                        interactedWith = true;
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
    public virtual void EndConversation(bool characterValue)
    {
        if (characterValue) lockout = true; 
        Debug.Log("Conversation lockout set to " + lockout);
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
    

    
    
    
    
    
}
