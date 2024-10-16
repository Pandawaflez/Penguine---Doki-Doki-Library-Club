using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement
{
    protected GameObject element;

    public UIElement(GameObject element)
    {
        this.element = element;
    }

    public void Show()
    {
        element.SetActive(true);
    }

    public void Hide()
    {
        element.SetActive(false);
    }

    public virtual void onClick()
    {
        Debug.Log("This is the superclass method.");
    }
}
