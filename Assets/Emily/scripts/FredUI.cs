using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class FredUI : MonoBehaviour
{
    public Button FredR1;
    public Button FredR2;
    public TextMeshProUGUI FredDialogueText, FredResponse1Text, FredResponse2Text;
    

    private FredScript FredScript;
    
    // Start is called before the first frame update
    void Start()
    {
        FredScript = new FredScript();
        
        
        ShowFredDialogue();
        FredR1.onClick.AddListener(() => HandleResponse(1));
        FredR2.onClick.AddListener(() => HandleResponse(2));

    }
    
    public void ShowFredDialogue(){
        List<string> prompts = FredScript.GetFredPrompts;
        List<string> response_1 = FredScript.GetPlayer_Response_1;
        List<string> response_2 = FredScript.GetPlayer_Response_2;
        int FredLove = FredScript.FredAffection;
        FredScript.DisplayDialogue(prompts, FredDialogueText, FredResponse1Text, FredResponse2Text, response_1, response_2, FredLove);

    }
    
    private void HandleResponse(int responseNum){
        FredScript.HandlePlayerResponse(responseNum);
        ShowFredDialogue();
    }
    
}
