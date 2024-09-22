using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Peanuts : MonoBehaviour
{
    //graphics
    //sfx

    //dialogues
    /*
    private string dialogue1;
    private string dialogue2;
    private string dialogue3;
    private string dialogue4;
    protected string dialogue5 = "hi";
    */

    //dialogue responses

    //dialoguetracker
    protected int dialogueNum = 0;

    //affection points
    public int affectionPoints;
    public void updateAffection(int newPoints){
        affectionPoints += newPoints;
    }

    //minigame

    
}
