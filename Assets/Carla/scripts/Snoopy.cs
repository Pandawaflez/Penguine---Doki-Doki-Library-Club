using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Snoopy : Peanuts
//PATTERN 1. 'independent' functionality
{
    public AudioManager theAudio;
    
    public TextMeshProUGUI CdialogueText, Cresponse1Text, Cresponse2Text;
    public GameObject Cr1p;
    public GameObject Cr2p;

    public Dialogue genDialogue;
    private SnoopyDialogue myDialogue;

    private string game = "Minesweeper";

    private List<WoodStock> birds;  //PATTERN 3. coupled only to 'interface'
    void Start()
    {
        birds = new List<WoodStock>();
        myDialogue = new SnoopyDialogue(Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        //theAudio = new AudioManager();
        p_dialogueNum = PeanutsDB.SnoopyDialogueNum;
        loadAffection(PeanutsDB.SnoopyAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialoge {1}", getAffectionPoints(), p_dialogueNum));
        onDialogue(p_dialogueNum);
    }
    
    void Update()
    {
        PeanutsDB.SnoopyAffectionPts = getAffectionPoints();
        PeanutsDB.SnoopyDialogueNum = p_dialogueNum;
    }

    //PATTERN attach method
    public void Attach(WoodStock birdie)
    {
        this.birds.Add(birdie);
        Debug.Log("added to birdlist");
    }

    public void Notify()    //PATTERN 5. publisher broadcasts
    {
        Debug.Log("going to notify");
        for (int i=0; i< birds.Count; i++)
        {
            birds[i].Refresh();
            Debug.Log("notified a bird");
        }
    }


    //a button being hit will trigger this. decides how to respond to response
    protected override void v_toNextDialogue()    //PATTERN this is like the setState()
    //private void v_toNextDialogue()
    {
        int d = getDialogueNum();
        switch(d){
            case 0:
                if (p_responseNum == 1){
                    p_dialogueNum = 1;
                    updateAffection(20);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 2;
                    updateAffection(-5);
                }
                p_responseNum = 0;
                break;
            case 1:
                if (p_responseNum == 1){
                    p_dialogueNum = 3;
                    updateAffection(10);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 4;
                    updateAffection(45);
                }
                p_responseNum = 0;

                break;
            case 2:
                //if r1, p_dialogueNum=3, else 4
                if (p_responseNum == 1){
                    p_dialogueNum = 5;
                    updateAffection(25);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 6;
                    updateAffection(40);
                }
                p_responseNum = 0;
                break;
            case 3: 
                //if r1, p_dialogueNum=5, else 6
                if (p_responseNum == 1){
                    p_dialogueNum = 4;
                    updateAffection(30);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 7;
                    updateAffection(-10);
                }
                p_responseNum = 0;
                break;
            case 4:
                if (p_responseNum == 1){
                    p_dialogueNum = 5;
                    updateAffection(-5);
                } else if (p_responseNum == 2){
                    updateAffection(20);
                    Debug.Log("current mini game");
                    Debug.Log(MainPlayer.GetMiniGameStatus().ToString());
                    initiateMiniGame(game);
                    //should depend on win 13 or loss 14
                    p_dialogueNum = -1;
                }
                p_responseNum = 0;
                break;
            case 5:
                if (p_responseNum == 1){
                    p_dialogueNum = 8;
                    updateAffection(30);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 9;
                    updateAffection(-20);
                }
                p_responseNum = 0;
                break;
            case 6:
                if (p_responseNum == 1){
                    p_dialogueNum = 9;
                    updateAffection(-10);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 10;
                    updateAffection(20);
                }
                p_responseNum = 0;
                break;
            case 7:
                if (p_responseNum == 1){
                    p_dialogueNum = 10;
                    updateAffection(20);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 8;
                    updateAffection(10);
                }
                p_responseNum = 0;
                break;
            case 8:
                if (p_responseNum == 1){
                    updateAffection(20);
                    initiateMiniGame(game);
                    //update after game 13w 14l
                    p_dialogueNum = -1;
                } else if (p_responseNum == 2){
                    p_dialogueNum = 11;
                    updateAffection(-10);
                }
                p_responseNum = 0;
                break;
            case 9:
                if (p_responseNum == 1){
                    p_dialogueNum = 11;
                    updateAffection(-5);
                } else if (p_responseNum == 2){
                    updateAffection(25);
                    initiateMiniGame(game);
                    //update after game 13w 14l
                    p_dialogueNum = -1;
                }
                p_responseNum = 0;
                break;
            case 10:
                if (p_responseNum == 1){
                    p_dialogueNum = 11;
                    updateAffection(-5);
                } else if (p_responseNum == 2){
                    updateAffection(20);
                    initiateMiniGame(game);
                    //dialogue depends... 13 won or 14 lost
                    p_dialogueNum = -1;
                }
                p_responseNum = 0;
                break;
            case 11:
                //do nothung
                p_dialogueNum = 12;
                break;
            case 12:
                //stuckk in loop
                break;
            case 13:
                //do nothung unlesss won potins?
                p_dialogueNum = 12;
                break;
            case 14:
                //do nothung unless won poitns?
                p_dialogueNum = 12;
                break;
            default:
                Debug.Log("uh oh - no dialogue match");
                break;
        }
        Notify(); //PATTERN updates all birdies
        onDialogue(p_dialogueNum);
        Debug.Log(string.Format("current affection points: {0}", getAffectionPoints()));
    }

    public void onDialogue(int d){
        //if they just played a game
        if (p_dialogueNum == -1){
            Debug.Log("dialogue is neg 1 and minigame stat is:");
            Debug.Log(MainPlayer.GetMiniGameStatus().ToString());
            //if they won
            if (MainPlayer.GetMiniGameStatus()==1)
            {
                Debug.Log("Won game");
                updateAffection(15);
                p_dialogueNum=13;
            }
            //or lost
            else if (MainPlayer.GetMiniGameStatus() == 0)
            {
                Debug.Log("Lost game");
                updateAffection(30);
                p_dialogueNum=14;
            }
            MainPlayer.SetMiniGameStatus(-1);   //reset game status
        }
        else if (p_dialogueNum == 11){
            PeanutsDB.SnoopyLocked = 1;
            p_dialogueNum = 12;
        }
        if (getAffectionPoints() >= 100) //check if they won yet
        {
            UIElementHandler.UIGod.EndGame(true, "Snoopy");
        } 

        //theAudio.loadSounds();
        //myDialogue.displayDialogue(d, Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        myDialogue.v_displayDialogue(d);
    }
    
}
