using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public abstract class Peanuts : MonoBehaviour
{
    private int _affectionPoints;

    //dialoguetrackers
    protected int p_dialogueNum = 0;
    protected int p_responseNum = 0;

    //user chose to play a game with their character. saves current scene w/ character and goes to game
    protected void initiateMiniGame(string game)
    {
        SceneChanger.saveScene();
        SceneManager.LoadScene(game);
    }

    //getters and setters
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
    
    //update affection is essentally a setter. adds (or subtracts) additional affection points
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

    //the actual setter for affection points. used when a character starts up
    protected void loadAffection(int totalPoints)
    {
        _affectionPoints = totalPoints;
    }

    //the function that decides what to do when a response is hit. defined in each character class
    protected abstract void v_toNextDialogue();

    //sets responseNum so and calls toNextDialogue to respond to user's response. also 'unselects' button
    public void hitResponse1()
    {
        p_responseNum = 1;
        Debug.Log("they hit it boss");

        // Run logic, then clear selection to avoid sticking
        v_toNextDialogue();
        StartCoroutine(DeselectButton());
    }

    // Button 2 OnClick. same functionality as hitResponse1
    public void hitResponse2()
    {
        p_responseNum = 2;
        Debug.Log("punch 2");
        // Run logic, then clear selection
        v_toNextDialogue();
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
