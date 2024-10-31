using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject submitButton;  //assign inspector
    public GameObject inputField;      //assign inspector

    private UIElement submitButtonElement;  //submitButtonElement is of type superclass
    private InputName inputFieldElement;

    private void Start()
    {
        // Initialize the InputName and UISubmitButton instances
        inputFieldElement = new InputName(inputField);
        submitButtonElement = new UISubmitButton(submitButton, inputFieldElement);  //dynamic binding
    }

    public void OnSubmitButtonClicked()
    {
        // Call the OnSubmitButtonClick method on UISubmitButton instance
        submitButtonElement.onClick();
    }

    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit(); // Quit the application
    }
}
