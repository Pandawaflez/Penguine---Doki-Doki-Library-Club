using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShaggyScript : ShaggyDialogeData
{
    //buttons for dialogue
    public List<string> GetShagPrompts => ShagPrompts;
    public List<string> GetPlayer_Response_1 => Player_Response_1;
    public List<string> GetPlayer_Response_2 => Player_Response_2;
    public TextMeshProUGUI ShagDialogueText, ShagResponse1Text, ShagResponse2Text;
    public int responseNum = 0;
    public int ShagAffection = 0;
    private string game = "Pong";
    public bool over = false;
    public bool inLove = false;
    void Start()
    {
        DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, ShagAffection);
        InteractionMonitor(ShagAffection);
    }
    //selection of dialogues
    public void hitShagResponse1()
    {
        HandlePlayerResponse(1);
        DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, ShagAffection);
    }

    public void hitShagResponse2()
    {
        HandlePlayerResponse(2);
        DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, ShagAffection);
    }

    public override void HandlePlayerResponse(int responseNum)
    {
        if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 1)
        {
            ShagAffection = AffectionPointsMonitor(ShagAffection, 20);
        }
        else if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 1)
        {
            ShagAffection = AffectionPointsMonitor(ShagAffection, -10);
        }
        else if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 2)
        {
            ShagAffection = AffectionPointsMonitor(ShagAffection, -10);
        }
        else if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 2)
        {
            ShagAffection = AffectionPointsMonitor(ShagAffection, 20);
        }
        if (SCdialogueNum == 5) {
            inLove = PlayOrNot(ShagAffection, responseNum);
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
       SCAP = AffectionPointsMonitor(ShagAffection,0);
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
            DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, ShagAffection);
            over = true;
            return false;
        }
    }
}
 