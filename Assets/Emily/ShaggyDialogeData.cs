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
        "Hey dude. Do you like sandwiches?", // 1
        "How do you feel about Scooby snacks?", // 2
        "I love haning around the Mystery Machine. Isn't is a sweet ride?", // 3
        "I don't like reading. Figures I'd end up in a library.",// 4
        "Have you seen any ghosts around? Ghouls? Lizard men?", // 5
        "I don't think we have much in common. Sorry pal, I'll see you around", // 6
        "Would you wanna keep this good thing going?", // 7
        "Ok, keep it groovy man" // 8
    };
    public List<string> Player_Response_1 = new List<string>{
        "I sure do.",
        "I love a Scooby Snack!",
        "The Mystery Machine is kind of mid.",
        "I like reading books.",
        "No, I don't think anything spooky is around here.",
        "Yes",
        " "
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
