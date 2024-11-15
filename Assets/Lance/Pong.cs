using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Pong : MiniGameLevel
{
    // Definition for the scoreManager
    private ScoreManager _scoreManager;
    public static Vector2 s_bottomLeft;
    public static Vector2 s_topRight;
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI aiScoreText;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] Ball ball;
    [SerializeField] PlayerPaddle playerPaddle;
    [SerializeField] AIPaddle aiPaddle;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject middleLine;
    [SerializeField] GameObject mobileMovement;

    private bool _isMobile = false;
    [SerializeField] byte PONG_SCORE_TO_WIN = 3;

    private BackgroundMusic backgroundMusic; //AUDIO
    private AudioSource backgroundAudioSource;

    void Start()
    {
        s_bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        s_topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _scoreManager = ScoreManagerFactory.CreateScoreManager("Pong", PONG_SCORE_TO_WIN);
        
        /* This is only for the Screenshot for the prelab showing how I would get the static and dynamic type. I use a Factory pattern as above */
        // // Static Type
        // _scoreManager = new ScoreManager(1);

        // Dynamic Type
        // _scoreManager = new PongScoreManager(1);

        if (Application.platform == RuntimePlatform.Android && Application.platform == RuntimePlatform.IPhonePlayer) {
            _isMobile = true;

            mobileMovement.SetActive(true);
        }

        // AUDIO SETUP- Get the AudioSource for background music
        // Step 1: Load the background music clip from Resources
        AudioClip backgroundClip = Resources.Load<AudioClip>("Owen/Games/Polka");

        if (backgroundClip == null)
        {
            Debug.LogError("Background music not found in Resources!");
            return;
        }

        // Step 2: Get or add an AudioSource component
        backgroundAudioSource = GetComponent<AudioSource>();
        if (backgroundAudioSource == null)
        {
            backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        }

        // Step 3: Create a new BackgroundMusic instance with the loaded AudioClip
        backgroundMusic = new BackgroundMusic(
            id: "BackgroundMusicID",
            clip: backgroundClip,
            characterID: "Background",
            backgroundID: "Pong",
            source: backgroundAudioSource
        );

        // Step 4: Loop the music if needed
        backgroundMusic.Loop();

    }

    // update the score display in the pong game
    private void UpdateScore() {
        playerScoreText.text = _scoreManager.GetPlayerScore().ToString();
        aiScoreText.text = (_scoreManager as PongScoreManager)?.GetAIScore().ToString();
    }

    // add one to the player score
    public void addPlayerScore() {
        _scoreManager.VAddPlayerScore();
        UpdateScore();
        CheckGameOver();
    }

    // add one to the ai score
    public void addAIScore() {
        (_scoreManager as PongScoreManager)?.AddAIScore();
        UpdateScore();
        CheckGameOver();
    }

    // dynamic binding to check win condition for pong game
    public bool CheckGameOver() {
        int checkWinner = _scoreManager.VCheckWinCondition();
        
        // player wins no matter what in bc mode
        if (MainPlayer.IsBCMode()) {
            checkWinner = ScoreManager.PLAYER_WON;
        }

        if (checkWinner == ScoreManager.PLAYER_WON) {
            Debug.Log("Player Won!");
            winnerText.text = "You Won!";
            MainPlayer.SetMiniGameStatus(1);
            VEndGame();
        } else if (checkWinner == PongScoreManager.AI_WON) {
            Debug.Log("AI Won :(");
            winnerText.text = "You Lost!";
            MainPlayer.SetMiniGameStatus(0);
            VEndGame();
        } else {
            p_isGameOver = false;
            ResetRound();
        }

        return p_isGameOver;
    }

    public void ResetRound() {
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
    public override void VEndGame() {
        Debug.Log("Ending the Game...");
        Time.timeScale = 0;
        p_isGameOver = true;

        // AUDIO -Fade out the background music before ending the game
        backgroundMusic.Stop();

        ball.gameObject.SetActive(false);
        aiPaddle.gameObject.SetActive(false);
        playerPaddle.gameObject.SetActive(false);
        middleLine.SetActive(false);

        if (_isMobile) {
            mobileMovement.SetActive(false);
        }

        gameOverScreen.SetActive(true); 
    }
}
