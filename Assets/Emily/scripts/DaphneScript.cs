using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DaphneScript : DahpneDialogueData
{
    //lists for dialogue prompts and responses
    public List<string> GetDaphPrompts => DaphPrompts;
    public List<string> GetPlayer_Response_1 => Player_Response_1;
    public List<string> GetPlayer_Response_2 => Player_Response_2;

    //text variables
    public TextMeshProUGUI DaphDialogueText, DaphResponse1Text, DaphResponse2Text;
    
    //tracking the affection points
    public static int DaphSCAP;

    //tracking what response the player chose
    public int responseNum = 0;

    //the game daphne likes to play
    private string game = "Minesweeper";

    //boolean to see if daphne has been interacted with
    public static bool DaphinteractedWith = false;

    //boolean to see if player has become locked out
    public static bool DaphLockout = false;
    
    void Start()
    {   
        //if player is not locked out, they can talk
        if (!DaphLockout)
        {
            DisplayDialogue(GetDaphPrompts, DaphDialogueText, DaphResponse1Text, DaphResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, DaphSCAP, DaphinteractedWith);
        }

        else 
        {
            Debug.Log("Daphne is locked out");
        }
    }


    //selection of responses via buttons
    public void hitDaphResponse1()
    {
        HandlePlayerResponse(1);
        DisplayDialogue(GetDaphPrompts, DaphDialogueText, DaphResponse1Text, DaphResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, DaphSCAP, DaphinteractedWith);
    }

    public void hitDaphResponse2()
    {
        HandlePlayerResponse(2);
        DisplayDialogue(GetDaphPrompts, DaphDialogueText, DaphResponse1Text, DaphResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, DaphSCAP, DaphinteractedWith);
    }

    //decides what happens after player picks a response
    public override void HandlePlayerResponse(int responseNum)
    {
        if (!DaphinteractedWith)
        {
            if ((SCdialogueNum == 1 || SCdialogueNum == 2 || SCdialogueNum == 4) && responseNum == 1)
            {
                DaphSCAP = DaphneAffectionPointsMonitor(DaphSCAP, 20);
            }
            else if ((SCdialogueNum == 0 || SCdialogueNum == 3) && responseNum == 1)
            {
                DaphSCAP = DaphneAffectionPointsMonitor(DaphSCAP, -10);
            }
            else if ((SCdialogueNum == 1 || SCdialogueNum == 2 || SCdialogueNum == 4) && responseNum == 2)
            {
                DaphSCAP = DaphneAffectionPointsMonitor(DaphSCAP, -10);
            }
            else if ((SCdialogueNum == 0 || SCdialogueNum == 3) && responseNum == 2)
            {
                DaphSCAP = DaphneAffectionPointsMonitor(DaphSCAP, 20);
            }
            else if (SCdialogueNum == 5) {
                DaphinteractedWith = true;
                DaphLockout = true;
                CheckEndConversation();
            }
            else if (SCdialogueNum == 6 && responseNum == 1)
            {
                startMiniGameDate(game);
            }

            if (SCdialogueNum > 6)
            {
                DaphinteractedWith = true;
                CheckEndConversation();
            }
        }
        base.HandlePlayerResponse(responseNum);
    }

    //seeing if player and character should begin their date
    public bool PlayOrNot(int SCAP, int response)
    {
       SCAP = DaphneAffectionPointsMonitor(DaphSCAP,0);
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
        else 
        {
            DaphinteractedWith = true;
            DaphLockout = true;
            CheckEndConversation();
            return false;
        }
    }

    //controls the affection points and returns them
    public int DaphneAffectionPointsMonitor(int AffectionPoints, int factor)
    {
        AffectionPoints += factor;
        Debug.Log("Affection Points: " + AffectionPoints);
        interactionPoints = AffectionPoints;
        DaphSCAP = AffectionPoints;
        DaphneAffectionUpdates();
        return AffectionPoints; 
    }
    
    //seeing what affection points are
    public static int DaphneAffectionUpdates(){
        Debug.Log("SCAP = " + DaphSCAP);
        return DaphSCAP;
    }

    //ends the conversation and locks out the player
    public override void EndConversation(bool characterValue, int affectionPts)
    {
        base.EndConversation(characterValue, DaphSCAP);
        if (characterValue)
        {
            DaphLockout = true;
            Debug.Log("Daphne's interaction is now locked out");
        }
    }

    //checks if the conversation has ended
    public void CheckEndConversation()
    {
        EndConversation(DaphinteractedWith, DaphSCAP);
    }

    //checking if daphne is locked out
    public static bool isDaphneLockedOut()
    {
        return DaphLockout;
    }
}
