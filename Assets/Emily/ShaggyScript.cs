using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShaggyScript : Scooby
{
    //buttons for dialogue
    public Button ShagR1;
    public Button ShagR2;
    public TextMeshProUGUI ShagDialogueText, ShagResponse1Text, ShagResponse2Text;
    public GameObject Shag1p;
    public GameObject Shag2p;
    public int responseNum = 0;
    public int ShagAffection = 0;
    void Start()
    {
        DisplayDialogue(ShagDialogueText, ShagResponse1Text, ShagResponse2Text);
    }
    //selection of dialogues
    public void hitShagResponse1()
    {
        HandlePlayerResponse(1);
        DisplayDialogue(ShagDialogueText, ShagResponse1Text, ShagResponse2Text);
    }

    public void hitShagResponse2()
    {
        HandlePlayerResponse(2);
        DisplayDialogue(ShagDialogueText, ShagResponse1Text, ShagResponse2Text);
    }

    public override void HandlePlayerResponse(int resopnseNum)
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
            DisplayDialogue(ShagDialogueText, ShagResponse1Text, ShagResponse2Text);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Overworld");
            return;
        }
    }

    


   // void Update() { }

}
