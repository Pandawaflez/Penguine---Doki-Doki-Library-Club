using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameLevel : MonoBehaviour
{
    protected bool isGameOver = false; // keep track of state of game
    protected int timeLimit = 60; // time limit in seconds for each mini game
    protected bool isRegularMode = true; // default game to being played in regular mode instead of BC mode
    protected int affectionReward = 10; // default number of affection points given for mini game
    protected string previousScene; // previous scene to return back to after mini game ends

    // update the affection points reward for mini game
    public void ChangeAffectionPointReward(int reward) {
        affectionReward = reward;
    }

    // set the game over boolean 
    public void SetGameOver(bool state) {
        isGameOver = state;
    }

    // set the difficulty mode for the level. True is regular mode, false is BC mode
    public void SetDifficultyMode(bool difficulty) {
        isRegularMode = difficulty;
    }

    // check if the game is over or not
    public bool CheckWinCondition() {
        return isGameOver;
    }

    public void StartMiniGame(string prevScene) {
        previousScene = prevScene;


    }

    // end the mini game
    public virtual void EndGame() {
        Debug.Log("Ending the Game");
        // Time.timeScale = 0f;
        // more to come? Maybe, idk. Carson will tell me. He tells me all truths of the universe.
        SceneManager.LoadScene(previousScene);
    }
}
