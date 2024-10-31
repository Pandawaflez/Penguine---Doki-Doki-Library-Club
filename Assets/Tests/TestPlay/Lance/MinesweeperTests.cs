using NUnit.Framework;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.TestTools;

public class Lance_MinesweeperTests
{
    private GameObject minesweeperPrefab;
    private GameObject minesweeperInstance;
    private Minesweeper minesweeper;

    [SetUp]
    public void Setup()
    {
        minesweeperPrefab = Resources.Load<GameObject>("Lance/MinesweeperGame");
        minesweeperInstance = GameObject.Instantiate(minesweeperPrefab);
        minesweeper = minesweeperInstance.GetComponentInChildren<Minesweeper>();
        
        Assert.IsNotNull(minesweeperPrefab, "Minesweeper prefab is not in Resources folder");
        Assert.IsNotNull(minesweeperInstance, "Minesweeper instance is null");
        Assert.IsNotNull(minesweeper, "Minesweeper is null");
        
        // Set up essential objects like tilePrefab and gameHolder if necessary
        minesweeper.SetTilePrefab(Resources.Load<Transform>("Lance/MinesweeperPrefabs/Tile"));
        minesweeper.SetGameHolder(new GameObject().transform);


        // Use temporary setters for test-specific setup
        GameObject timerTextObject = new GameObject("TimerText");
        TextMeshProUGUI timerText = timerTextObject.AddComponent<TextMeshProUGUI>();
        minesweeper.SetTimerText(timerText);

        GameObject timerScreenObject = new GameObject("TimerScreen");
        minesweeper.SetTimerScreen(timerScreenObject);

        GameObject gameOverScreenObject = new GameObject("GameOverScreen");
        minesweeper.SetGameOverScreen(gameOverScreenObject);

        GameObject winnerTextObject = new GameObject("WinnerText");
        TextMeshProUGUI winnerText = winnerTextObject.AddComponent<TextMeshProUGUI>();
        minesweeper.SetWinnerText(winnerText);
    }

    [UnityTest]
    public IEnumerator TestBoardMinimumSize_ShouldBe1()
    {
        minesweeper.CreateGameBoard(1, 1, 0);
        minesweeper.ResetGameState();
        Assert.AreEqual(1, minesweeper.GetTileCount(), "Board should have only one tile.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator GameEndsAtZero()
    {
        minesweeper.SetTimeRemaining(0.1f);
        yield return new WaitForSeconds(0.2f);
        Assert.IsTrue(minesweeper.GetIsGameOver(), "Game should end when timer reaches zero.");
        Assert.IsTrue(minesweeper.IsGameOverShowing(), "Game over screen should be active.");
    }

    [UnityTest]
    public IEnumerator MaximumMinesOnBoard_ShouldBe25()
    {
        minesweeper.CreateGameBoard(5, 5, 25);
        minesweeper.ResetGameState();
        
        int mineCount = minesweeper.TotalMinesOnBoard();
        Assert.AreEqual(25, mineCount, "All tiles should be mines.");
        
        yield return null;
    }

    [UnityTest]
    public IEnumerator MoreMinesThanTiles_ShouldNotAllowMoreMines()
    {
        minesweeper.CreateGameBoard(5, 5, 30);
        minesweeper.ResetGameState();
        
        int mineCount = minesweeper.TotalMinesOnBoard();
        Assert.AreEqual(25, mineCount, "All tiles should be mines.");
        
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestMaxBoardSize_ShouldBe100()
    {
        minesweeper.CreateGameBoard(11, 11, 5);
        Assert.AreEqual(100, minesweeper.GetTileCount(), "Board should contain 100 tiles.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator SetNegativeTimeRemaining_ShouldEndGame()
    {
        minesweeper.SetTimeRemaining(-10f);
        minesweeper.UpdateTimer();
        Assert.IsTrue(minesweeper.GetIsGameOver());
        yield return null;
    }
}
