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

    //tracking the affection points
    public static int ShagSCAP;

    public int responseNum = 0;
    //public int ShagSCAP = 0;
    private string game = "Pong";
    //public bool over = false;
    public static bool ShaginteractedWith = false;
    public static bool ShagLockout = false;
    public bool inLove = false;

    void Start()
    {
        if (!ShagLockout){
            DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, ShagSCAP, ShaginteractedWith);
            //EndConversation(ShaginteractedWith, ShagSCAP);
        }
        else {
            Debug.Log("Shaggy is locked out");
        }
    }

    //selection of dialogues
    public void hitShagResponse1()
    {
        HandlePlayerResponse(1);
        DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, ShagSCAP, ShaginteractedWith);
    }

    public void hitShagResponse2()
    {
        HandlePlayerResponse(2);
        DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, ShagSCAP, ShaginteractedWith);
    }

    public override void HandlePlayerResponse(int responseNum)
    {
        Debug.Log("ShaginteractedWith = " + ShaginteractedWith);

        if (!ShaginteractedWith){

            if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 1)
            {
                ShagSCAP = ShaggyAffectionPointsMonitor(ShagSCAP, 20);
            }
            else if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 1)
            {
                ShagSCAP = ShaggyAffectionPointsMonitor(ShagSCAP, -10);
            }
            else if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 2)
            {
                ShagSCAP = ShaggyAffectionPointsMonitor(ShagSCAP, -10);
            }
            else if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 2)
            {
                ShagSCAP = ShaggyAffectionPointsMonitor(ShagSCAP, 20);
            }
            if (SCdialogueNum == 5) {
                inLove = PlayOrNot(ShagSCAP, responseNum);
                if (inLove) 
                {
                    startMiniGameDate(game);
                }
                else 
                {
                    ShaginteractedWith = true;
                    CheckEndConversation();
                } 
            }
            if (SCdialogueNum > 6){
                ShaginteractedWith = true;
                CheckEndConversation();
            }
        }
        base.HandlePlayerResponse(responseNum);
    }

    public bool PlayOrNot(int SCAP, int response)
    {
        SCAP = ShaggyAffectionPointsMonitor(ShagSCAP,0);

        if (SCAP >= 40)
        {
            Debug.Log("Testing if game start conditional works");
            if (response == 1)
            {
               return true;
            }
            else
            {
                SCdialogueNum += 1;
                return false;
            }
        }
        else 
        {
            //DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, ShagSCAP, ShaginteractedWith);
            ShaginteractedWith = true;
            CheckEndConversation();
            return false;
        }
    }

    public int ShaggyAffectionPointsMonitor(int AffectionPoints, int factor)
    {
        AffectionPoints += factor;
        Debug.Log("Affection Points: " + AffectionPoints);
        interactionPoints = AffectionPoints;
        ShagSCAP = AffectionPoints;
        ShaggyAffectionUpdates();
        return AffectionPoints; 
    }

    public static int ShaggyAffectionUpdates()
    {
        Debug.Log("Shag SCAP = " + ShagSCAP);
        return ShagSCAP;
    }
    
    public override void EndConversation(bool characterValue, int affectionPts)
    {
        base.EndConversation(characterValue, ShagSCAP);
        if (characterValue)
        {
            ShagLockout = true;
            Debug.Log("Shaggy's interactions is now locked out");
        }
    }

    public void CheckEndConversation()
    {
        EndConversation(ShaginteractedWith, ShagSCAP);
    }
}
 