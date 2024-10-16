using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Math : MiniGameLevel
{
    private MathScoreManager scoreManager;
    [SerializeField] TextMeshProUGUI leftNum;
    [SerializeField] TextMeshProUGUI rightNum;
    [SerializeField] TextMeshProUGUI op;
    [SerializeField] Button leftAnswer ;
    [SerializeField] Button rightAnswer;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject mathGameScreen;
    private float timeRemaining;
    private int correctAnswer;
    private const int SCORE_TO_WIN = 10;

    // Start is called before the first frame update
    public void Start()
    {
        scoreManager = new MathScoreManager(SCORE_TO_WIN);
        timeLimit = 15;
        timeRemaining = timeLimit;
        leftAnswer.onClick.AddListener(() => CheckAnswer(leftAnswer));
        rightAnswer.onClick.AddListener(() => CheckAnswer(rightAnswer));
        gameOverScreen.SetActive(false);
        GenerateNewQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
            CheckGameOver();
        }
    }

    private void UpdateTimerText() {
        timerText.text = Mathf.Ceil(timeRemaining).ToString();
    }

    private void UpdateScoreText() {
        scoreText.text = "Score: " + scoreManager.GetPlayerScore().ToString();
    }

    private void CheckGameOver() {
        if (timeRemaining <= 0f) {
            if (scoreManager.CheckWinCondition() == ScoreManager.PLAYER_WON) {
                winnerText.text = "You Won!";
            } else {
                winnerText.text = "You Lost";
            }
            EndGame();
        }
    }

    private void GenerateNewQuestion() {
        int num1 = Random.Range(1,10);
        int num2 = Random.Range(1,10);
        int randOperator = Random.Range(1,4);
        int incorrectAnswer = Random.Range(1,10);
        if (randOperator == 1) {
            correctAnswer = num1 + num2;
            op.text = "+";
        } else if (randOperator == 2) {
            correctAnswer = num1 - num2;
            op.text = "-";
        } else {
            correctAnswer = num1 * num2;
            op.text = "*";
        }

        leftNum.text = num1.ToString();
        rightNum.text = num2.ToString();

        incorrectAnswer = correctAnswer + Random.Range(-5,6);

        while (incorrectAnswer == correctAnswer) {
            incorrectAnswer = correctAnswer + Random.Range(-5,6);
        }

        if (Random.Range(0, 2) == 0) {
            leftAnswer.GetComponentInChildren<TextMeshProUGUI>().text = correctAnswer.ToString();
            rightAnswer.GetComponentInChildren<TextMeshProUGUI>().text = incorrectAnswer.ToString();
        } else {
            rightAnswer.GetComponentInChildren<TextMeshProUGUI>().text = correctAnswer.ToString();
            leftAnswer.GetComponentInChildren<TextMeshProUGUI>().text = incorrectAnswer.ToString();
        }
    }

    private void CheckAnswer(Button selectedButton) {
        int selectedAnswer = int.Parse(selectedButton.GetComponentInChildren<TextMeshProUGUI>().text);
        if (selectedAnswer == correctAnswer) {
            scoreManager.AddPlayerScore(1);
        } else {
            scoreManager.AddPlayerScore(-1);
        }
        GenerateNewQuestion();
        UpdateScoreText();
    }

    public override void EndGame() {
        Debug.Log("Ending the game...");
        // Time.timeScale = 0;
        isGameOver = true;
        mathGameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    // getter function for testing
    public float GetTimeRemaining() {
        return timeRemaining;
    }

    // setter function for testing
    public void SetTimeRemaining(float time) {
        timeRemaining = time;
    }

    public bool GetGameOverScreenShowing() {
        return gameOverScreen.activeSelf;
    }
}
