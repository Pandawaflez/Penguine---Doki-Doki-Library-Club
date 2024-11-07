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
        ShowShagDialogue();
        ShagR1.onClick.AddListener(() => HandleResponse(1));
        ShagR2.onClick.AddListener(() => HandleResponse(2));

    }
    
    public void ShowShagDialogue(){
        List<string> prompts = ((ShaggyScript)scoobyScript).GetShagPrompts;
        List<string> response_1 = ((ShaggyScript)scoobyScript).GetPlayer_Response_1;
        List<string> response_2 = ((ShaggyScript)scoobyScript).GetPlayer_Response_2;
        int ShaggyLove = ((ShaggyScript)scoobyScript).ShagAffection;
        scoobyScript.DisplayDialogue(prompts, ShagDialogueText, ShagResponse1Text, ShagResponse2Text, response_1, response_2, ShaggyLove);
        scoobyScript.InteractionMonitor(ShaggyLove);


    }
    
    private void HandleResponse(int responseNum){
        scoobyScript.HandlePlayerResponse(responseNum);
        ShowShagDialogue();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
