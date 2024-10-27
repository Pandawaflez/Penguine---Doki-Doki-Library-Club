using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElementHandler : MonoBehaviour
{
    private static readonly Lazy<UIElementHandler> _instance =
        new Lazy<UIElementHandler>(() => FindObjectOfType<UIElementHandler>());

    public static UIElementHandler UIGod => _instance.Value;

        public Button quitButton; //Reference to the Quit button


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
}
