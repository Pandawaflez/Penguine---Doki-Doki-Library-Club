using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DialoqData
{

    public string dialogue;
    public string response1;
    public string response2;

    public void DialogData(string d, string r1, string r2){
        dialogue = d;
        response1 = r1;
        response2 = r2;
    }

}
