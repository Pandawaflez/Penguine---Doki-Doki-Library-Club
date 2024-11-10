using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesweeperScoreManager : ScoreManager
{
    // playerScore for MineSweeper is the number of tiles left on the board to click on
    // scoreToWin is numberOfMines left on the board, as those will be only tiles not clicked on
    private bool _didPlayerHitMine;
    public const int PLAYER_HIT_MINE = 3;

    public MinesweeperScoreManager(int numTiles, int numMines): base(numTiles - numMines) {
        _didPlayerHitMine = false;
        Debug.Log("MinesweeperScoreManager::scoreToWin = " + p_scoreToWin);
    }

    public override void VAddPlayerScore(int val = 1) {
        p_playerScore += val;
        Debug.Log("MinesweeperScoreManager::AddPlayerScore::playerScore = " + p_playerScore);
    }

    public override int VCheckWinCondition() {
    // public int CheckWinCondition() {
        if ((p_playerScore == p_scoreToWin) || MainPlayer.IsBCMode()) {
            return PLAYER_WON;
        }
        else if (_didPlayerHitMine) {
            return PLAYER_HIT_MINE;
        } 
        else {
            return WIN_CONDITION_NOT_MET;
        }
    }

    public bool DidPlayerHitMine() {
        return _didPlayerHitMine;
    }

    public override void VSetPlayerHitMine(bool hitMine = true) {
        _didPlayerHitMine = true;
    }
}
