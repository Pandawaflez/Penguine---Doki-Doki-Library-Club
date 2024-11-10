using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ScoobyObserver;

public class FredScript : FredDialogueData, IObserver
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
        //register script as observer
        RegisterObserver(this);
        //if player isn't locked out, they can talk
        if (!FredLockout) 
        {
            DisplayDialogue(GetFredPrompts, FredDialogueText, FredResponse1Text, FredResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, FredSCAP, FredinteractedWith);
            if (MainPlayer.GetMiniGameStatus() != -1)
            {
                UpdateAffectionAfterMinigame();
            }
        }

        else 
        {
            Debug.Log("Fred is locked out"); //fred is locked out for player
        }
    }

    public void Update(int affectionPoints, bool lockoutStatus, bool Shaginteraction, bool Daphinteraction, bool Fredinteraction)
    {
        FredSCAP = affectionPoints;
        FredLockout = lockoutStatus;
        FredinteractedWith = Fredinteraction;
        Debug.Log("Observer Update received in Fred script");
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
            //no bc mode
            else if (((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 1) && !BCModeOn)
            {
                FredSCAP = FredAffectionPointsMonitor(FredSCAP, -10);
            }
            //yes bc mode
            else if (((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 1) && BCModeOn)
            {
                FredSCAP = FredAffectionPointsMonitor(FredSCAP, 5);
            }
            //no bc mode
            else if (((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 2) && !BCModeOn)
            {
                FredSCAP = FredAffectionPointsMonitor(FredSCAP, -10);
            }
            //yes bc mode
            else if (((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 2) && BCModeOn)
            {
                FredSCAP = FredAffectionPointsMonitor(FredSCAP, 5);
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
                UpdateAffectionAfterMinigame();
            }

            if (SCdialogueNum > 6)
            {
                FredinteractedWith = true;
                UpdateAffectionAfterMinigame();
                CheckEndConversation();
            }  
        }

          
        base.HandlePlayerResponse(responseNum);
         if (FredAffectionUpdates() >= 100)
        {
            UIElementHandler.UIGod.EndGame(true, "Fred");
        }     
    }

    

    //controls the affection points and returns them
    public int FredAffectionPointsMonitor(int AffectionPoints, int factor)
    {
        AffectionPoints += factor;
        interactionPoints = AffectionPoints;
        FredSCAP = AffectionPoints;
        FredAffectionUpdates();
        return AffectionPoints; 
    }

    //seeing what the affection points are
    public static int FredAffectionUpdates(){
        return FredSCAP;
    }

    //ends the conversation and locks out the player
    public override void EndConversation(bool characterValue, int affectionPts)
    {
        base.EndConversation(characterValue, FredSCAP);
        if (characterValue && !BCModeOn)
        {
            FredLockout = true;
            UpdateAffectionAfterMinigame();
            Debug.Log("Fred is locked out");
        }
        else if (BCModeOn)
        {
            UIElementHandler.UIGod.EndGame(true,"Fred");
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

    public static void UpdateAffectionAfterMinigame(){

     int miniGameStatus = MainPlayer.GetMiniGameStatus();
        if (miniGameStatus == 1)
        {
            FredSCAP += 50;

        }
        else if (miniGameStatus == 0 && !BCModeOn)
        {
            FredSCAP -= 30;
            FredLockout = true;
        }
        else if (miniGameStatus == 0 && BCModeOn)
        {
            FredSCAP += 5;
        }
        if (FredSCAP >= 100)
        {
            UIElementHandler.UIGod.EndGame(true, "Fred");
        }
    }

    void OnDestroy()
    {
        UnregisteredObserver(this);
    }
}
