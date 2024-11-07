using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FredDialogueData : Scooby
{
     public List<string> FredPrompts = new List<string>{
        "I heard there was a monster around. Have you seen it?" , // 0
        "I love to solve mysteries. What about you?", // 1
        "Before I started solving mysteries, I was an actor!", // 2
        "I love the Mystery Machine. I sure am a good driver!",// 3
        "I think Daphne is just the best.", // 4
        "I don't think we have much in common. Have a nice day!", // 5
        "Would you wanna play a game with me?", // 6
        "Ok, I'll go find Daphne instead." // 7
    };
    public List<string> Player_Response_1 = new List<string>{
        "Nope. I'm blind.", //0
        "Mysteries? *yawn*", //1
        "Cool!", //2 
        "I bet!", //3 
        "She's pretty great.", //4 
        "Yes", // 5
        " " //6
    };
    public List<string> Player_Response_2 = new List<string>{
        "Yes!",
        "I love mysteries too!",
        "So... you were a theater kid?",
        "Are you sure about that?",
        "I don't think shes that cool.",
        "No",
        " "
    };
}
