using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicMiniGameState : IState
{
    private SonicDialogue dialogue;

    public SonicMiniGameState(SonicDialogue dialogue)
    {
        this.dialogue = dialogue;
    }

    public void EnterState()
    {
        dialogue.DialogueLine = $"Let's test your speed, {dialogue.playerName}! Get ready for the game!";
        dialogue.startMiniGameDate(dialogue.game);
    }

    public void ProcessChoice(int choice){
        //no choice needed
    }
    //after minigame, give result
    public void UpdateDialogueAfterMinigame()
    {
        int miniGameStatus = MainPlayer.GetMiniGameStatus();

        if (miniGameStatus == 1) // Player wins
        {
            dialogue.DialogueLine = "Wow you're the fastest of them all! I think you're pretty cool.";
            UIElementHandler.UIGod.EndGame(true, "Sonic");
        }
        else if (miniGameStatus == 0) // Player loses
        {
            dialogue.DialogueLine = $"At least you tried, good job {dialogue.playerName}.";
            SonicDialogue.lockoutSonic = true; // Lockout after loss
        }

        dialogue.EndConversation(); // End the conversation after the mini-game

    }
}
