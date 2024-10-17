using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnityDialogueUI : MonoBehaviour
{
    public TMP_Text dialogueText;
    public TMP_Text affectionText;
    public Button responseButton1;
    public Button responseButton2;
    private DialogueController dialogueController;
    private AffectionManager affectionManager;
    void Start()
    {
        //instantiate affection manager manually since its not mono.
        affectionManager = new AffectionManager();

        //set AffectionUI and register it as an observer
        AffectionUI affectionUI = new AffectionUI(affectionText);
        affectionManager.RegisterObserver(affectionUI);

        //create Shadow's dialogue
        HedgehogDialogue shadowDialogue = new ShadowDialogue(affectionManager);
        dialogueController = new DialogueController(shadowDialogue);
        //show base dialogue
        ShowDialogue();

        //set buttons up
        responseButton1.onClick.AddListener( () => OnResponse(1));
        responseButton2.onClick.AddListener( () => OnResponse(2));
    }

    void ShowDialogue(){
        dialogueText.text = dialogueController.GetCurrentDialogueLine();
        string[] responses = dialogueController.GetCurrentResponses();

        responseButton1.GetComponentInChildren<TMP_Text>().text = responses[0];
        responseButton2.GetComponentInChildren<TMP_Text>().text = responses[1];
    }
    void OnResponse(int choice){
        dialogueController.HandlePlayerChoice(choice);
        ShowDialogue(); // update dialogue after player choice
    }

}
