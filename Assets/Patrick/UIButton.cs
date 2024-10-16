using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : UIElement
{
    public UIButton(GameObject element) : base(element)
    {
    }

    public void OnButtonClick()
    {
        Debug.Log("Button clicked: " + element.name);
        Show();  // look into overriding UIElement here
    }
}
