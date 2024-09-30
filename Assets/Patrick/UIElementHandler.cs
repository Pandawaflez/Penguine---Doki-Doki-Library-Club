using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementHandler : MonoBehaviour
{

    public static UIElementHandler UIGod {get; private set; }

    private void Awake()
    {
        // Implement Singleton pattern
        if (UIGod != null && UIGod != this)
        {
            Destroy(gameObject);
        }
        else
        {
            UIGod = this;
            DontDestroyOnLoad(gameObject);  // Make this instance persistent across scenes
        }
    }

    private void Update(){
        UICheckInput();
    }

    //Function to check for UI User input ***Put in update()***
    public void UICheckInput(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            Debug.Log("*****Overlay Toggle*****");
        }
    }
}
