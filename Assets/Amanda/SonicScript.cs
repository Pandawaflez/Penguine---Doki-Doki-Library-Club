using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SonicScript : Hedgehog
{
   //graphics, sfx, minigame
   // public TextMeshProUGUI HdialogueText, Hresponse1Text, Hresponse2Text;
   //private SonicDialogue myDialogueSonic;
   //public Dialogue generalSonicDialogue;

   //order of dialogue

   /* private string dialogueSonic0 = "Hey it's me Sonic the Hedgehog. I love adventure, how about you?";
   private string Response1dialogueSonic0 = "Me too! Did you find any adventure books?";
   private string Response2dialogueSonic0 = "Nice to meet you Sonic. I like to stay inside, like this library!";

   private string dialogueSonic1 = "More to come, real soon... hopefully";

    public void displaySonicDialogue(string dialogue, string r1, string r2){
        HdialogueText.SetText(dialogueSonic0);
        Hresponse1Text.SetText(Response1dialogueSonic0);
        Hresponse1Text.SetText(Response1dialogueSonic0);
    }

    public GameObject r1pS0;
    public GameObject r2pS0;
    public void displayJustText(string dialogue){
        HdialogueText.SetText(dialogueSonic1);
        r2pS0.SetActive(false);
        r1pS0.SetActive(false);
    }
        */

    //buttons to for reset
    public Button SonicRB1;
    public Button SonicRB2;


    public int responseNumber = 0;

    //button one calls onclick
    public void hitSonicResponse1(){
        responseNumber = 1;
        Debug.Log("Response 1 has been chosen");
        SonicRB1.Select();
        //toNextDialogue();
    }

    public void hitSonicResponse2(){
        responseNumber = 2;
        Debug.Log("Response 2 has been chosen");
        SonicRB2.Select();
        //toNextDialogue();
    }
     
    private SonicDialogue mySonicDialogue;
    //public Dialogue generalSonicDialogue;

public TextMeshProUGUI SonDialogueText, SonResponse1Text, SonResponse2Text;
public GameObject Son1p;
public GameObject Son2p;
    void Start(){
       mySonicDialogue = new SonicDialogue(Son1p, Son2p, SonDialogueText, SonResponse1Text, SonResponse2Text);
    Debug.Log("Where are the response buttons? ");
    }

    void Update(){
        
    }
}

