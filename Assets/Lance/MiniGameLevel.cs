using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameLevel : MonoBehaviour
{
    protected bool p_isGameOver = false; // keep track of state of game
    protected int p_timeLimit = 60; // time limit in seconds for each mini game
    protected int p_affectionReward = 10; // default number of affection points given for mini game

    // update the affection points reward for mini game
    public void ChangeAffectionPointReward(int reward) {
        p_affectionReward = reward;
    }

    // set the game over boolean 
    public void SetGameOver(bool state) {
        p_isGameOver = state;
    }

    // check if the game is over or not
    public bool CheckWinCondition() {
        return p_isGameOver;
    }

    // handle the continue button click at the end of the game
    public void HandleContinueButtonClick() {
        Debug.Log("Loading Level1");
        SceneChanger.Continue();
    }

    // end the mini game
    public virtual void VEndGame() {
        Debug.Log("Ending the Game");
        // Time.timeScale = 0f;
    }

    // return isGameOver boolean
    public bool GetIsGameOver() {
        return p_isGameOver;
    }
}
