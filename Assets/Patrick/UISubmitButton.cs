using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISubmitButton : UIElement
{
    private readonly InputName _inputField;  // Reference to the input field

    public UISubmitButton(GameObject element, InputName inputField) : base(element)     //Pass the GameObject to the base classd
    {
        this._inputField = inputField;
    }

    public override void v_onClick()
    // public void onClick()
    {
        // Get the player's name from the input field
        string playerName = _inputField.GetInputText();

        // Debug.Log($"Player Name Entered: '{playerName}'");  // Log the input value

        Debug.Log($"BCMode: '{MainPlayer.IsBCMode()}");


        if (!string.IsNullOrEmpty(playerName))
        {
            MainPlayer.SetPlayerName(playerName);
            SceneManager.LoadScene("Overworld");
        }
        else
        {
            Debug.Log("Please enter a valid name.");
        }

        //playerName = MainPlayer.getPlayerName();
        //Debug.Log($"Player stored name: '{playerName}'");
    }
}
