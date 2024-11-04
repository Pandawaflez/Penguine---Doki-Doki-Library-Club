using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class Scooby
{
   
    //tracking what number dialogue response
    protected int SCdialogueNum = 0;
    //tracking affection points
    public int SCAP;

    public virtual void DisplayDialogue(List<string> prompts,TextMeshProUGUI dialogueText, TextMeshProUGUI response1Text, TextMeshProUGUI response2Text, List<string> Player_Response_1, List<string> Player_Response_2)
    {

        if (SCdialogueNum < prompts.Count)
        {
            dialogueText.text = prompts[SCdialogueNum];
            response1Text.text = Player_Response_1[SCdialogueNum];
            response2Text.text = Player_Response_2[SCdialogueNum];
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
        else if ((SCdialogueNum == 3 || SCdialogueNum == 4 || SCdialogueNum == 5) && responseNum == 2) SCAP -= 10;

        SCdialogueNum += 1;
    }

    
}
