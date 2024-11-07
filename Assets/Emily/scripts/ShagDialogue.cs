using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;

public class ShagStuffDialogue
{
    //dialogue setup for unity
    public TextMeshProUGUI ShagDialogueText, ShagResponse1Text, ShagResponse2Text;
    public GameObject Shag1Rp;
    public GameObject Shag2Rp;

    //responses
    private string dialogue = "Groovy";
    private string response1 = "Zoinks!";
    private string response2 = "I'm hungry";


}
public class ShagDialogue : ShagStuffDialogue
{
    public ShagDialogue(GameObject Shagrp1, GameObject Shagrp2, TextMeshProUGUI dt, TextMeshProUGUI r1te, TextMeshProUGUI r2te)
    {

        ShagDialogueText = dt;
        ShagResponse1Text = r1te;
        ShagResponse2Text = r2te;
        Shag1Rp = Shagrp1;
        Shag2Rp = Shagrp2;
    }
}


