using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongScoreManager : ScoreManager
{
    private int aiScore = 0;
    public const int AI_WON = 2;

    public PongScoreManager(int winScore) : base(winScore) {
        Debug.Log("PongScoreManager::scoreToWin = " + scoreToWin);
    }

    public override void AddPlayerScore(int val = 0) {
        if (playerScore < scoreToWin) {
            playerScore++;
        }
        Debug.Log("PongScoreManager::AddPlayerScore\tplayerScore = " + playerScore);
    }

    public void AddAIScore() {
        if (aiScore < scoreToWin) {
            aiScore++;
        }
        Debug.Log("PongScoreManager::AddAIScore\tAIScore = " + aiScore);
    }

    // Dynamic binding - check if win condition is met for pong game
    public override int CheckWinCondition() {
        Debug.Log("playerScore");
        if (playerScore >= scoreToWin) {
            Debug.Log("Player Won!");
            return PLAYER_WON;
        } else if (aiScore >= scoreToWin) {
            Debug.Log("AI Won :(");
            return AI_WON;
        }
        return WIN_CONDITION_NOT_MET;
    }

    public int GetAIScore() {
        return aiScore;
    }
}
