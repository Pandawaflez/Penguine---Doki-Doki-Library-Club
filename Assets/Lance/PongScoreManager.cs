using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongScoreManager : ScoreManager
{
    private int _aiScore = 0;
    public const int AI_WON = 2;

    public PongScoreManager(int winScore) : base(winScore) {
        Debug.Log("PongScoreManager::scoreToWin = " + p_scoreToWin);
    }

    public override void VAddPlayerScore(int val = 0) {
        if (p_playerScore < p_scoreToWin) {
            p_playerScore++;
        }
        Debug.Log("PongScoreManager::AddPlayerScore\tplayerScore = " + p_playerScore);
    }

    public void AddAIScore() {
        if (_aiScore < p_scoreToWin) {
            if (MainPlayer.IsBCMode()) {
                // add to BC's score instead of AI's score
                VAddPlayerScore();
            } else {
                _aiScore++;
            }
        }
        Debug.Log("PongScoreManager::AddAIScore\tAIScore = " + _aiScore);
    }

    // Dynamic binding - check if win condition is met for pong game. Without Dynamic binding, AI can never win
    public override int VCheckWinCondition() {
    // public int CheckWinCondition() {
        Debug.Log("PongScoreManager::CheckWinCondition");
        if (p_playerScore >= p_scoreToWin) {
            Debug.Log("Player Won!");
            return PLAYER_WON;
        } else if (_aiScore >= p_scoreToWin) {
            if (MainPlayer.IsBCMode()) {
                // BC Can never lose
                return PLAYER_WON;
            }
            return AI_WON;
        }
        return WIN_CONDITION_NOT_MET;
    }

    public int GetAIScore() {
        return _aiScore;
    }
}
