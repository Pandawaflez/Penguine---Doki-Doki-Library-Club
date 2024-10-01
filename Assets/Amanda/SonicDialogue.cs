

using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class sonicstuffDialogue
{
    
    public TextMeshProUGUI SonicDialogueText, SonicResponse1Text, SonicResponse2Text;
    public GameObject Sonic1rp;
    public GameObject Sonic2rp;
    
   

    private string genericDialogue = "Who am I?";
    private string genericResponse1 = "Bro";
    private string genericResponse2 = "ruh roh";

    //public virtual void displayDialogue(int d){
    //public virtual void displayDialogue(int d, GameObject cr1p, GameObject cr2p, TextMeshProUGUI cdt, TextMeshProUGUI cr1t, TextMeshProUGUI cr2t){
        //display the dialogue, call sfx, wait a few sec, display response
        //dialogueText.SetText(genericDialogue);
        //response1Text.SetText(genericResponse1);
        //response2Text.SetText(genericResponse2);
        //call sfx. should only play 3 sec
    //}
}

public class SonicDialogue : sonicstuffDialogue
{
    //public TextMeshProUGUI dialogueText, response1Text, response2Text;

    
    public SonicDialogue(GameObject Sonr1p, GameObject Sonr2p, TextMeshProUGUI dt, TextMeshProUGUI r1t, TextMeshProUGUI r2t){
        SonicDialogueText =  dt;
        SonicResponse1Text = r1t;
        SonicResponse2Text = r2t;
        Sonic1rp = Sonr1p ;
        Sonic2rp = Sonr2p;
    }

}

