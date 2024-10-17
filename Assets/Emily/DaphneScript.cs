using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class DaphneScript : MonoBehaviour
{
    //buttons for dialogue
    public Button DaphR1;
    public Button DaphR2;

    public int responseNumD = 0;

    //selection fo dialogues
    public void hitDaphResponse1(){
        responseNumD = 1;
        Debug.Log("Response 1 chosen");
        DaphR1.Select();
    }
   
   public void hitDaphResponse2(){
        responseNumD = 2;
        Debug.Log("Response 2 chosen");
        DaphR2.Select();
   }

    private DaphDialogue mvpDaphDialogue;

    public TextMeshProUGUI DaphDialogueText, DaphResponse1Text, DaphResponse2Text;
    public GameObject Daph1p;
    public GameObject Daph2p;
    // Update is called once per frame
    void Update()
    {
        
    }
}
