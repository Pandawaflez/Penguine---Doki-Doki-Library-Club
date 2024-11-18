using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
//using System.Random;


public class RPS : MiniGameLevel
{
    // private ScoreManager _scoreManager;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] GameObject rpsGameScreen;

    public int compMove; //0=rock, 1=paper, 2=scissors
    public int didWin = -1; // -1 means they haven't won or lost yet

    // Start is called before the first frame update
    void Start()
    {
        compMove = Random.Range(0,3);
        //Debug.Log(compMove);
        Debug.Log("play loser");
        gameOverScreen.SetActive(false);
        rpsGameScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickRock(){
        if (compMove == 0){
            Start();
        } else if (compMove == 1){
            didWin = 0; // they lost
            winnerText.text = "You lost!";
            VEndGame();
        } else {
            didWin = 1; // they won
            winnerText.text = "You won!";
            VEndGame();
        }
    }

    public void ClickPaper(){
        if (compMove == 0){
            didWin = 1; // they won
            VEndGame();
        } else if (compMove == 1){
            Start();
        } else {
            didWin = 0; // they lost
            VEndGame();
        }
    }

    public void ClickScissors(){
        if (compMove == 0){
            didWin = 0; // they lost
            VEndGame();
        } else if (compMove == 1){
            didWin = 1; // they won
            VEndGame();
        } else {
            Start();
        }
    }

    public override void VEndGame() {
        Time.timeScale = 0f;
        p_isGameOver = true;

        if (didWin == -1) {
            // player has not won or lost yet
            return;
        } else if (didWin == 1 || MainPlayer.IsBCMode()) {
            MainPlayer.SetMiniGameStatus(1); // epic
        } else if (didWin == 0){
            // player lost - not epic
            MainPlayer.SetMiniGameStatus(0); // not epic
        } else {
            Debug.Log("What happened?"); // this shouldn't happen
        }

        rpsGameScreen.SetActive(false);
        gameOverScreen.SetActive(true); // continue screen
    }
}
