using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ScoobyObserver;

public class ShaggyScript : ShaggyDialogeData, IObserver
{
    //lists for dialogue prompts and responses
    public List<string> GetShagPrompts => ShagPrompts;
    public List<string> GetPlayer_Response_1 => Player_Response_1;
    public List<string> GetPlayer_Response_2 => Player_Response_2;

    //text variables 
    public TextMeshProUGUI ShagDialogueText, ShagResponse1Text, ShagResponse2Text;

    //tracking the affection points
    public static int ShagSCAP;

    //tracking what response the player chose
    public int responseNum = 0;

    //the game shaggy likes to play
    private string game = "Pong";

    //boolean to see if shaggy has been interacted with
    public static bool ShaginteractedWith = false;

    //boolean to see if the player has become locked out of interacting with shaggy
    public static bool ShagLockout = false;

    void Start()
    {
        //register script as observer
        RegisterObserver(this);
        //if player is not locked out, they can talk
        if (!ShagLockout)
        {
            DisplayDialogue(GetShagPrompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, GetPlayer_Response_1, GetPlayer_Response_2, ShagSCAP, ShaginteractedWith);
            if (MainPlayer.GetMiniGameStatus() != -1)
            {
                UpdateAffectionAfterMinigame();
            }
        }

        else
        {
            Debug.Log("Shaggy is locked out"); //they're locked out
        }
    }

    public void Update(int affectionPoints, bool lockoutStatus, bool Shaginteraction, bool Daphinteraction, bool Fredinteraction)
    {
        ShagSCAP = affectionPoints;
        ShagLockout = lockoutStatus;
        ShaginteractedWith = Shaginteraction;

        Debug.Log("Observer Update received in SHaggyScript: SCAP = " + affectionPoints + ", lockout = " + lockoutStatus);
    }


    //selection of responses via buttons
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

    //decides what happens after the player picks a response
    public override void HandlePlayerResponse(int responseNum)
    {   
        
        if (!ShaginteractedWith)
        {
            if ((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 1)
            {
                ShagSCAP = ShaggyAffectionPointsMonitor(ShagSCAP, 20);
            }
            //no bc mode
            else if (((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 1) && !BCModeOn)
            {
                ShagSCAP = ShaggyAffectionPointsMonitor(ShagSCAP, -10);
            }
            //yes bc mode 
            else if (((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 1) && BCModeOn)
            {
                ShagSCAP = ShaggyAffectionPointsMonitor(ShagSCAP, 5);
            }
            //no bc mode
            else if (((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 2) && !BCModeOn)
            {
                ShagSCAP = ShaggyAffectionPointsMonitor(ShagSCAP, -10);
            }
            //yes bc mode
            else if (((SCdialogueNum == 0 || SCdialogueNum == 1) && responseNum == 2) && BCModeOn)
            {
                ShagSCAP = ShaggyAffectionPointsMonitor(ShagSCAP, 5);
            }

            else if ((SCdialogueNum == 2 || SCdialogueNum == 3 || SCdialogueNum == 4) && responseNum == 2)
            {
                ShagSCAP = ShaggyAffectionPointsMonitor(ShagSCAP, 20);
            }
            else if (SCdialogueNum == 5) {
                
                ShaginteractedWith = true;
                UpdateAffectionAfterMinigame();
                ShagLockout = true;
                CheckEndConversation();
            }
            else if (SCdialogueNum == 6 && responseNum == 1)
            {
                //UpdateAffectionAfterMinigame();
                startMiniGameDate(game);
                UpdateAffectionAfterMinigame();
            }
        
            if (SCdialogueNum > 6){
                ShaginteractedWith = true;
                UpdateAffectionAfterMinigame();
                CheckEndConversation();
            }
        }   
        
           
        base.HandlePlayerResponse(responseNum);
        if (ShaggyAffectionUpdates() >= 100)
        {
            UIElementHandler.UIGod.EndGame(true, "Shaggy"); 
        }
    }

    

    //controls the affection points and returns them
    public static int ShaggyAffectionPointsMonitor(int AffectionPoints, int factor)
    {
        AffectionPoints += factor;
        //Debug.Log("Affection Points: " + AffectionPoints);
        //interactionPoints = AffectionPoints;
        ShagSCAP = AffectionPoints;
        ShaggyAffectionUpdates();
        
        return AffectionPoints;
    }

    //seeing what the affection points are
    public static int ShaggyAffectionUpdates()
    {
        
        //Debug.Log("Shag SCAP = " + ShagSCAP);
        return ShagSCAP;
    }
    
    //ends the conversation + locks out the player
    public override void EndConversation(bool characterValue, int affectionPts)
    {
        base.EndConversation(characterValue, ShagSCAP);
        if (characterValue && !BCModeOn)
        {
            ShagLockout = true;
            UpdateAffectionAfterMinigame();
            Debug.Log("Shaggy's interactions is now locked out");
        }
        else if (BCModeOn)
        {
            UIElementHandler.UIGod.EndGame(true, "Shaggy");
        }
    }

    //checks if the conversation has ended
    public void CheckEndConversation()
    {
        EndConversation(ShaginteractedWith, ShagSCAP);

    }

    //checking if shaggy is locked out
    public static bool isShaggyLockedOut()
    {
        return ShagLockout;
    }

    public static void UpdateAffectionAfterMinigame()
    {
        int miniGameStatus = MainPlayer.GetMiniGameStatus();
        if (miniGameStatus == 1)
        {
            ShagSCAP += 50;

        }
        else if (miniGameStatus == 0 && !BCModeOn)
        {
            ShagSCAP -= 30;
            ShagLockout = true;
        }
        else if (miniGameStatus == 0 && BCModeOn)
        {
            ShagSCAP += 5;
        }
        if (ShagSCAP >= 100)
        {
            UIElementHandler.UIGod.EndGame(true, "Shaggy");
        }
    }

    void OnDestroy()
    {
        UnregisteredObserver(this);
    }
}
 