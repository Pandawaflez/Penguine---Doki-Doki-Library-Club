using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject submitButton;  // Assign via Inspector
    public GameObject inputField;    // Assign via Inspector

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
    public void onQuitButton(){
        Application.Quit();
    }
}
