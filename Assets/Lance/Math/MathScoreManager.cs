using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathScoreManager : ScoreManager
{
    public MathScoreManager(int winScore) : base(winScore) {
        Debug.Log("Score to Win = " + p_scoreToWin);
    }

    // override parent class
    public override void VAddPlayerScore(int val) {
        p_playerScore += val;
    }
}
