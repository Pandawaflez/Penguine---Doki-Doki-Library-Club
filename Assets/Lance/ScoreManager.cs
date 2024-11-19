using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager 
{
    protected int p_playerScore = 0;
    protected int p_scoreToWin;
    protected bool p_isGameOver = false;
    public const int PLAYER_WON = 1;
    public const int WIN_CONDITION_NOT_MET = 0;

    public ScoreManager(int winScore) {
        p_scoreToWin = winScore;
        Debug.Log("ScoreManager::scoreToWin = " + p_scoreToWin);
    }

    public virtual void VAddPlayerScore(int val = 1) {
        p_playerScore += val;
    }

    public virtual int VCheckWinCondition() {
        Debug.Log("ScoreManager::CheckWinCondition");
    // public int CheckWinCondition() {
        if (p_playerScore >= p_scoreToWin) {
            p_isGameOver = true;
            return PLAYER_WON;
        } else {
            return WIN_CONDITION_NOT_MET;
        }
    }

    public int GetPlayerScore() {
        return p_playerScore;
    }

    // static
    public virtual void VSetPlayerHitMine(bool hitMine = true) {
        // empty function for Minesweeper
    }
}
