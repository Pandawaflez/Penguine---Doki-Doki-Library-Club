using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesweeperScoreManager : ScoreManager
{
    // playerScore for MineSweeper is the number of tiles left on the board to click on
    // scoreToWin is numberOfMines left on the board, as those will be only tiles not clicked on
    private bool didPlayerHitMine;
    public const int PLAYER_HIT_MINE = 3;

    public MinesweeperScoreManager(int numTiles, int numMines): base(numTiles - numMines) {
        didPlayerHitMine = false;
        Debug.Log("scoreToWin = " + scoreToWin);
    }

    public override void AddPlayerScore(int val = 1) {
        playerScore += val;
        Debug.Log("MinesweeperScoreManager::AddPlayerScore::playerScore = " + playerScore);
    }

    public override int CheckWinCondition() {
        if (didPlayerHitMine) {
            return PLAYER_HIT_MINE;
        } else if (playerScore == scoreToWin) {
            Debug.Log("Player won!");
            return PLAYER_WON;
        } else {
            return WIN_CONDITION_NOT_MET;
        }
    }

    public bool DidPlayerHitMine() {
        return didPlayerHitMine;
    }

    public void SetPlayerHitMine(bool hitMine = true) {
        didPlayerHitMine = true;
    }
}
