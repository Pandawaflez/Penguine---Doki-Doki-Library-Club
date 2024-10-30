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
    public GameObject overlayPanel; //panel for overlay
    public Sprite[] characterImages;    //inspector?
    private string[] characterNames = { "Snoopy", "Charlie", "Sonic", "Shadow", "Daphne", "Scooby", "Shaggy"};

    private UIOverlay overlayUI;


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
            overlayUI = new UIOverlay(overlayPanel, characterImages, characterNames);
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

        overlayUI.UpdateCharacterUI("Charlie", PeanutsDB.CharlieAffectionPts);
    }


    // Check for UI User input
    public void UICheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(overlayUI.Visible()){
                overlayUI.Show();
                overlayPanel.SetActive(true);
                quitButton.gameObject.SetActive(false);
            }
            else{
                overlayUI.Hide();
                overlayPanel.SetActive(false);
                quitButton.gameObject.SetActive(true);
            }
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
