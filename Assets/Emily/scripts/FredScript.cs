using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FredScript : FredDialogueData
{
    //lists for dialogue prompts and responses
    public List<string> GetFredPrompts => FredPrompts;
    public List<string> GetPlayer_Response_1 => Player_Response_1;
    public List<string> GetPlayer_Response_2 => Player_Response_2;

    //text variables
    public TextMeshProUGUI FredDialogueText, FredResponse1Text, FredResponse2Text;
    
    //tracking affection points
    public static int FredSCAP;

    //tracking what response the player chooses
    public int responseNum = 0;

    //the game fred likes to play
    private string game = "Math";

    //boolean to see if fred has been interacted with
    public static bool FredinteractedWith = false;

    //boolean to see if player has become locked out of interacting with fred
    public static bool FredLockout = false;

    void Start()
    {
        if (!FredLockout) //if player isn't locked out, they can talk
        {
            DisplayDialogue(GetFredPrompts, FredDialogueText, FredResponse1Text, FredResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, FredSCAP, FredinteractedWith);
        }

        else 
        {
            Debug.Log("Fred is locked out"); //fred is locked out for player
        }
    }

    //selection of responses via buttons
    public void hitFredResponse1()
    {
        HandlePlayerResponse(1);
        DisplayDialogue(GetFredPrompts, FredDialogueText, FredResponse1Text, FredResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, FredSCAP, FredinteractedWith);
    }

    public void hitFredResponse2()
    {
        HandlePlayerResponse(2);
        DisplayDialogue(GetFredPrompts, FredDialogueText, FredResponse1Text, FredResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, FredSCAP, FredinteractedWith);
    }

    //decides what happens after player picks a repsponse
    public override void HandlePlayerResponse(int responseNum)
    {
        if (!FredinteractedWith){
            if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 1)
            {
                FredSCAP = FredAffectionPointsMonitor(FredSCAP, 20);
            }
            else if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 1)
            {
                FredSCAP = FredAffectionPointsMonitor(FredSCAP, -10);
            }
            else if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 2)
            {
                FredSCAP = FredAffectionPointsMonitor(FredSCAP, -10);
            }
            else if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 2)
            {
                FredSCAP = FredAffectionPointsMonitor(FredSCAP, 20);
            }
            else if (SCdialogueNum == 5) 
            {
                FredinteractedWith = true;
                FredLockout = true;
                CheckEndConversation();
            }
            else if (SCdialogueNum == 6 && responseNum == 1)
            {
                startMiniGameDate(game);
            }

            if (SCdialogueNum > 6)
            {
                FredinteractedWith = true;
                CheckEndConversation();
            }  
        }        
        base.HandlePlayerResponse(responseNum);
    }

    //seeing if the player and character should begin their date
    public bool PlayOrNot(int SCAP, int response)
    {
       SCAP = FredAffectionPointsMonitor(FredSCAP,0);
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
        else {
            FredinteractedWith = true;
            FredLockout = true;
            CheckEndConversation();
            return false;
        }
    }

    //controls the affection points and returns them
    public int FredAffectionPointsMonitor(int AffectionPoints, int factor)
    {
        AffectionPoints += factor;
        Debug.Log("Affection Points: " + AffectionPoints);
        interactionPoints = AffectionPoints;
        FredSCAP = AffectionPoints;
        FredAffectionUpdates();
        return AffectionPoints; 
    }

    //seeing what the affection points are
    public static int FredAffectionUpdates(){
        Debug.Log("SCAP = " + FredSCAP);
        return FredSCAP;
    }

    //ends the conversation and locks out the player
    public override void EndConversation(bool characterValue, int affectionPts)
    {
        base.EndConversation(characterValue, FredSCAP);
        if (characterValue)
        {
            FredLockout = true;
            Debug.Log("Fred is locked out");
        }
    }

    //checks if conversation has ended
    public void CheckEndConversation()
    {
        EndConversation(FredinteractedWith, FredSCAP);
    }

    //checking if fred is locked out
    public static bool isFredLockedOut()
    {
        return FredLockout;
    }
}
