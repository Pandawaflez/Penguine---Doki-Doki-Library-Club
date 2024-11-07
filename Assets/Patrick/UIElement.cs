using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement
{
    //private data class pattern:
    private class UIElementData
    {
        private GameObject Element;
        private bool Visible;   //mainly implemented for the overlay feature
        private bool State;     //will use for enabled/disabled button opacity

        public UIElementData(GameObject element)
        {
            Element = element;
            Visible = true;
            State = true;
        }

        public void SetActive(bool isActive)
        {
            Element.SetActive(isActive);
            Visible = isActive;
        }

        public void SetState(bool state)
        {
            State = state;
        }

        public bool GetState()
        {
            return State;
        }

        public bool IsVisible()
        {
            return Visible;
        }

        // Generic accessor for retrieving components
        public T GetComponent<T>() where T : Component
        {
            return Element != null ? Element.GetComponent<T>() : null;
        }
    }

    //composition: UIElement contains instance of UIElementData
    private UIElementData elementData;

    //constructor initializes data object from the private class
    public UIElement(GameObject element)
    {
        elementData = new UIElementData(element);
    }

    public void Show()
    {
        elementData.SetActive(true);
    }

    public void Hide()
    {
        elementData.SetActive(false);
    }

    public void setState(bool state)
    {
        elementData.SetState(state);
    }

    public bool Visible()
    {
        return elementData.IsVisible();
    }

    public virtual void v_onClick()
    // public void onClick()
    {
        Debug.Log("This is the superclass method.");
    }

    // Expose GetComponent through UIElement (for TMPro and getting input from input field)
    protected T GetComponent<T>() where T : Component
    {
        return elementData.GetComponent<T>();
    }
}
