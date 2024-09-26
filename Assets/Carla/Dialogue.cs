using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class Dialogue
{
    /*
    public TextMeshProUGUI dialogueText, response1Text, response2Text;
    public GameObject r1p;
    public GameObject r2p;
    */

    private string genericDialogue = "Who am I?";
    private string genericResponse1 = "Bro";
    private string genericResponse2 = "ruh roh";

    public virtual void displayDialogue(int d, GameObject cr1p, GameObject cr2p, TextMeshProUGUI cdt, TextMeshProUGUI cr1t, TextMeshProUGUI cr2t){
        //display the dialogue, call sfx, wait a few sec, display response
        //dialogueText.SetText(genericDialogue);
        //response1Text.SetText(genericResponse1);
        //response2Text.SetText(genericResponse2);
        //call sfx. should only play 3 sec
    }
}

public class CharlieDialogue : Dialogue
{
    //public TextMeshProUGUI dialogueText, response1Text, response2Text;

    //dialogue order: 
    //0->a1|b2
    //1->a5|b2
    //2->a3|b4
    //3->a5|b6
    //4->a5|b-game
    //5-> 7
    //6->a5|b-game
    //7-> 7
    
  
    private string dialogue0 = "Hello. I'm Charlie Brown. I'd love to keep talking to you, as long as you keep your voice down. Afterall, we're in the Miami-Dade Public Library.";
    private string d0response1 = "Live a little Charlie! What harm will come from speaking loudly?";
    private string d0response2 = "Oh, of course! So nice to meet you Charlie";

    private string dialogue1 = "Don't you know the librarians can lock you up in the Ancient book room?! I can't associate with you anymore.";
    private string d1response1 = "Don't be such a scaredy cat Charlie Brown";
    private string d1response2 = "Good Grief! Good thing you warned me!";

    private string dialogue2 = "So what brings you to my corner of the library?";
    private string d2response1 = "I'm hunting rats";
    private string d2response2 = "I'm just looking for something to do while I wait for my little sister to pick out her comics.";

    private string dialogue3 = "Good Grief! Are there really rats in here?";
    private string d3response1 = "No smh that was clearly a joke";
    private string d3response2 = "Yeah but don't worry pookie, I'll keep you safe";

    private string dialogue4 = "Oh what a coincidence! I have a little sister roaming around too. Do you want to play a game with me while we wait?";
    private string d4response1 = "No I just want to read a book";
    private string d4response2 = "Holy Smokes yeah";

    private string dialogue5 = "I'm just going to go back to reading then...";

    private string dialogue6 = "Oh umm. Thank you. Well since you're here, want to play a game?";
    private string d6response1 = "Unfortch there's no rest for the wicked. See ya!";
    private string d6response2 = "Yes, my sweet prince!";

    private string dialogue7 = "I'm reading, sorry.";

    public string dialogue8 = "Thanks for playing with me!";
    

    //was public
    public override void displayDialogue(int d, GameObject r1p, GameObject r2p, TextMeshProUGUI dt, TextMeshProUGUI r1t, TextMeshProUGUI r2t){
        switch(d){
            case 0:
            r2p.SetActive(true);
            r1p.SetActive(true);
            Debug.Log("first time here huh");
                displayRealDialogue(dialogue0, d0response1, d0response2, dt, r1t, r2t);
                
                break;
            case 1:
            Debug.Log("here i stand");
                displayRealDialogue(dialogue1, d1response1, d1response2, dt, r1t, r2t);
                
                break;
            case 2:
                displayRealDialogue(dialogue2, d2response1, d2response2, dt, r1t, r2t);
                
                break;
            case 3: 
                displayRealDialogue(dialogue3, d3response1, d3response2, dt, r1t, r2t);
                
                break;
            case 4:
                displayRealDialogue(dialogue4, d4response1, d4response2, dt, r1t, r2t);
                
                break;
            case 5:
                displayJustText(dialogue5, r1p, r2p, dt);
                
                break;
            case 6:
                displayRealDialogue(dialogue6, d6response1, d6response2, dt, r1t, r2t);
                
                break;
            case 7:
                displayJustText(dialogue7, r1p, r2p, dt);
                //stuck
                break;
            case 8:
                displayJustText(dialogue8, r1p, r2p, dt);
                break;
        }
    }

    private void displayRealDialogue(string dialogue, string r1, string r2, TextMeshProUGUI dt, TextMeshProUGUI r1t, TextMeshProUGUI r2t){
        //dialogueText.SetText(dialogue);
        //response1Text.SetText(r1);
        //response2Text.SetText(r2);
        dt.SetText(dialogue);
        r1t.SetText(r1);
        r2t.SetText(r2);
    }
    private string dialouge70 = "this is dialogue 70";
    public string getDialogue70(){
        return dialouge70;
    }
    
    private void displayJustText(string dialogue, GameObject r1p, GameObject r2p, TextMeshProUGUI dt){
        //dialogueText.SetText(dialogue);
        dt.SetText(dialogue);
        r2p.SetActive(false);
        r1p.SetActive(false);
        //r1.gameObject.SetActive(false); //these didn't work for no reason smh
        //r2.gameObject.SetActive(false);
    }

    public CharlieDialogue(){
        //this.dialouge70 = "this is dialoge 70.1";
    }

}

