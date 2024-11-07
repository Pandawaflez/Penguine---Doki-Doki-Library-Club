using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DaphneScript : DahpneDialogueData
{
    //buttons for dialogue
    public List<string> GetDaphPrompts => DaphPrompts;
    public List<string> GetPlayer_Response_1 => Player_Response_1;
    public List<string> GetPlayer_Response_2 => Player_Response_2;
    public TextMeshProUGUI DaphDialogueText, DaphResponse1Text, DaphResponse2Text;
    
    public int responseNum = 0;
    public int DaphAffection = 0;
    private string game = "Minesweeper";
    public bool over = false;
    public bool like = false;
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
        if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 1)
        {
            DaphAffection = AffectionPointsMonitor(DaphAffection, 20);
        }
        else if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 1)
        {
            DaphAffection = AffectionPointsMonitor(DaphAffection, -10);
        }
        else if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 2)
        {
            DaphAffection = AffectionPointsMonitor(DaphAffection, -10);
        }
        else if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 2)
        {
            DaphAffection = AffectionPointsMonitor(DaphAffection, 20);
        }
        if (SCdialogueNum == 5) {
            like = PlayOrNot(DaphAffection, responseNum);
            if (like) 
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
       SCAP = AffectionPointsMonitor(DaphAffection,0);
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
}
