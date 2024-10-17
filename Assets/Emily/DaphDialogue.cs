using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;

public class DaphStuffDialogue
{
    //dialogue setup for unity
    public TextMeshProUGUI DaphDialogueText, DaphResponse1Text, DaphResponse2Text;
    public GameObject Daph1Rp;
    public GameObject Daph2Rp;

    //responses
    private string dialogue = "Hi, I'm Daphne";
    private string response1 = "Jeepers!";
    private string response2 = "Oooo nice!";

}

public class DaphDialogue : DaphStuffDialogue {
    public DaphDialogue(GameObject Daphrp1, GameObject Daphrp2, TextMeshProUGUI dt, TextMeshProUGUI r1te, TextMeshProUGUI r2te){
        DaphDialogueText = dt;
        DaphResponse1Text = r1te;
        DaphResponse2Text = r2te;
        Daph1Rp = Daphrp1;
        Daph2Rp = Daphrp2;
    }
}
    