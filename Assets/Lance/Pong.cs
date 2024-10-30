using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// this should be the game manager for the pong level. lets hope
public class Pong : MiniGameLevel
{
    private ScoreManager scoreManager;
    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI aiScoreText;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] Ball ball;
    [SerializeField] PlayerPaddle playerPaddle;
    [SerializeField] AIPaddle aiPaddle;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject middleLine;

    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        // scoreManager = new PongScoreManager(3);
        scoreManager = ScoreManagerFactory.CreateScoreManager("Pong", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // update the score display in the pong game
    private void UpdateScore() {
        playerScoreText.text = scoreManager.GetPlayerScore().ToString();
        aiScoreText.text = (scoreManager as PongScoreManager)?.GetAIScore().ToString();
    }

    // add one to the player score
    public void addPlayerScore() {
        scoreManager.AddPlayerScore();
        UpdateScore();
        CheckGameOver();
    }

    // add one to the ai score
    public void addAIScore() {
        (scoreManager as PongScoreManager)?.AddAIScore();
        UpdateScore();
        CheckGameOver();
    }

    // dynamic binding to check win condition for pong game
    public bool CheckGameOver() {
        int checkWinner = scoreManager.CheckWinCondition();
        
        // player wins no matter what in bc mode
        if (MainPlayer.IsBCMode()) {
            checkWinner = ScoreManager.PLAYER_WON;
        }

        if (checkWinner == ScoreManager.PLAYER_WON) {
            Debug.Log("Player Won!");
            winnerText.text = "You Won!";
            EndGame();
        } else if (checkWinner == PongScoreManager.AI_WON) {
            Debug.Log("AI Won :(");
            winnerText.text = "You Lost!";
            EndGame();
        } else {
            isGameOver = false;
            ResetRound();
        }

        return isGameOver;
    }

    private void ResetRound() {
        Debug.Log("Resetting Round...");
        aiPaddle.ResetPaddle();
        playerPaddle.ResetPaddle();
        ball.ResetBall();

        ball.gameObject.SetActive(true);
        aiPaddle.gameObject.SetActive(true);
        playerPaddle.gameObject.SetActive(true);

        Time.timeScale = 1;
    }

    // dynamic binding to end the Pong game
    public override void EndGame() {
        Debug.Log("Ending the Game...");
        Time.timeScale = 0;
        isGameOver = true;

        ball.gameObject.SetActive(false);
        aiPaddle.gameObject.SetActive(false);
        playerPaddle.gameObject.SetActive(false);
        middleLine.SetActive(false);

        gameOverScreen.SetActive(true); 
    }
}
