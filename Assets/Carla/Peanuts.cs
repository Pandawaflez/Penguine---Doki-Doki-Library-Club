using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Peanuts : MonoBehaviour
{
    //graphics
    //sfx

    //dialoguetracker
    protected int dialogueNum = 0;
    protected int responseNum = 0;
     protected void initiateMiniGame(string game){
        //SceneManager.LoadScene("Pong", LoadSceneMode.Additive);
        SceneChanger.saveScene();
        SceneManager.LoadScene(game);

        dialogueNum = 8;
    }

    //affection points
    private int affectionPoints;

    public int getAffectionPoints(){
        return affectionPoints;
    }
    public void updateAffection(int newPoints){
        affectionPoints += newPoints;
    }

    protected void loadAffection(int totalPoints){
        affectionPoints = totalPoints;
    }

    //minigame

    
}
