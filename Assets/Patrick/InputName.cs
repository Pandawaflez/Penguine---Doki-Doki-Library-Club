using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputName : UIElement
{
    public InputName(GameObject element) : base(element) { }


    //get string from input field in game
    public string GetInputText()
    {
        var inputField = GetComponent<TMP_InputField>();
        return inputField != null ? inputField.text : string.Empty;
    }


    public void ClearInput()
    {
        var inputField = GetComponent<TMP_InputField>();
        if (inputField != null)
        {
            inputField.text = "";
        }
    }

    public void ValidateInput()
    {
        var inputField = GetComponent<TMP_InputField>();
        if (inputField != null && string.IsNullOrEmpty(inputField.text))
        {
            Debug.Log("Input field is empty!");
        }
    }
}
