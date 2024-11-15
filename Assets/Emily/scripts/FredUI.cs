using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using ScoobyObserver;


public class FredUI : MonoBehaviour, IObserver
{
    //buttons for responses
    public Button FredR1;
    public Button FredR2;

    //variable to see if buttons are disabled
    public bool ButtonsDisabled;

    //text variables
    public TextMeshProUGUI FredDialogueText, FredResponse1Text, FredResponse2Text;
    
    //utilizing the superclass
    private Scooby  scoobyScript;

    private DialogueSound dialogueSound; // declared for audio
    
    // Start is called before the first frame update
    void Start()
    {
        //creates new instance of fredscript
        scoobyScript = new FredScript();

        //register as observer
        scoobyScript.RegisterObserver(this);
        
        // as long as fred hasn't been interacted with/locked out, the dialogue is shown
        if (!(FredScript.FredinteractedWith))
        {
            ShowFredDialogue();
            FredR1.onClick.AddListener(() => HandleResponse(1));
            FredR2.onClick.AddListener(() => HandleResponse(2));
        }
        //player is locked out
        else
        {
            FredScript.UpdateAffectionAfterMinigame();
            DisableButtons();
        }

        // AUDIO SETUP
        AudioClip fredVoice = Resources.Load<AudioClip>("Owen/voice");
        if (fredVoice == null)
        {
            Debug.LogError("Audio clip not found!");
            return;
        }

        // Create a new GameObject for the AudioSource
        GameObject audioGameObject = new GameObject("DialogueSoundAudioSource");
        AudioSource audioSource = audioGameObject.AddComponent<AudioSource>();

        // Assign the instance to the class-level dialogueSound variable
        dialogueSound = new DialogueSound(
            id: "fredVoice",
            clip: fredVoice,
            characterID: "Fred",
            backgroundID: "Scooby",
            source: audioSource
        );

        // Adjust the pitch directly through Unity on the AudioSource
        audioSource.pitch = 1f; 

    }
    
    //method to show dialogue on screen
    public void ShowFredDialogue(){
        //making sure player isn't locked out
        if (FredScript.FredinteractedWith || FredScript.FredLockout)
        {
            FredScript.UpdateAffectionAfterMinigame();
            DisableButtons();
            return;
        }

        //creates list, bool, and int variables from fred script
        List<string> prompts = ((FredScript)scoobyScript).GetFredPrompts;
        List<string> response_1 = ((FredScript)scoobyScript).GetPlayer_Response_1;
        List<string> response_2 = ((FredScript)scoobyScript).GetPlayer_Response_2;
        int FredLove = FredScript.FredSCAP;
        bool FredInteraction = FredScript.FredinteractedWith;
        scoobyScript.DisplayDialogue(prompts, FredDialogueText, FredResponse1Text, FredResponse2Text, response_1, response_2, FredLove, FredInteraction);

        //if fred has been interacted with after dialogue is shown, then values are changed and buttons disabled
        if (FredScript.FredinteractedWith || ((FredScript)scoobyScript).SCdialogueNum == 7 || ((FredScript)scoobyScript).SCdialogueNum == 5)
        {
            ButtonsDisabled = true;
            DisableButtons();
            Debug.Log("interaction ended");
            scoobyScript.EndConversation(FredScript.FredinteractedWith, FredScript.FredSCAP);
        }


    }

    private void HandleResponse(int responseNum){
        //calls HandlePlayerResponse from fred script
        scoobyScript.HandlePlayerResponse(responseNum);
        //if dialogue number > length of prompts list, everything stops
        if (((FredScript)scoobyScript).SCdialogueNum >= ((FredScript)scoobyScript).GetFredPrompts.Count)
        {
            FredScript.FredinteractedWith = true;
            FredScript.UpdateAffectionAfterMinigame();
            scoobyScript.EndConversation(FredScript.FredinteractedWith, FredScript.FredSCAP);
        }
        ShowFredDialogue();
    }
    
    //disables buttons and sets lockout variable to true so that the player cannot interact anymore  
    private void DisableButtons()
    {
        FredScript.FredLockout = true;
        FredR1.interactable = false;
        FredR2.interactable = false;
    }
    
    void Update()
    {
        if (FredScript.FredinteractedWith || ButtonsDisabled)
        {
            DisableButtons();
        }
    }

    public void Update(int affectionPoints, bool lockout, bool shaggyInteractedWith, bool daphneInteractedWith, bool fredInteractedwWith)
    {
        if (fredInteractedwWith)
        {
            DisableButtons();
        }
        else 
        {
            ShowFredDialogue();
        }
    }
}
