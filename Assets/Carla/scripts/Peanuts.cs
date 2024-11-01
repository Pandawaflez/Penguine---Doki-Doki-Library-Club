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
    protected int p_dialogueNum = 0;
    protected int p_responseNum = 0;
    protected void initiateMiniGame(string game){
        //SceneManager.LoadScene("Pong", LoadSceneMode.Additive);
        SceneChanger.saveScene();
        SceneManager.LoadScene(game);
        //dialogueNum = 8;
        
    }

    public int getResponseNum(){
        return p_responseNum;
    }
    public int getDialogueNum(){
        return p_dialogueNum;
    }

    //affection points
    private int _affectionPoints;

    public int getAffectionPoints(){
        return _affectionPoints;
    }
    public void updateAffection(int newPoints){
        if (MainPlayer.IsBCMode()){
            if (newPoints <0) newPoints *= -1;
            _affectionPoints += 2*newPoints;
        }
        else{
            _affectionPoints += newPoints;
        }
    }

    protected void loadAffection(int totalPoints){
        _affectionPoints = totalPoints;
    }

    //minigame

    //can have start & update in parent class??
    //then just update all 4 char affection&dialogue every time?

    
}
