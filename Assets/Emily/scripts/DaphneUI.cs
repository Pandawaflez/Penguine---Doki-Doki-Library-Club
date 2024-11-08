using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
/*
public class DaphneUI : MonoBehaviour
{
    public Button DaphR1;
    public Button DaphR2;
    public TextMeshProUGUI DaphDialogueText, DaphResponse1Text, DaphResponse2Text;
    

    private DaphneScript DaphScript;
    
    // Start is called before the first frame update
    void Start()
    {
        DaphScript = new DaphneScript();
        
        
        ShowDaphDialogue();
        DaphR1.onClick.AddListener(() => HandleResponse(1));
        DaphR2.onClick.AddListener(() => HandleResponse(2));

    }
    
    public void ShowDaphDialogue(){
        List<string> prompts = DaphScript.GetDaphPrompts;
        List<string> response_1 = DaphScript.GetPlayer_Response_1;
        List<string> response_2 = DaphScript.GetPlayer_Response_2;
        int DaphneLove = DaphScript.DaphAffection;
        DaphScript.DisplayDialogue(prompts, DaphDialogueText, DaphResponse1Text, DaphResponse2Text, response_1, response_2, DaphneLove);

    }
    
    private void HandleResponse(int responseNum){
        DaphScript.HandlePlayerResponse(responseNum);
        ShowDaphDialogue();
    }
    


}
*/