using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

public abstract class ShaggyDialogeData : Scooby
{
     public List<string> ShagPrompts = new List<string>{
        "Hey dude. Do you like sandwiches?", // 0
        "How do you feel about Scooby snacks?", // 1
        "I love haning around the Mystery Machine. Isn't is a sweet ride?", // 2
        "I don't like reading. Figures I'd end up in a library.",// 3
        "Have you seen any ghosts around? Ghouls? Lizard men?", // 4
        "I don't think we have much in common. Sorry pal, I'll see you around", // 5
        "Would you wanna keep this good thing going?", // 6
        "Ok, keep it groovy man" // 7
    };
    public List<string> Player_Response_1 = new List<string>{
        "I sure do.", //0
        "I love a Scooby Snack!", //1
        "The Mystery Machine is kind of mid.", //2 
        "I like reading books.", //3 
        "No, I don't think anything spooky is around here.", //4 
        "Yes", // 5
        " " //6
    };
    public List<string> Player_Response_2 = new List<string>{
        "Nah, I'm more of a salad person.",
        "I prefer fruit snacks instead.",
        "The Mystery Machine sure is groovy!",
        "I don't like reading either.",
        "Yeah, I'm pretty sure I saw something freaky earlier.",
        "No",
        " "
    };
    
   
}
