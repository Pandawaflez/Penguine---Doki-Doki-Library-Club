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
    
    //no buttons because i'm using weird techniques
    public Dialogue myDialogue;
    //private LucyDialogue myDialogue;
    private string game = "Math";
    // Start is called before the first frame update
    void Start()
    {
        myDialogue = new SchroederDialogue(Sr1p, Sr2p, SdialogueText, Sresponse1Text, Sresponse2Text);
        //theAudio = new AudioManager();
        p_dialogueNum = PeanutsDB.SchroederDialogueNum;
        loadAffection(PeanutsDB.SchroederAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialogue {1}", getAffectionPoints(), p_dialogueNum));
        onDialogue(p_dialogueNum);
    }

    // Update is called once per frame
    void Update()
    {
        PeanutsDB.SchroederAffectionPts = getAffectionPoints();
        PeanutsDB.SchroederDialogueNum = p_dialogueNum;
    }

    // Button 1 OnClick
    public void hitResponse1()
    {
        p_responseNum = 1;
        Debug.Log("they hit it boss");

        // Run logic, then clear selection to avoid sticking
        toNextDialogue();
        StartCoroutine(DeselectButton());
    }

    // Button 2 OnClick
    public void hitResponse2()
    {
        p_responseNum = 2;

        // Run logic, then clear selection
        toNextDialogue();
        StartCoroutine(DeselectButton());
    }

    // Coroutine to wait a frame and clear selection
    private IEnumerator DeselectButton()
    {
        yield return null;  // Wait one frame to ensure UI updates

        // Deselect the current selected UI element
        EventSystem.current.SetSelectedGameObject(null);
    }


    //a button being hit will trigger this. decides how to respond to response
    private void toNextDialogue(){
        int d = getDialogueNum();
        switch(d){
            case 0:
                if (p_responseNum == 1){
                    p_dialogueNum = 1;
                    updateAffection(5);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 2;
                    updateAffection(-5);
                }
                p_responseNum = 0;
                break;
            case 1:
                if (p_responseNum == 1){
                    p_dialogueNum = 3;
                    updateAffection(5);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 4;
                    updateAffection(0);
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
                    updateAffection(20);
                }
                p_responseNum = 0;
                break;
            case 4:
                if (p_responseNum == 1){
                    p_dialogueNum = 7;
                    updateAffection(15);
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
                    updateAffection(-10);
                } else if (p_responseNum == 2){
                    updateAffection(5);
                    initiateMiniGame(game);
                    //dialogue depends... 13 won or 14 lost
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
        onDialogue(p_dialogueNum);
        Debug.Log(string.Format("current affection points: {0}", getAffectionPoints()));
    }

    public void onDialogue(int d){
        //if they just played a game
        if (p_dialogueNum == -1){
            //if they won
            if (MainPlayer.IsBCMode()){
                updateAffection(15);
                p_dialogueNum=16;
            }
            //or lost
            else {
                updateAffection(-5);
                p_dialogueNum=17;
            }
        }
        //theAudio.loadSounds();
        //myDialogue.displayDialogue(d, Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        myDialogue.v_displayDialogue(d);
    }

}
