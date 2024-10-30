using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Lance_ScoreManagerTests {
    private ScoreManager pongScoreManager;
    private ScoreManager minesweeperScoreManager;
    private ScoreManager mathScoreManager;

    private const int PONG_WIN_SCORE = 10;
    private const int MINESWEEPER_NUM_MINES = 9;
    private const int MINESWEEPER_WIN_SCORE = 81;
    private const int MATH_WIN_SCORE = 50;


    [SetUp]
    public void Setup() {
        pongScoreManager = ScoreManagerFactory.CreateScoreManager("Pong", PONG_WIN_SCORE);
        minesweeperScoreManager = ScoreManagerFactory.CreateScoreManager("Minesweeper", MINESWEEPER_WIN_SCORE, MINESWEEPER_NUM_MINES);
        mathScoreManager = ScoreManagerFactory.CreateScoreManager("Math", MATH_WIN_SCORE);
    }

    // PongScoreManager Tests
    [Test]
    public void PongScoreManager_InitialScore_ShouldBeZero() {
        Assert.AreEqual(0, pongScoreManager.GetPlayerScore());
    }

    [Test]
    public void PongScoreManager_AddScore_IncreasesScoreByOne() {
        pongScoreManager.AddPlayerScore(1);
        Assert.AreEqual(1, pongScoreManager.GetPlayerScore());
    }

    [Test]
    public void PongScoreManager_CheckPlayerWinCondition_ShouldWinWhenScoreIs10() {
        for (int i = 0; i < 10; i++) pongScoreManager.AddPlayerScore(1);
        Assert.AreEqual(ScoreManager.PLAYER_WON, pongScoreManager.CheckWinCondition());
    }

    [Test]
    public void PongScoreManager_CheckAIWinCondition_ShouldWinWhenScoreIs10() {
        for (int i = 0; i < 10; i++) (pongScoreManager as PongScoreManager)?.AddAIScore();
        Assert.AreEqual(PongScoreManager.AI_WON, pongScoreManager.CheckWinCondition());
    }

    [Test]
    public void PongScoreManager_CheckWinCondition_ShouldNotWinWhenScoreIsLessThan10() {
        pongScoreManager.AddPlayerScore(PONG_WIN_SCORE - 1);
        Assert.AreEqual(ScoreManager.WIN_CONDITION_NOT_MET, pongScoreManager.CheckWinCondition());
    }

    [Test]
    public void PongScoreManager_AddScore_ShouldNotExceedWinScore() {
        for (int i = 0; i < 15; i++) pongScoreManager.AddPlayerScore(1);
        Assert.AreEqual(10, pongScoreManager.GetPlayerScore()); 
    }

    // MinesweeperScoreManager Tests
    [Test]
    public void MinesweeperScoreManager_InitialScore_ShouldBeZero() {
        Assert.AreEqual(0, minesweeperScoreManager.GetPlayerScore());
    }

    [Test]
    public void MinesweeperScoreManager_AddScore_IncreasesScoreByOne() {
        minesweeperScoreManager.AddPlayerScore(1);
        Assert.AreEqual(1, minesweeperScoreManager.GetPlayerScore());
    }

    [Test]
    public void MinesweeperScoreManager_SetPlayerHitMine_ShouldSetGameOver() {
        minesweeperScoreManager.SetPlayerHitMine();
        Assert.AreEqual(MinesweeperScoreManager.PLAYER_HIT_MINE, minesweeperScoreManager.CheckWinCondition());
    }

    [Test]
    public void MinesweeperScoreManager_CheckWinCondition_ShouldWinWhenScoreReachesThreshold() {
        minesweeperScoreManager.AddPlayerScore(MINESWEEPER_WIN_SCORE - MINESWEEPER_NUM_MINES);
        Assert.AreEqual(ScoreManager.PLAYER_WON, minesweeperScoreManager.CheckWinCondition());
    }

    [Test]
    public void MinesweeperScoreManager_CheckWinCondition_ShouldNotWinWhenBelowThreshold() {
        minesweeperScoreManager.AddPlayerScore(MINESWEEPER_WIN_SCORE-1);
        Assert.AreEqual(ScoreManager.WIN_CONDITION_NOT_MET, minesweeperScoreManager.CheckWinCondition());
    }

    // MathScoreManager Tests
    [Test]
    public void MathScoreManager_InitialScore_ShouldBeZero() {
        Assert.AreEqual(0, mathScoreManager.GetPlayerScore());
    }

    [Test]
    public void MathScoreManager_AddScore_IncreasesScoreByFive() {
        mathScoreManager.AddPlayerScore(5);
        Assert.AreEqual(5, mathScoreManager.GetPlayerScore());
    }

    [Test]
    public void MathScoreManager_CheckWinCondition_ShouldWinWhenScoreReachesThreshold() {
        mathScoreManager.AddPlayerScore(MATH_WIN_SCORE);
        Assert.AreEqual(ScoreManager.PLAYER_WON, mathScoreManager.CheckWinCondition());
    }

    [Test]
    public void MathScoreManager_CheckWinCondition_ShouldNotWinWhenBelowThreshold() {
        mathScoreManager.AddPlayerScore(MATH_WIN_SCORE - 1);
        Assert.AreEqual(ScoreManager.WIN_CONDITION_NOT_MET, mathScoreManager.CheckWinCondition());
    }
}
