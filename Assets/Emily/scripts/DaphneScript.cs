using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
public class DaphneScript : DahpneDialogueData
{
    //buttons for dialogue
    public List<string> GetDaphPrompts => DaphPrompts;
    public List<string> GetPlayer_Response_1 => Player_Response_1;
    public List<string> GetPlayer_Response_2 => Player_Response_2;
    public TextMeshProUGUI DaphDialogueText, DaphResponse1Text, DaphResponse2Text;
    
    public static int DaphSCAP;

    public int responseNum = 0;
    public int DaphAffection = 0;
    private string game = "Minesweeper";
    public bool over = false;
    public bool inLove = false;
    //public static int allAffection = 0;
    void Start()
    {
        DisplayDialogue(GetDaphPrompts, DaphDialogueText, DaphResponse1Text, DaphResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, DaphAffection);
    }
    //selection of dialogues
    public void hitDaphResponse1()
    {
        HandlePlayerResponse(1);
        DisplayDialogue(GetDaphPrompts, DaphDialogueText, DaphResponse1Text, DaphResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, DaphAffection);
    }

    public void hitDaphResponse2()
    {
        HandlePlayerResponse(2);
        DisplayDialogue(GetDaphPrompts, DaphDialogueText, DaphResponse1Text, DaphResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, DaphAffection);
    }

    public override void HandlePlayerResponse(int responseNum)
    {
        if ((SCdialogueNum == 1 || SCdialogueNum == 2 || SCdialogueNum == 4) && responseNum == 1)
        {
            DaphAffection = DaphneAffectionPointsMonitor(DaphAffection, 20);
        }
        else if ((SCdialogueNum == 0 || SCdialogueNum == 3) && responseNum == 1)
        {
            DaphAffection = DaphneAffectionPointsMonitor(DaphAffection, -10);
        }
        else if ((SCdialogueNum == 1 || SCdialogueNum == 2 || SCdialogueNum == 4) && responseNum == 2)
        {
            DaphAffection = DaphneAffectionPointsMonitor(DaphAffection, -10);
        }
        else if ((SCdialogueNum == 0 || SCdialogueNum == 3) && responseNum == 2)
        {
            DaphAffection = DaphneAffectionPointsMonitor(DaphAffection, 20);
        }
        if (SCdialogueNum == 5) {
            inLove = PlayOrNot(DaphAffection, responseNum);
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
       SCAP = DaphneAffectionPointsMonitor(DaphAffection,0);
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
            DisplayDialogue(GetDaphPrompts, DaphDialogueText, DaphResponse1Text, DaphResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, DaphAffection);
            over = true;
            return false;
        }
    }
    public int DaphneAffectionPointsMonitor(int AffectionPoints, int factor)
    {
        AffectionPoints += factor;
        Debug.Log("Affection Points: " + AffectionPoints);
        interactionPoints = AffectionPoints;
        DaphSCAP = AffectionPoints;
        DaphneAffectionUpdates();
        return AffectionPoints; 
    }
    public static int DaphneAffectionUpdates(){
        Debug.Log("SCAP = " + DaphSCAP);
        return DaphSCAP;
    }
}*/
