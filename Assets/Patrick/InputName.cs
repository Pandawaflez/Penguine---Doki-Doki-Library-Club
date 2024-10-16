using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputName : UIElement
{
    public InputName(GameObject element) : base(element) { }

    public string GetInputText()
    {
        var inputField = element.GetComponent<TMP_InputField>();
        return inputField != null ? inputField.text : string.Empty;
    }


    public void ClearInput()
    {
        var inputField = element.GetComponent<TMP_InputField>();
        if (inputField != null)
        {
            inputField.text = "";
        }
    }

    public void ValidateInput()
    {
        var inputField = element.GetComponent<TMP_InputField>();
        if (inputField != null && string.IsNullOrEmpty(inputField.text))
        {
            Debug.Log("Input field is empty!");
        }
    }
}
