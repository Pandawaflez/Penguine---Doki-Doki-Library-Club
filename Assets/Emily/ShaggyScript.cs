/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShaggyScript : MonoBehaviour// ShaggyDialogeData
{
    //buttons for dialogue
    
    public TextMeshProUGUI ShagDialogueText, ShagResponse1Text, ShagResponse2Text;
    
    public int responseNum = 0;
    public int ShagAffection = 0;
    void Start()
    {
        DisplayDialogue(ShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, Player_Response_1, Player_Response_2);
    }
    //selection of dialogues
    public void hitShagResponse1()
    {
        HandlePlayerResponse(1);
        DisplayDialogue(ShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, Player_Response_1, Player_Response_2);
    }

    public void hitShagResponse2()
    {
        HandlePlayerResponse(2);
        DisplayDialogue(ShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, Player_Response_1, Player_Response_2);
    }

    public override void HandlePlayerResponse(int responseNum)
    {
        if ((SCdialogueNum == 1 || SCdialogueNum == 2) && responseNum == 1)
        {
            SCAP += 10;
            Debug.Log("Affection Points increased: " + SCAP);
            ShagAffection = SCAP;
        }
        else if ((SCdialogueNum == 3 || SCdialogueNum == 4 || SCdialogueNum == 5) && responseNum == 1)
        {
            SCAP -= 10;
            Debug.Log("Affection Points decreased: " + SCAP);
            ShagAffection = SCAP;
        }
        else if ((SCdialogueNum == 1 || SCdialogueNum == 2) && responseNum == 2)
        {
            SCAP -= 10;
            Debug.Log("Affection Points decreased: " + SCAP);
            ShagAffection = SCAP;
        }
        else if ((SCdialogueNum == 3 || SCdialogueNum == 4 || SCdialogueNum == 5) && responseNum == 1)
        {
            SCAP += 10;
            Debug.Log("Affection Points increased: " + SCAP);
            ShagAffection = SCAP;
        }
        base.HandlePlayerResponse(responseNum);
    }
    public void PlayOrNot(int SCAP)
    {
        if (SCAP >= 40)
        {
            //        "Would you wanna keep this good thing going?"

            //going to transition to minigame
        }
        else 
        {
            ShagDialogueText.text = "I don't think we have much in common. Sorry pal, I'll see you around";
            ShagResponse1Text.text = "";
            ShagResponse2Text.text = "";
            DisplayDialogue(ShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, Player_Response_1, Player_Response_2);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Overworld");
            return;
        }
    }

    


   // void Update() { }

}
 */