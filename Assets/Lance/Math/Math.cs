using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Math : MiniGameLevel
{
    private ScoreManager _scoreManager;
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
    private float _timeRemaining;
    private int _correctAnswer;
    private const int _SCORE_TO_WIN = 10;
    private const int _TIME_LIMIT = 25;

    // Start is called before the first frame update
    public void Start()
    {
        // BC Mode score to win is -1000
        // _scoreManager = new MathScoreManager((MainPlayer.IsBCMode()) ? -1000 : _SCORE_TO_WIN);
        _scoreManager = ScoreManagerFactory.CreateScoreManager( "Math", (MainPlayer.IsBCMode()) ? -1000 : _SCORE_TO_WIN);
        p_timeLimit = _TIME_LIMIT;
        _timeRemaining = p_timeLimit;
        leftAnswer.onClick.AddListener(() => CheckAnswer(leftAnswer));
        rightAnswer.onClick.AddListener(() => CheckAnswer(rightAnswer));
        gameOverScreen.SetActive(false);
        GenerateNewQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if (!p_isGameOver) {
            _timeRemaining -= Time.deltaTime;
            UpdateTimerText();
            CheckGameOver();
        }
    }

    private void UpdateTimerText() {
        timerText.text = Mathf.Ceil(_timeRemaining).ToString();
    }

    private void UpdateScoreText() {
        scoreText.text = "Score: " + _scoreManager.GetPlayerScore().ToString();
    }

    private void CheckGameOver() {
        if (_timeRemaining <= 0f) {
            if ((_scoreManager.VCheckWinCondition() == ScoreManager.PLAYER_WON) || (MainPlayer.IsBCMode())) {
                winnerText.text = "You Won!";
                MainPlayer.SetMiniGameStatus(1);
            } else {
                winnerText.text = "You Lost";
                MainPlayer.SetMiniGameStatus(0);
            }
            VEndGame();
        }
    }

    private void GenerateNewQuestion() {
        int num1 = Random.Range(1,10);
        int num2 = Random.Range(1,10);
        int randOperator = Random.Range(1,4);
        int incorrectAnswer = Random.Range(1,10);
        if (randOperator == 1) {
            _correctAnswer = num1 + num2;
            op.text = "+";
        } else if (randOperator == 2) {
            _correctAnswer = num1 - num2;
            op.text = "-";
        } else {
            _correctAnswer = num1 * num2;
            op.text = "*";
        }

        leftNum.text = num1.ToString();
        rightNum.text = num2.ToString();

        incorrectAnswer = _correctAnswer + Random.Range(-5,6);

        while (incorrectAnswer == _correctAnswer) {
            incorrectAnswer = _correctAnswer + Random.Range(-5,6);
        }

        if (Random.Range(0, 2) == 0) {
            leftAnswer.GetComponentInChildren<TextMeshProUGUI>().text = _correctAnswer.ToString();
            rightAnswer.GetComponentInChildren<TextMeshProUGUI>().text = incorrectAnswer.ToString();
        } else {
            rightAnswer.GetComponentInChildren<TextMeshProUGUI>().text = _correctAnswer.ToString();
            leftAnswer.GetComponentInChildren<TextMeshProUGUI>().text = incorrectAnswer.ToString();
        }
    }

    private void CheckAnswer(Button selectedButton) {
        int selectedAnswer = int.Parse(selectedButton.GetComponentInChildren<TextMeshProUGUI>().text);
        
        // BC Mode always gets correct answer
        if (MainPlayer.IsBCMode()) {
            selectedAnswer = _correctAnswer;
        }
        if (selectedAnswer == _correctAnswer) {
            _scoreManager.VAddPlayerScore(1);
        } else {
            _scoreManager.VAddPlayerScore(-1);
        }
        GenerateNewQuestion();
        UpdateScoreText();
    }

    public override void VEndGame() {
        Debug.Log("Ending the game...");
        // Time.timeScale = 0;
        p_isGameOver = true;
        mathGameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    // getter function for testing
    public float GetTimeRemaining() {
        return _timeRemaining;
    }

    // setter function for testing
    public void SetTimeRemaining(float time) {
        _timeRemaining = time;
    }

    public bool GetGameOverScreenShowing() {
        return gameOverScreen.activeSelf;
    }
}
