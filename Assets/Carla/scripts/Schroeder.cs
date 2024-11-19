using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Schroeder : Peanuts
{
    public AudioManager theAudio;
    public TextMeshProUGUI SdialogueText, Sresponse1Text, Sresponse2Text;
    public GameObject Sr1p;
    public GameObject Sr2p;
    
    public Dialogue myDialogue;
    //private LucyDialogue myDialogue;
    private string game = "Math";

    //Start is called beofre the first frame update
    void Start()
    {
        //set dialogue up
        myDialogue = new SchroederDialogue(Sr1p, Sr2p, SdialogueText, Sresponse1Text, Sresponse2Text);
        //theAudio = new AudioManager();

        //reload state
        p_dialogueNum = PeanutsDB.SchroederDialogueNum;
        loadAffection(PeanutsDB.SchroederAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialogue {1}", getAffectionPoints(), p_dialogueNum));

        //get to it
        onDialogue(p_dialogueNum);
    }

    // Update is called once per frame
    void Update()
    {
        //continuosly make sure database is up to date
        PeanutsDB.SchroederAffectionPts = getAffectionPoints();
        PeanutsDB.SchroederDialogueNum = p_dialogueNum;
    }

    /*a response button being hit will trigger this. 
    * decides how to respond to response through updating affection, setting next dialogue, and possibly starting a minigame
    */
    protected override void v_toNextDialogue()
    {
        //see what dialouge we are currently on
        int d = getDialogueNum();
        switch(d){
            case 0:
            //check response num and respond accordingly.
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
                    updateAffection(20);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 4;
                    updateAffection(5);
                }
                p_responseNum = 0;

                break;
            case 2:
                if (p_responseNum == 1){
                    p_dialogueNum = 5;
                    updateAffection(15);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 3;
                    updateAffection(5);
                }
                p_responseNum = 0;
                break;
            case 3: 
                if (p_responseNum == 1){
                    p_dialogueNum = 6;
                    updateAffection(-15);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 7;
                    updateAffection(25);
                }
                p_responseNum = 0;
                break;
            case 4:
                if (p_responseNum == 1){
                    p_dialogueNum = 7;
                    updateAffection(20);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 6;
                    updateAffection(-20);
                }
                p_responseNum = 0;
                break;
            case 5:
                if (p_responseNum == 1){
                    p_dialogueNum = 8;
                    updateAffection(5);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 9;
                    updateAffection(-5);
                }
                p_responseNum = 0;
                break;
            case 6:
                if (p_responseNum == 1){
                    p_dialogueNum = 11;
                    updateAffection(-10);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 7;
                    updateAffection(10);
                }
                p_responseNum = 0;
                break;
            case 7:
                if (p_responseNum == 1){
                    p_dialogueNum = 11;
                    updateAffection(5);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 10;
                    updateAffection(15);
                }
                p_responseNum = 0;
                break;
            case 8:
                if (p_responseNum == 1){
                    p_dialogueNum = 7;
                    updateAffection(15);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 9;
                    updateAffection(-10);
                }
                p_responseNum = 0;
                break;
            case 9:
                //do nothing
                p_dialogueNum = 12;
                break;
            case 10:
                if (p_responseNum == 1){
                    p_dialogueNum = 14;
                    updateAffection(-5);
                } else if (p_responseNum == 2){
                    updateAffection(20);
                    initiateMiniGame(game);
                    //dialogue depends... 13 won or 14 lost. set to -1 for now
                    p_dialogueNum = -1;
                }
                p_responseNum = 0;
                break;
            case 11:
                if (p_responseNum == 1){
                    p_dialogueNum = 10;
                    updateAffection(5);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 9;
                    updateAffection(20);
                }
                p_responseNum = 0;
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
        Debug.Log(string.Format("toNext just called onDia {0}", p_dialogueNum));
        onDialogue(p_dialogueNum);
        Debug.Log(string.Format("current affection points: {0}", getAffectionPoints()));
    }

    /* this function is either called from start or onDialogue.
    * It will tell the Dialogue class to display the dialogue
    * and will also check for edge cases (win/lose a game, get locked out, or win character's love)
    */
    public void onDialogue(int d){
        Debug.Log("someone called onDialogue");
        //if they just played a game
        if (p_dialogueNum == -1){
            //if they won
            if (MainPlayer.GetMiniGameStatus()==1)
            {
                updateAffection(25);
                p_dialogueNum=13;
                d=13;
            }
            //or lost
            else if (MainPlayer.GetMiniGameStatus() == 0)
            {
                Debug.Log("they lost");
                updateAffection(-5);
                p_dialogueNum=14;
                d=14;
            }
            MainPlayer.SetMiniGameStatus(-1);   //reset game status
            Update();   //make sure DB gets updated
        }

        //check if user is locked out
        else if (p_dialogueNum == 9){
            PeanutsDB.SchroederLocked = 1;
            p_dialogueNum = 12;
        }
        //count them as locked out if after game??

        if (getAffectionPoints() >= 100) //check if they won yet
        {
            UIElementHandler.UIGod.EndGame(true, "Schroeder");
        } 

        Debug.Log(string.Format("current dialoge: {0} and d: {1}", p_dialogueNum, d));
        Debug.Log(string.Format("DB dialogue: {0} and d {1}", PeanutsDB.SchroederDialogueNum, d));

        //theAudio.loadSounds();
        myDialogue.v_displayDialogue(d);
    }

}
