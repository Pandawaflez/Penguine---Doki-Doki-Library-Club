using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class Dialogue
{
    
    public TextMeshProUGUI dialogueText, response1Text, response2Text;
    public GameObject r1p;
    public GameObject r2p;
    

    private string genericDialogue = "Who am I?";
    private string genericResponse1 = "Bro";
    private string genericResponse2 = "ruh roh";

    public virtual void displayDialogue(int d){
    //public virtual void displayDialogue(int d, GameObject cr1p, GameObject cr2p, TextMeshProUGUI cdt, TextMeshProUGUI cr1t, TextMeshProUGUI cr2t){
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
    //5-> 7 (end)
    //6->a5|b-game
    //7-> loop
    //8-> after game
    
  
    private string dialogue0 = "Hello. I'm Charlie Brown.\nI'd love to keep talking to you, as long as you keep your voice down. Afterall, we're in the Miami-Dade Public Library.";
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

    public string dialogue8 = "Well, thanks for playing!";

    //what's that got to do with anything
    

    //was public
    /*
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
    */

    public override void displayDialogue(int d){
        switch(d){
            case 0:
            r2p.SetActive(true);
            r1p.SetActive(true);
            Debug.Log("first time here huh");
                displayRealDialogue(dialogue0, d0response1, d0response2);
        
                break;
            case 1:
            Debug.Log("here i stand");
                displayRealDialogue(dialogue1, d1response1, d1response2);
                
                break;
            case 2:
                displayRealDialogue(dialogue2, d2response1, d2response2);
                
                break;
            case 3: 
                displayRealDialogue(dialogue3, d3response1, d3response2);
                
                break;
            case 4:
                displayRealDialogue(dialogue4, d4response1, d4response2);
                
                break;
            case 5:
                displayJustText(dialogue5);
                
                break;
            case 6:
                displayRealDialogue(dialogue6, d6response1, d6response2);
                
                break;
            case 7:
                displayJustText(dialogue7);
                //stuck
                break;
            case 8:
                displayJustText(dialogue8);
                break;
        }
    }

    private void displayRealDialogue(string dialogue, string r1, string r2){
        dialogueText.SetText(dialogue);
        response1Text.SetText(r1);
        response2Text.SetText(r2);
    }

    private void displayJustText(string dialogue){
        dialogueText.SetText(dialogue);
        //dt.SetText(dialogue);
        r2p.SetActive(false);
        r1p.SetActive(false);
        //r1.gameObject.SetActive(false); //these didn't work for no reason smh
        //r2.gameObject.SetActive(false);
    }

    public CharlieDialogue(GameObject Cr1p, GameObject Cr2p, TextMeshProUGUI dt, TextMeshProUGUI r1t, TextMeshProUGUI r2t){
        dialogueText =  dt;
        response1Text = r1t;
        response2Text = r2t;
        r1p = Cr1p;
        r2p = Cr2p;
    }

}


public class LucyDialogue : Dialogue
{
    //public TextMeshProUGUI dialogueText, response1Text, response2Text;

    //dialogue order: 
    //0-> a1|b2
    //1-> a4|b3
    //2-> a5|b6
    //3-> a7|b2
    //4-> a7|b8
    //5-> a10|b9
    //6-> a10|b9
    //7-> 15 end
    //8-> a7|b6 
    //9-> a10|b-game
    //10->a7|b11
    //11->a12|b-game
    //12->a14|b13
    //13->a14|b-game
    //14-> 15 end
    //15-> loop
    //16-> after lose game
    //17-> after win game
    
  
    private string dialogue0 = "You look lost, little donut. I'll take pity on you and give you some advice, for a nickel. Welcome to Lucy's corner.";
    private string d0response1 = "Bruh you ain't getting my nickels";
    private string d0response2 = "Deal of the century. Please enlighten me, my Grace";

    private string dialogue1 = "Fine! I'll give you a free sample then. Goodness you are stingy.";
    private string d1response1 = "What's this advice huh";
    private string d1response2 = "Oh, well thanks I suppose... I'll try it out";

    private string dialogue2 = "I guess you're a pretty smart one afterall!\nWell, I was going to tell you that you'd better start walking around a little more mindfully. Those librarians are always watching.";
    private string d2response1 = "... Really?";
    private string d2response2 = "Good Grief! Are they watching us right now?";

    private string dialogue3 = "My advice is to treat a lady with a little more respect! What is it with people these days?!";
    private string d3response1 = "Do you have any actually good advice?";
    private string d3response2 = "Jeez, my bad Lucy. I'll be better for you :)";

    private string dialogue4 = "My advice is to get a pair of eyes! Nobody wants to talk to a nickel-less wanderer.";
    private string d4response1 = "Bro! I'm not nickel-less, I just don't want to give them to you!";
    private string d4response2 = "Golly Lucy, like you're right, but it's not my fault I'm nickel-less! That crazy Shaggy kid robbed me for sandwich money for him and his beastie";

    private string dialogue5 = "Of course! I've never made a mistake in my life. I thought I did once, but I was wrong.";
    private string d5response1 = "So... that's a mistake";
    private string d5response2 = "You are my idol, Lucy Van Pelt";

    private string dialogue6 = "They know not to bother me. Nobody tells me what to do! Nobody!!";
    private string d6response1 = "What if I told you that you infact are a product of a society of tellers.";
    private string d6response2 = "You are a legend among characters, Lucy";

    private string dialogue7 = "Well you don't deserve any advice! Bug off, cretin!!";

    private string dialogue8 = "Harrumph!\nWell, that's why you've got to carry yourself with a little more respect! Then people won't bother you";
    private string d8response1 = "Respect?! You carry yourself like a dictator!";
    private string d8response2 = "Oh, does that really work?";

    private string dialogue9 = "You're lucky I like flattery. So, do you want to play a game?";
    private string d9response1 = "Bro that was sarcasm";
    private string d9response2 = "yethhhh";

    private string dialogue10 = "Oh so we've got a smarty pants on our hands, is that so?!";
    private string d10response1 = "Hardly much competition around here";
    private string d10response2 = "I'm sorry Lucy, I was just trying to keep up with your unbeatable witiness! Let me repent.";

    private string dialogue11 = "You should obviously know that no one can keep up with me. So let's see your talent in a game!";
    private string d11response1 = "I've seen your wiles with Charlie, so there's no way.";
    private string d11response2 = "It would be my honor to lose to you";

    private string dialogue12 = "Hanging around Charlie Brown, huh? What's that downer been up to. Downering? Gah! Don't bring him up again.";
    private string d12response1 = "You're the downerer! Of others!";
    private string d12response2 = "Well that's why I'm over here talking to you instead of him.";

    private string dialogue13 = "Hmm, that's what I thought. Well, prove it with a game?";
    private string d13response1 = "Why must we perpetrate the cycle of pain...";
    private string d13response2 = "Well... I'll try.";

    private string dialogue14 = "I can't take this attitude any longer! Don't bring me down with these words of despair! Good Grief! You're just like Charlie Brown!";

    public string dialogue15 = "You again? Don't bother!";

    public string dialogue16 = "";

    public string dialogue17 = "Hah! Well good game against me, the winner, of course.";

    public override void displayDialogue(int d){
        switch(d){
            case 0:
            r2p.SetActive(true);
            r1p.SetActive(true);
            Debug.Log("first time here huh");
                displayRealDialogue(dialogue0, d0response1, d0response2);
                break;
            case 1:
            Debug.Log("here i stand");
                displayRealDialogue(dialogue1, d1response1, d1response2);
                
                break;
            case 2:
                displayRealDialogue(dialogue2, d2response1, d2response2);
                
                break;
            case 3: 
                displayRealDialogue(dialogue3, d3response1, d3response2);
                
                break;
            case 4:
                displayRealDialogue(dialogue4, d4response1, d4response2);
                
                break;
            case 5:
                displayRealDialogue(dialogue5, d5response1, d5response2);
                
                break;
            case 6:
                displayRealDialogue(dialogue6, d6response1, d6response2);
                
                break;
            case 7:
                displayJustText(dialogue7);
                
                break;
            case 8:
                displayRealDialogue(dialogue8, d8response1, d8response2);
                break;
            case 9:
                displayRealDialogue(dialogue9, d9response1, d9response2);
                
                break;
            case 10: 
                displayRealDialogue(dialogue10, d10response1, d10response2);
                
                break;
            case 11:
                displayRealDialogue(dialogue11, d11response1, d11response2);
                
                break;
            case 12:
                displayRealDialogue(dialogue12, d12response1, d12response2);
                break;
            case 13:
                displayRealDialogue(dialogue13, d13response1, d13response2);
                
                break;
            case 14: 
                 displayJustText(dialogue14);
                
                break;
            case 15:
                 displayJustText(dialogue15);
                 break;
            case 16:
                displayJustText(dialogue16);
                break;
        }
    }

    private void displayRealDialogue(string dialogue, string r1, string r2){
        dialogueText.SetText(dialogue);
        response1Text.SetText(r1);
        response2Text.SetText(r2);
    }

    private void displayJustText(string dialogue){
        dialogueText.SetText(dialogue);
        //dt.SetText(dialogue);
        r2p.SetActive(false);
        r1p.SetActive(false);
        //r1.gameObject.SetActive(false); //these didn't work for no reason smh
        //r2.gameObject.SetActive(false);
    }

    public LucyDialogue(GameObject Lr1p, GameObject Lr2p, TextMeshProUGUI dt, TextMeshProUGUI r1t, TextMeshProUGUI r2t){
        dialogueText =  dt;
        response1Text = r1t;
        response2Text = r2t;
        r1p = Lr1p;
        r2p = Lr2p;
    }

}

