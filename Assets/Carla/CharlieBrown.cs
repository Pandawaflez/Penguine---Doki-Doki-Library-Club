using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CharlieBrown : Peanuts
{
    //graphics
    //sfx
    //minigame

    public TextMeshProUGUI dialogueText, response1Text, response2Text;

    /*dialogue order: 
    0->a1|b2
    1->a5|b2
    2->a3|b4
    3->a5|b6
    4->a5|b-game
    5-> 7
    6->a5|b-game
    7-> 7
    */
    private string dialogue0 = "Hello. I'm Charlie Brown. I'd love to keep talking to you, as long as you keep your voice down. Afterall, we're in the Miami-Dade Public Library.";
    private string d0response1 = "Live a little Charlie! What harm will come from speaking loudly?";
    private string d0response2 = "Oh, of course! So nice to meet you Charlie";

    public string dialogue1 = "Don't you know the librarians can lock you up in the Ancient book room?! I can't associate with you anymore.";
    public string d1response1 = "Don't be such a scaredy cat Charlie Brown";
    public string d1response2 = "Good Grief! Good thing you warned me!";

    public string dialogue2 = "So what brings you to my corner of the library?";
    public string d2response1 = "I'm hunting rats";
    public string d2response2 = "I'm just looking for something to do while I wait for my little sister to pick out her comics.";

    public string dialogue3 = "Good Grief! Are there really rats in here?";
    public string d3response1 = "No smh that was clearly a joke";
    public string d3response2 = "Yeah but don't worry pookie, I'll keep you safe";

    public string dialogue4 = "Oh what a coincidence! I have a little sister roaming around too. Do you want to play a game with me while we wait?";
    public string d4response1 = "No I just want to read a book";
    public string d4response2 = "Holy Smokes yeah";

    public string dialogue5 = "I'm just going to go back to reading then...";

    public string dialogue6 = "Oh umm. Thank you. Well since you're here, want to play a game?";
    public string d6response1 = "Unfortch there's no rest for the wicked. See ya!";
    public string d6response2 = "Yes, my sweet prince!";

    public string dialogue7 = "I'm reading, sorry.";


    public void displayDialogue(string dialogue){
        //display the dialogue, call sfx, wait a few sec, display response

    }

   
    void Start(){
        dialogueNum = 0;
        affectionPoints = 5;
        dialogueText.SetText(dialogue0);
        response1Text.SetText(d0response1);
        response2Text.SetText("my sweet sweet charlie prince...");

    }
    void Update(){

    }
}
