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
    public bool t = true;
    public bool f = false;
    public int responseNum = 0;
    public int ShagAffection = 0;
    private string game = "Minesweeper";
    void Start()
    {
        DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, f);
    }
    //selection of dialogues
    public void hitShagResponse1()
    {
        HandlePlayerResponse(1);
        DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, f);
    }

    public void hitShagResponse2()
    {
        HandlePlayerResponse(2);
        DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, f);
    }

    public override void HandlePlayerResponse(int responseNum)
    {
        if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 1)
        {
            ShagAffection += 20;
            Debug.Log("Affection Points increased: " + ShagAffection);
            //ShagAffection = SCAP;
        }
        else if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 1)
        {
            ShagAffection -= 10;
            Debug.Log("Affection Points decreased: " + ShagAffection);
            //ShagAffection = SCAP;
        }
        else if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 2)
        {
            ShagAffection -= 10;
            Debug.Log("Affection Points decreased: " + ShagAffection);
            //ShagAffection = SCAP;
        }
        else if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 2)
        {
            ShagAffection += 20;
            Debug.Log("Affection Points increased: " + ShagAffection);
            //ShagAffection = SCAP;
        }
        if (SCdialogueNum == 5) {
            PlayOrNot(ShagAffection);
        }
        base.HandlePlayerResponse(responseNum);
    }
    public void PlayOrNot(int SCAP)
    {
       
        if (ShagAffection >= 40)
        {
            //SCdialogueNum += 1;
            DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, t);
            if (responseNum == 1){
                startMiniGameDate(game);
            }
            else {
                SCdialogueNum += 1;
            }

        }
        else {
            DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, f);
            return;
        }
        
                
        /*else 
        {
            ShagDialogueText.text = "I don't think we have much in common. Sorry pal, I'll see you around";
            ShagResponse1Text.text = "";
            ShagResponse2Text.text = "";
            DisplayDialogue(ShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, Player_Response_1, Player_Response_2);
            return;
        }*/
    }

    


   // void Update() { }

}
 