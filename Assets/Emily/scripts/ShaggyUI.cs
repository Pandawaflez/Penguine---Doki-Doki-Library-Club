using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShaggyUI : MonoBehaviour
{
    //buttons for responses
    public Button ShagR1;
    public Button ShagR2;

    //variable to see if the buttons are disabled 
    public bool ButtonsDisabled;

    //text variables
    public TextMeshProUGUI ShagDialogueText, ShagResponse1Text, ShagResponse2Text;
    
    //utilizing the superclass
    private Scooby scoobyScript;

    // Start is called before the first frame update
    void Start()
    {
        //creates new instance of shaggyscript
        scoobyScript = new ShaggyScript(); 

        if (!(ShaggyScript.ShaginteractedWith)){ //as long as shaggy hasn't been interacted with/locked out, the dialogue is shown
            ShowShagDialogue();
            ShagR1.onClick.AddListener(() => HandleResponse(1));
            ShagR2.onClick.AddListener(() => HandleResponse(2));
        }
        else{ //player is locked out
            Debug.Log("ShaginteractedWith is already true");
            DisableButtons();
        }
    }
    
    //method to show the dialogue on screen
    public void ShowShagDialogue(){
        if (ShaggyScript.ShaginteractedWith || ShaggyScript.ShagLockout){ //making sure the player isn't locked out
            Debug.Log("ShaggyinteractedWith is already true");
            DisableButtons();
            return;
        }
        
        // creates the list, bool, and int variables from the shaggy script
        List<string> prompts = ((ShaggyScript)scoobyScript).GetShagPrompts;
        List<string> response_1 = ((ShaggyScript)scoobyScript).GetPlayer_Response_1;
        List<string> response_2 = ((ShaggyScript)scoobyScript).GetPlayer_Response_2;
        int ShaggyLove = ShaggyScript.ShagSCAP;
        bool ShagInteraction = ShaggyScript.ShaginteractedWith;
        scoobyScript.DisplayDialogue(prompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, response_1, response_2, ShaggyLove, ShagInteraction); //called using the class instance

        //if shaggy has been interacted with after dialogue is shown, then the values are changed and buttons disabled
        if (ShaggyScript.ShaginteractedWith || ((ShaggyScript)scoobyScript).SCdialogueNum == 7 || ((ShaggyScript)scoobyScript).SCdialogueNum == 5)
        {
            ButtonsDisabled = true;
            DisableButtons();

            Debug.Log("interaction ended");
            scoobyScript.EndConversation(ShaggyScript.ShaginteractedWith, ShaggyScript.ShagSCAP);
        }
    }
    
    private void HandleResponse(int responseNum){
        scoobyScript.HandlePlayerResponse(responseNum); //calls HandlePlayerResponse using the class instance
        if (((ShaggyScript)scoobyScript).SCdialogueNum >= ((ShaggyScript)scoobyScript).GetShagPrompts.Count) //if the dialogue number is > length of the prompts list, everything stops
        {
            ShaggyScript.ShaginteractedWith = true;
            scoobyScript.EndConversation(ShaggyScript.ShaginteractedWith, ShaggyScript.ShagSCAP);
        }
        ShowShagDialogue();
    }

    //disables the buttons and sets the lockout variable to true so the player can't interact
    private void DisableButtons()
    {
        ShaggyScript.ShagLockout = true;
        ShagR1.interactable = false;
        ShagR2.interactable = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (ShaggyScript.ShaginteractedWith || ButtonsDisabled){ 
            DisableButtons();
        }
    }
}
