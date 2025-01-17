using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ScoobyObserver;

public class DaphneScript : DahpneDialogueData, IObserver
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
        //register script as observer
        RegisterObserver(this);
        //if player is not locked out, they can talk
        if (!DaphLockout)
        {
            DisplayDialogue(GetDaphPrompts, DaphDialogueText, DaphResponse1Text, DaphResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, DaphSCAP, DaphinteractedWith);
            if (MainPlayer.GetMiniGameStatus() != -1)
            {
                UpdateAffectionAfterMinigame();
            }
        }

        else 
        {
            Debug.Log("Daphne is locked out");
        }
    }

    public void Update(int affectionPoints, bool lockoutStatus, bool Shaginteraction, bool Daphinteraction, bool Fredinteraction)
    {
        DaphSCAP = affectionPoints;
        DaphLockout = lockoutStatus;
        DaphinteractedWith = Daphinteraction;

        Debug.Log("Observer received in DaphneScript");
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
            //no bc mode
            else if (((SCdialogueNum == 0 || SCdialogueNum == 3) && responseNum == 1) && !BCModeOn)
            {
                DaphSCAP = DaphneAffectionPointsMonitor(DaphSCAP, -10);
            }
            //yes bc mode
            else if (((SCdialogueNum == 0 || SCdialogueNum == 3) && responseNum == 1) && BCModeOn)
            {
                DaphSCAP = DaphneAffectionPointsMonitor(DaphSCAP, 5);
            }
            //no bc mode
            else if (((SCdialogueNum == 1 || SCdialogueNum == 2 || SCdialogueNum == 4) && responseNum == 2) && !BCModeOn)
            {
                DaphSCAP = DaphneAffectionPointsMonitor(DaphSCAP, -10);
            }
            //yes bc mode
            else if (((SCdialogueNum == 1 || SCdialogueNum == 2 || SCdialogueNum == 4) && responseNum == 2) && BCModeOn)
            {
                DaphSCAP = DaphneAffectionPointsMonitor(DaphSCAP, 5);
            }
            else if ((SCdialogueNum == 0 || SCdialogueNum == 3) && responseNum == 2)
            {
                DaphSCAP = DaphneAffectionPointsMonitor(DaphSCAP, 20);
            }
            else if (SCdialogueNum == 5) {
                DaphinteractedWith = true;
                UpdateAffectionAfterMinigame();
                DaphLockout = true;
                CheckEndConversation();
            }
            else if (SCdialogueNum == 6 && responseNum == 1)
            {
                startMiniGameDate(game);
                UpdateAffectionAfterMinigame();
            }

            if (SCdialogueNum > 6)
            {
                DaphinteractedWith = true;
                UpdateAffectionAfterMinigame();
                CheckEndConversation();
            }
        }
        
        base.HandlePlayerResponse(responseNum);
        if (DaphneAffectionUpdates() >= 100)
        {
            UIElementHandler.UIGod.EndGame(true, "Daphne"); 
        }
    }

    

    //controls the affection points and returns them
    public int DaphneAffectionPointsMonitor(int AffectionPoints, int factor)
    {
        AffectionPoints += factor;
        //Debug.Log("Affection Points: " + AffectionPoints);
        //interactionPoints = AffectionPoints;
        DaphSCAP = AffectionPoints;
        DaphneAffectionUpdates();
        return AffectionPoints; 
    }
    
    //seeing what affection points are
    public static int DaphneAffectionUpdates(){
       // Debug.Log("SCAP = " + DaphSCAP);
        return DaphSCAP;
    }

    //ends the conversation and locks out the player
    public override void EndConversation(bool characterValue, int affectionPts)
    {
        base.EndConversation(characterValue, DaphSCAP);
        if (characterValue && !BCModeOn)
        {
            DaphLockout = true;
            Debug.Log("Daphne's interaction is now locked out");
        }
        else if (BCModeOn)
        {
            UIElementHandler.UIGod.EndGame(true, "Daphne");
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

    public static void UpdateAffectionAfterMinigame()
    {
        int miniGameStatus = MainPlayer.GetMiniGameStatus();
        if (miniGameStatus == 1)
        {
            DaphSCAP += 50;

        }
        else if (miniGameStatus == 0 && !BCModeOn)
        {
            DaphSCAP -= 30;
            DaphLockout = true;
        }
        else if (miniGameStatus == 0 && BCModeOn)
        {
            DaphSCAP += 5;
        }
        if (DaphSCAP >= 100)
        {
            UIElementHandler.UIGod.EndGame(true, "Daphne");
        }
    }

    void OnDestroy()
    {
        UnregisteredObserver(this);
    }
}
