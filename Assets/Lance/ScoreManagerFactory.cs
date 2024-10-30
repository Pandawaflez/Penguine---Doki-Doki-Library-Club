using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManagerFactory {
    public static ScoreManager CreateScoreManager(string gameType, int winScore, int additionalParam = 0) {
        switch (gameType) {
            case "Pong":
                return new PongScoreManager(winScore);
                break;
            
            case "Minesweeper":
                return new MinesweeperScoreManager(winScore, additionalParam);
                break;
            
            case "Math":
                return new MathScoreManager(winScore);
                break;
            
            default:
                throw new System.ArgumentException("Unkown game type");
        }
    }
}
