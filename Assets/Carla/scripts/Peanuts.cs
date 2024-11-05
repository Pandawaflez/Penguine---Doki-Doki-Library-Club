using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public abstract class Peanuts : MonoBehaviour
{
    //graphics
    //sfx
    //affection points
    private int _affectionPoints;

    //dialoguetracker
    protected int p_dialogueNum = 0;
    protected int p_responseNum = 0;

    protected void initiateMiniGame(string game)
    {
        //SceneManager.LoadScene("Pong", LoadSceneMode.Additive);
        SceneChanger.saveScene();
        SceneManager.LoadScene(game);
        //dialogueNum = 8;
        
    }

    public int getResponseNum()
    {
        return p_responseNum;
    }
    public int getDialogueNum()
    {
        return p_dialogueNum;
    }
    //for testing
    public void setDialogueNum(int pts)
    {
        p_dialogueNum = pts;
    }

    public int getAffectionPoints()
    {
        return _affectionPoints;
    }
    
    public void updateAffection(int newPoints)
    {
        //in BC mode, affection points cannot go down and go up at 2x the rate
        if (MainPlayer.IsBCMode()){
            if (newPoints <0) newPoints = 0;  //ensure points will not get taken away
            _affectionPoints += 2*newPoints;
        }
        else{
            _affectionPoints += newPoints;
        }
    }

    protected void loadAffection(int totalPoints)
    {
        _affectionPoints = totalPoints;
    }

    protected abstract void toNextDialogue();

    public void hitResponse1()
    {
        p_responseNum = 1;
        Debug.Log("they hit it boss");

        // Run logic, then clear selection to avoid sticking
        toNextDialogue();
        StartCoroutine(DeselectButton());
    }

    // Button 2 OnClick
    public void hitResponse2()
    {
        p_responseNum = 2;
        Debug.Log("punch 2");
        // Run logic, then clear selection
        toNextDialogue();
        StartCoroutine(DeselectButton());
    }

    // Coroutine to wait a frame and clear selection
    private IEnumerator DeselectButton()
    {
        yield return null;  // Wait one frame to ensure UI updates

        // Deselect the current selected UI element
        EventSystem.current.SetSelectedGameObject(null);
    }
    
}
