using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class Scooby : MonoBehaviour
{
    public List<string> ShagPrompts = new List<string>{
        "Hey dude. Do you like sandwiches?",
        "How do you feel about Scooby snacks?",
        "I love haning around the Mystery Machine. Isn't is a sweet ride?",
        "I don't like reading. Figures I'd end up in a library.",
        "Have you seen any ghosts around? Ghouls? Lizard men?",
        "I don't think we have much in common. Sorry pal, I'll see you around",
        "Would you wanna keep this good thing going?"
    };
    public List<string> Player_Response_1 = new List<string>{
        "I sure do.",
        "I love a Scooby Snack!",
        "The Mystery Machine is kind of mid.",
        "I like reading books.",
        "No, I don't think anything spooky is around here."
    };
    public List<string> Player_Response_2 = new List<string>{
        "Nah, I'm more of a salad person.",
        "I prefer fruit snacks instead.",
        "The Mystery Machine sure is groovy!",
        "I don't like reading either.",
        "Yeah, I'm pretty sure I saw something freaky earlier."
    };
    //tracking what number dialogue response
    protected int SCdialogueNum = 0;
    //tracking affection points
    public int SCAP;

    public virtual void DisplayDialogue(TextMeshProUGUI dialogueText, TextMeshProUGUI response1Text, TextMeshProUGUI response2Text)
    {

        if (SCdialogueNum < ShagPrompts.Count)
        {
            dialogueText.text = ShagPrompts[SCdialogueNum];
            response1Text.text = Player_Response_1[SCdialogueNum];
            response2Text.text = Player_Response_2[SCdialogueNum];
        }
        else
        {
            dialogueText.text = "";
            response1Text.text = "";
            response2Text.text = "";
        }
    }

    public virtual void HandlePlayerResponse(int responseNum)
    {
        if (responseNum == 1) SCAP += 10;
        else if ((SCdialogueNum == 3 || SCdialogueNum == 4 || SCdialogueNum == 5) && responseNum == 2) SCAP -= 10;

        SCdialogueNum += 1;
    }

    
}
