using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SonicLI : Hedgehog
{
   //graphics, sfx, minigame
   public TextMeshProUGUI HdialogueText, Hresponse1Text, Hresponse2Text;

   //order of dialogue

   private string dialogueSonic0 = "Hey it's me Sonic the Hedgehog. I love adventure, how about you?";
   private string Response1dialogueSonic0 = "Me too! Did you find any adventure books?";
   private string Response2dialogueSonic0 = "Nice to meet you Sonic. I like to stay inside, like this library!";

   private string dialogueSonic1 = "More to come, real soon... hopefully";

    public void displaySonicDialogue(string dialogue, string r1, string r2){
        HdialogueText.SetText(dialogueSonic0);
        Hresponse1Text.SetText(Response1dialogueSonic0);
        Hresponse1Text.SetText(Response1dialogueSonic0);
    }

    public Text displayText;
    //JUST FOR MVP
    public void DisplayText(){
    displayText.text = "More text coming soon...";
    }


    public GameObject r1pS0;
    public GameObject r2pS0;
    public void displayJustText(string dialogue){
        HdialogueText.SetText(dialogueSonic1);
        r2pS0.SetActive(false);
        r1pS0.SetActive(false);
    }

    public Button SonicR1;
    public Button SonicR2;
    public int responseNumber = 0;

    //button one calls onclick
    public void hitSonicR1(){
        responseNumber = 1;
        Debug.Log("Response 1 has been chosen");
        SonicR1.Select();
        //toNextDialogue();
    }

    public void hitSonicR2(){
        responseNumber = 2;
        Debug.Log("Response 2 has been chosen");
        SonicR2.Select();
        //toNextDialogue();
    }
}
