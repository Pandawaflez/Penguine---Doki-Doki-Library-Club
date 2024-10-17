using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISubmitButton : UIElement
{
    private readonly InputName inputField;  // Reference to the input field

    public UISubmitButton(GameObject element, InputName inputField) : base(element)     //Pass the GameObject to the base classd
    {
        this.inputField = inputField;
    }

    public override void onClick()
    {
        // Get the player's name from the input field
        string playerName = inputField.GetInputText();

        // Debug.Log($"Player Name Entered: '{playerName}'");  // Log the input value


        if (!string.IsNullOrEmpty(playerName))
        {
            MainPlayer.setPlayerName(playerName);
            SceneManager.LoadScene("Overworld");
        }
        else
        {
            Debug.Log("Please enter a valid name.");
        }

        playerName = MainPlayer.getPlayerName();
        Debug.Log($"Player stored name: '{playerName}'");
    }
}
