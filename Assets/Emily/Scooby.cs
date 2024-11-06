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
    protected void startMiniGameDate(string game){
        SceneChanger.saveScene();
        SceneManager.LoadScene(game);
    }

    public virtual void DisplayDialogue(List<string> prompts,TextMeshProUGUI dialogueText, TextMeshProUGUI response1Text, TextMeshProUGUI response2Text, List<string> Player_Response_1, List<string> Player_Response_2, bool highScore) 
    {
        if (SCdialogueNum < prompts.Count)
        {
            dialogueText.text = prompts[SCdialogueNum];
            response1Text.text = Player_Response_1[SCdialogueNum];
            response2Text.text = Player_Response_2[SCdialogueNum];
        }
        else if (SCdialogueNum == 4 && highScore)
        {
            dialogueText.text = prompts[6];
            response1Text.text = Player_Response_1[6];
            response2Text.text = Player_Response_2[6];
        }
        else if (SCdialogueNum == 4 && !highScore)
        {
            dialogueText.text = prompts[5];
            response1Text.text = Player_Response_1[5];
            response2Text.text = Player_Response_2[5];
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

    
}
