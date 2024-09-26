using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public abstract class Peanuts : MonoBehaviour
{
    //graphics
    //sfx

    //dialogues
    /*
    private string dialogue1;
    private string dialogue2;
    private string dialogue3;
    private string dialogue4;
    protected string dialogue5 = "hi";
    */

    //dialogue responses

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
