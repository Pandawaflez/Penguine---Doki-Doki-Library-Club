using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager 
{
    protected int playerScore = 0;
    protected int scoreToWin;
    protected bool isGameOver = false;
    public const int PLAYER_WON = 1;
    public const int WIN_CONDITION_NOT_MET = 0;

    public ScoreManager(int winScore) {
        scoreToWin = winScore;
    }

    public virtual void AddPlayerScore(int val = 1) {
        playerScore += val;
    }

    // Check if the win condition is met
    public virtual int CheckWinCondition() {
        if (playerScore >= scoreToWin) {
            isGameOver = true;
            return PLAYER_WON;
        } else {
            return WIN_CONDITION_NOT_MET;
        }
    }

    public int GetPlayerScore() {
        return playerScore;
    }
}