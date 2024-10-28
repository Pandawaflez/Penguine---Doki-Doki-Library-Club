using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElementHandler : MonoBehaviour
{
    private static readonly Lazy<UIElementHandler> _instance =
        new Lazy<UIElementHandler>(() => FindObjectOfType<UIElementHandler>()); //lazy initialization, thread safety

    public static UIElementHandler UIGod => _instance.Value;

    public Button quitButton; //Reference to the Quit button
    public GameObject endGamePanel; //Reference to the end game panel (UI)


    private void Awake()
    {
        //Implement Singleton pattern
        if (_instance.IsValueCreated && _instance.Value != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);  // Make this instance persistent across scenes
        }
    }

    private void Start()
    {
        // Set up the quit button
        quitButton.onClick.AddListener(QuitGame);
        quitButton.gameObject.SetActive(true); //button stays active on screen till game start
        endGamePanel.SetActive(false); //ensure the end game panel is hidden initially
    }

    private void Update()
    {
        UICheckInput();
    }

    // Check for UI User input
    public void UICheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("*****Overlay Toggle*****");
        }
    }

    // Function to quit the game
    private void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit(); // Quit the application
    }

    //handle end of game scenario (global access point)
    public void EndGame(bool isWin)
    {
        endGamePanel.SetActive(true); //Show the end game panel

        // // Update panel text based on win/loss
        // Text panelText = endGamePanel.GetComponentInChildren<Text>();
        // if (panelText != null)
        // {
        //     panelText.text = isWin ? "You Win!" : "You Lose!";
        // }

        Debug.Log(isWin ? "Game Over: You Win!" : "Game Over: You Lose!");
    }
}
