using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShaggyUI : MonoBehaviour
{
    public Button ShagR1;
    public Button ShagR2;
    public TextMeshProUGUI ShagDialogueText, ShagResponse1Text, ShagResponse2Text;
    

    private Scooby scoobyScript;

    // Start is called before the first frame update
    void Start()
    {
        scoobyScript = new ShaggyScript(); 

        if (!(ShaggyScript.ShaginteractedWith)){
            ShowShagDialogue();
            ShagR1.onClick.AddListener(() => HandleResponse(1));
            ShagR2.onClick.AddListener(() => HandleResponse(2));
        }
        else{
            Debug.Log("ShaginteractedWith is already true");
            DisableButtons();
        }
    }
    
    public void ShowShagDialogue(){
        if (ShaggyScript.ShaginteractedWith){
            Debug.Log("ShaggyinteractedWith is already true");
            DisableButtons();
            return;
        }

        List<string> prompts = ((ShaggyScript)scoobyScript).GetShagPrompts;
        List<string> response_1 = ((ShaggyScript)scoobyScript).GetPlayer_Response_1;
        List<string> response_2 = ((ShaggyScript)scoobyScript).GetPlayer_Response_2;
        int ShaggyLove = ShaggyScript.ShagSCAP;
        bool ShagInteraction = ShaggyScript.ShaginteractedWith;
        scoobyScript.DisplayDialogue(prompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, response_1, response_2, ShaggyLove, ShagInteraction);
        //scoobyScript.InteractionMonitor(ShaggyLove);

        if (ShaggyScript.ShaginteractedWith)
        {
            Debug.Log("interaction ended");
            scoobyScript.EndConversation(ShaggyScript.ShaginteractedWith, ShaggyScript.ShagSCAP);
            DisableButtons();
        }
    }
    
    private void HandleResponse(int responseNum){
        scoobyScript.HandlePlayerResponse(responseNum);
        if (((ShaggyScript)scoobyScript).SCdialogueNum >= ((ShaggyScript)scoobyScript).GetShagPrompts.Count)
        {
            ShaggyScript.ShaginteractedWith = true;
            scoobyScript.EndConversation(ShaggyScript.ShaginteractedWith, ShaggyScript.ShagSCAP);
        }
        ShowShagDialogue();
    }

    private void DisableButtons(){
        ShagR1.interactable = false;
        ShagR2.interactable = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (ShaggyScript.ShaginteractedWith){
            Debug.Log("buttons are disabled");
            DisableButtons();
        }
    }
}
