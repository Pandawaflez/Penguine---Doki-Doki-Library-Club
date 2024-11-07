using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DahpneDialogueData : Scooby
{
     public List<string> DaphPrompts = new List<string>{
        "Hi there! Do you like mysteries?", // 0
        "How do you feel about Scooby snacks?", // 1
        "I'm so glad my parents got us the Mystery Machine. Don't you love it?", // 2
        "I love hanging out with my friends at school. What about you?",// 3
        "Someday, we're all going to be world class detectives together!", // 4
        "I don't think we have much in common. Have a nice day!", // 5
        "Would you wanna play a game with me?", // 6
        "Ok, I'll go find Fred instead." // 7
    };
    public List<string> Player_Response_1 = new List<string>{
        "Boring...", //0
        "I love Scooby Snacks!", //1
        "I think its fabulous.", //2 
        "I like hanging out alone.", //3 
        "Sounds fun!", //4 
        "Yes", // 5
        " " //6
    };
    public List<string> Player_Response_2 = new List<string>{
        "I love solving them!",
        "I prefer salads.",
        "I think it's a bit much...",
        "I love being with my friends!",
        "I'm not so sure about that.",
        "No",
        " "
    };
}
