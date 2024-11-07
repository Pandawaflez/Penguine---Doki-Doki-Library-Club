using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject submitButton;  //assign inspector
    public GameObject inputField;      //assign inspector

    private UIElement _submitButtonElement;  //submitButtonElement is of type superclass
    private InputName _inputFieldElement;

    private void Start()
    {
        // Initialize the InputName and UISubmitButton instances
        _inputFieldElement = new InputName(inputField);
        _submitButtonElement = new UISubmitButton(submitButton, _inputFieldElement);  //dynamic binding
    }

    public void OnSubmitButtonClicked()
    {
        // Call the OnSubmitButtonClick method on UISubmitButton instance
        _submitButtonElement.v_onClick();
    }

    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit(); // Quit the application
    }
}
