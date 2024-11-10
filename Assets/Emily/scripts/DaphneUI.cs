using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using ScoobyObserver;

public class DaphneUI : MonoBehaviour, IObserver
{
    //buttons for responses
    public Button DaphR1;
    public Button DaphR2;

    //variable to see if buttons are disabled
    public bool ButtonsDisabled;

    //text variables
    public TextMeshProUGUI DaphDialogueText, DaphResponse1Text, DaphResponse2Text;
    
    //utilizing the superclass
    private Scooby scoobyScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //creates new instance of daphne script
        scoobyScript = new DaphneScript();

        //register observer
        scoobyScript.RegisterObserver(this);
        
        if (!(DaphneScript.DaphinteractedWith))
        {
            ShowDaphDialogue();
            DaphR1.onClick.AddListener(() => HandleResponse(1));
            DaphR2.onClick.AddListener(() => HandleResponse(2));
        }

        //player is locked out
        else
        {
            Debug.Log("DaphinteractedWith is already true");
            DaphneScript.UpdateAffectionAfterMinigame();
            DisableButtons();
        }
    }
    
    //method to show the dialogue on screen
    public void ShowDaphDialogue(){
        //making sure player isn't locked out
        if (DaphneScript.DaphinteractedWith || DaphneScript.DaphLockout)
        {
            Debug.Log("DaphneinteractedWith is already true");
            DaphneScript.UpdateAffectionAfterMinigame();
            DisableButtons();
            return;
        }

        //creates list, bool, and int variables from daphne script
        List<string> prompts = ((DaphneScript)scoobyScript).GetDaphPrompts;
        List<string> response_1 = ((DaphneScript)scoobyScript).GetPlayer_Response_1;
        List<string> response_2 = ((DaphneScript)scoobyScript).GetPlayer_Response_2;
        int DaphneLove = DaphneScript.DaphSCAP;
        bool DaphInteration = DaphneScript.DaphinteractedWith;
        scoobyScript.DisplayDialogue(prompts, DaphDialogueText, DaphResponse1Text, DaphResponse2Text, response_1, response_2, DaphneLove, DaphInteration);

        //if daphne has been interacted with after dialogue is shown, then values are changed and buttons disabled
        if (DaphneScript.DaphinteractedWith || ((DaphneScript)scoobyScript).SCdialogueNum == 7 || ((DaphneScript)scoobyScript).SCdialogueNum == 5)
        {
            ButtonsDisabled = true;
            DisableButtons();
            Debug.Log("interaction ended");
            scoobyScript.EndConversation(DaphneScript.DaphinteractedWith, DaphneScript.DaphSCAP);
        }
    }
    
    private void HandleResponse(int responseNum){
        //calls HandlePlayerResponse from daphne script
        scoobyScript.HandlePlayerResponse(responseNum);
        
        //if dialogue number is > length of prompts list, everything stops
        if (((DaphneScript)scoobyScript).SCdialogueNum >= ((DaphneScript)scoobyScript).GetDaphPrompts.Count)
        {
            DaphneScript.DaphinteractedWith = true;
            DaphneScript.UpdateAffectionAfterMinigame();
            scoobyScript.EndConversation(DaphneScript.DaphinteractedWith, DaphneScript.DaphSCAP);
        }
        ShowDaphDialogue();
    }

    //disables buttons and sets lockout variable to true so that the player cannot interact with daphne
    private void DisableButtons()
    {
        DaphneScript.DaphLockout = true;
        DaphR1.interactable = false;
        DaphR2.interactable = false;
    }

    //update (called once per frame)
    void Update()
    {
        if (DaphneScript.DaphinteractedWith || ButtonsDisabled)
        {
            DisableButtons();
        }
    }
    
    public void Update(int affectionPoints, bool lockout, bool shaggyInteractedWith, bool daphneInteractedWith, bool fredInteractedwWith)
    {
        if (daphneInteractedWith)
        {
            DisableButtons();
        }
        else
        {
            ShowDaphDialogue();
        }
    }

}
