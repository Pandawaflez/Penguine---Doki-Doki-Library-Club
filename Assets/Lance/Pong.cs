using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// this should be the game manager for the pong level. lets hope
public class Pong : MiniGameLevel
{
    // score for player and AI
    private int playerScore = 0; 
    private int aiScore = 0;
    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // add one to the player score
    public void addPlayerScore() {
        playerScore += 1;
    }

    // add one to the ai score
    public void addAIScore() {
        aiScore += 1;
    }
}
