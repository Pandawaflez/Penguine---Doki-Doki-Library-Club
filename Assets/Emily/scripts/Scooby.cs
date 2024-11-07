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
    public int SCAP;
    public static bool interactedWith = false;
    public static int interactionPoints = 0; 
    public void startMiniGameDate(string game){
        SceneChanger.saveScene();
        SceneManager.LoadScene(game);
    }

    public virtual void DisplayDialogue(List<string> prompts,TextMeshProUGUI dialogueText, TextMeshProUGUI response1Text, TextMeshProUGUI response2Text, List<string> Player_Response_1, List<string> Player_Response_2, int SCAP) 
    {
        if (SCdialogueNum < prompts.Count)
        {
            if (SCdialogueNum > 4){
                int TotalPoints = AffectionPointsMonitor(SCAP, 0);
                if (SCdialogueNum == 5 && TotalPoints >= 50)
                {
                    dialogueText.text = prompts[6];
                    response1Text.text = Player_Response_1[5];
                    response2Text.text = Player_Response_2[5];
                }
                else if (SCdialogueNum == 5 && TotalPoints < 50)
                {
                    dialogueText.text = prompts[5];
                    response1Text.text = Player_Response_1[6];
                    response2Text.text = Player_Response_2[6];
                }
                else if (SCdialogueNum == 6){
                    dialogueText.text = prompts[SCdialogueNum];
                    response1Text.text = Player_Response_1[6];
                    response2Text.text = Player_Response_2[6];
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
            dialogueText.text = "";
            response1Text.text = "";
            response2Text.text = "";
        }
    }

    public virtual void HandlePlayerResponse(int responseNum)
    {
        if (responseNum == 1) SCAP += 10;
        else if (responseNum == 2) SCAP -= 10;

        SCdialogueNum += 1;
    }
    public int AffectionPointsMonitor(int AffectionPoints, int factor)
    {
        AffectionPoints += factor;
        Debug.Log("Affection Points: " + AffectionPoints);
        interactionPoints = AffectionPoints;
        SCAP = AffectionPoints;
        AffectionUpdates();
        return AffectionPoints; 
    }

    public bool InteractionMonitor(int interactionPoints)
    {
        Debug.Log("InteractionMonitor");
        if (interactionPoints > 0)
        {
            interactedWith = true;
            Debug.Log("interactedWith = " + interactedWith);
            return interactedWith;
        }
        else 
        {
            interactedWith = false;
            Debug.Log("interactedWith = " + interactedWith);
            return interactedWith;
        }
    }
    public int AffectionUpdates(){
        Debug.Log("SCAP = " + SCAP);
        return SCAP;
    }
    
    
}
