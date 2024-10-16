using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathScoreManager : ScoreManager
{
    public MathScoreManager(int winScore) : base(winScore) {
        Debug.Log("Score to Win = " + scoreToWin);
    }

    // override parent class
    public override void AddPlayerScore(int val) {
        playerScore += val;
    }
}
