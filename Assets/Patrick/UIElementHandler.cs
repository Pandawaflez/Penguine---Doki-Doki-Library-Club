using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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
    private string[] characterNames = { "Charlie", "Lucy", "Snoopy", "Schroeder" };

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
        quitButton.gameObject.SetActive(false); //button stays deactivated until user presses tab

        overlayUI.Hide();   //hide overlay on start

        endGamePanel.SetActive(false); //ensure the end game panel is hidden initially
    }

    private void Update()
    {
        UICheckInput();

        overlayUI.UpdateCharacterUI("Charlie", PeanutsDB.CharlieAffectionPts);
        overlayUI.UpdateCharacterUI("Lucy", PeanutsDB.LucyAffectionPts);
        overlayUI.UpdateCharacterUI("Snoopy", PeanutsDB.SnoopyAffectionPts);
        overlayUI.UpdateCharacterUI("Schroeder", PeanutsDB.SchroederAffectionPts);
        // overlayUI.UpdateCharacterUI("Sonic", affectionManager.GetShadowAffectionPoints());
        // overlayUI.UpdateCharacterUI("Shadow", affectionManager.GetSonicAffectionPoints());



        
        if(Input.GetKeyDown(KeyCode.Space)){
            overlayUI.UpdateCharacterUI("Charlie", 80);
        }
    }


    // Check for UI User input
    public void UICheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("tab pressed");
            if(!overlayUI.Visible()){
                overlayUI.Show();
                quitButton.gameObject.SetActive(true);
            }
            else{
                overlayUI.Hide();
                quitButton.gameObject.SetActive(false);
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
