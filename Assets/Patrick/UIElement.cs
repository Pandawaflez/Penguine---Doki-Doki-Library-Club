using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement
{
    //private data class pattern:
    private class UIElementData{
        public GameObject Element { get; private set; }

        public bool Visible { get; private set; }   //mainly implemented for the overlay feature

        public UIElementData(GameObject element){
            Element = element;
            Visible = true;
        }

        public void SetActive(bool isActive){
            Element.SetActive(isActive);
            Visible = isActive;
        }

        public bool IsVisible(){
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

    //constructor initializes data object
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

    public bool Visible(){
        return elementData.IsVisible();
    }

    public virtual void onClick()
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
