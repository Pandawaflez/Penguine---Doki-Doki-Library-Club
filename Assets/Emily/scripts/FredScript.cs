using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
public class FredScript : FredDialogueData
{
    //buttons for dialogue
    public List<string> GetFredPrompts => FredPrompts;
    public List<string> GetPlayer_Response_1 => Player_Response_1;
    public List<string> GetPlayer_Response_2 => Player_Response_2;
    public TextMeshProUGUI FredDialogueText, FredResponse1Text, FredResponse2Text;
    
    public static int FredSCAP;
    public int responseNum = 0;
    public int FredAffection = 0;
    private string game = "Math";
    public bool over = false;
    public bool inLove = false;
    void Start()
    {
        DisplayDialogue(GetFredPrompts, FredDialogueText, FredResponse1Text, FredResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, FredAffection);
    }
    //selection of dialogues
    public void hitFredResponse1()
    {
        HandlePlayerResponse(1);
        DisplayDialogue(GetFredPrompts, FredDialogueText, FredResponse1Text, FredResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, FredAffection);
    }

    public void hitFredResponse2()
    {
        HandlePlayerResponse(2);
        DisplayDialogue(GetFredPrompts, FredDialogueText, FredResponse1Text, FredResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, FredAffection);
    }

    public override void HandlePlayerResponse(int responseNum)
    {
        if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 1)
        {
            FredAffection = FredAffectionPointsMonitor(FredAffection, 20);
        }
        else if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 1)
        {
            FredAffection = FredAffectionPointsMonitor(FredAffection, -10);
        }
        else if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 2)
        {
            FredAffection = FredAffectionPointsMonitor(FredAffection, -10);
        }
        else if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 2)
        {
            FredAffection = FredAffectionPointsMonitor(FredAffection, 20);
        }
        if (SCdialogueNum == 5) {
            inLove = PlayOrNot(FredAffection, responseNum);
            if (inLove) 
            {
                startMiniGameDate(game);
            }
            else 
            {
                over = true;
            }
            
        }
        base.HandlePlayerResponse(responseNum);
    }
    public bool PlayOrNot(int SCAP, int response)
    {
       SCAP = FredAffectionPointsMonitor(FredAffection,0);
        if (SCAP >= 40)
        {
            Debug.Log("Testing if game start conditional works");
            if (response == 1){
               return true;
            }
            else {
                SCdialogueNum += 1;
                return false;
            }
        }
        else {
            DisplayDialogue(GetFredPrompts, FredDialogueText, FredResponse1Text, FredResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, FredAffection);
            over = true;
            return false;
        }
    }

    public int FredAffectionPointsMonitor(int AffectionPoints, int factor)
    {
        AffectionPoints += factor;
        Debug.Log("Affection Points: " + AffectionPoints);
        interactionPoints = AffectionPoints;
        FredSCAP = AffectionPoints;
        FredAffectionUpdates();
        return AffectionPoints; 
    }
    public static int FredAffectionUpdates(){
        Debug.Log("SCAP = " + FredSCAP);
        return FredSCAP;
    }
}
*/