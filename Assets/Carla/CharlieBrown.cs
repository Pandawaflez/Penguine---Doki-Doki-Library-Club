using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharlieBrown : Peanuts
{
    
    public string dialogue0 = "Hello. I'm Charlie Brown. I'd love to keep talking to you, as long as you keep your voice down. Afterall, we're in the Miami-Dade Public Library.";
    public string d0response1 = "Live a little Charlie! What harm will come from speaking loudly?";
    public string d0response2 = "Oh, of course! So nice to meet you Charlie";

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

    public string dialogue7 = "I'm busy, sorry.";


    void Start(){
        dialogueNum = 5;

    }
    void Update(){

    }
}
