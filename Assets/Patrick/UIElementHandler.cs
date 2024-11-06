using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using CandyCoded.HapticFeedback;

public class UIElementHandler : MonoBehaviour
{
    private static readonly Lazy<UIElementHandler> _instance =
        new Lazy<UIElementHandler>(() => FindObjectOfType<UIElementHandler>()); //lazy initialization, thread safety

    public static UIElementHandler UIGod => _instance.Value;

    public Button overlayButton;    //for mobile implementation

    public Button quitButton; //Reference to the Quit button
    public GameObject endGamePanel; //Reference to the end game panel (UI)
    public GameObject overlayPanel; //panel for overlay
    public Sprite[] characterImages;    //inspector?
    private string[] _characterNames = { "Charlie", "Lucy", "Snoopy", "Schroeder", "Sonic", "Shadow", };

    private UIOverlay _overlayUI;

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
            _overlayUI = new UIOverlay(overlayPanel, characterImages, _characterNames);
        }
    }

    private void Start()
    {
        // Set up the quit button
        quitButton.onClick.AddListener(QuitGame);
        quitButton.gameObject.SetActive(false); //button stays deactivated until user presses tab

        overlayButton.onClick.AddListener(ShowOverlay);
        overlayButton.gameObject.SetActive(false); //hide this button initially

        _overlayUI.Hide();   //hide overlay on start

        endGamePanel.SetActive(false); //ensure the end game panel is hidden initially
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName != "Menu"){    //don't allow overlay to come up during menu scene.
            UICheckInput();
            if(Application.isMobilePlatform || UnityEngine.Device.Application.isMobilePlatform){               //if game is in mobile, show button for overlay
                overlayButton.gameObject.SetActive(true);
            }
        };

        _overlayUI.UpdateCharacterUI("Charlie", PeanutsDB.CharlieAffectionPts);
        // overlayUI.UpdateCharacterUI("Charlie", 100);

        _overlayUI.UpdateCharacterUI("Lucy", PeanutsDB.LucyAffectionPts);
        _overlayUI.UpdateCharacterUI("Snoopy", PeanutsDB.SnoopyAffectionPts);
        _overlayUI.UpdateCharacterUI("Schroeder", PeanutsDB.SchroederAffectionPts);
        _overlayUI.UpdateCharacterUI("Sonic", AffectionManager.GetSonicAffectionPoints());
        _overlayUI.UpdateCharacterUI("Shadow", AffectionManager.GetShadowAffectionPoints());

        if(Input.GetKeyDown(KeyCode.DownArrow)){
            UIGod.EndGame(true, "Charlie");
        }

    }

    //mobile overlay button function
    public void ShowOverlay(){
        if(!_overlayUI.Visible()){
            _overlayUI.Show();
            HapticFeedback.LightFeedback();         //some haptic feedback
            quitButton.gameObject.SetActive(true);
        }
        else{
            _overlayUI.Hide();
            quitButton.gameObject.SetActive(false);
        }
    }

    // Check for UI User input
    public void UICheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("tab pressed");
            if(!_overlayUI.Visible()){
                _overlayUI.Show();
                quitButton.gameObject.SetActive(true);
            }
            else{
                _overlayUI.Hide();
                quitButton.gameObject.SetActive(false);
            }
        }
    }

    //simulates the same menu scene checking as implemented for testing
    public void ShowOverlayTest(){
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName != "Menu"){
            ShowOverlay();
        }
    }

    // Function to quit the game
    private void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit(); // Quit the application
    }

    //handle end of game scenario (global access point)
    public void EndGame(bool isWin, string character)
    {
        if(Application.isMobilePlatform){
            HapticFeedback.MediumFeedback();    //vibrate on end game
        }
        
        endGamePanel.SetActive(isWin); // Show the end game panel

        if(isWin){
            // Get the Text component from the end game panel
            TextMeshProUGUI panelText = endGamePanel.GetComponentInChildren<TextMeshProUGUI>();
            if (panelText != null)
            {
               panelText.text = $"Congratulations! You and {character} are now dating!";
            }
        }

        Debug.Log(isWin ? $"Game Over: You Win with {character}!" : "Game Over: You Lose!");
    }
}
