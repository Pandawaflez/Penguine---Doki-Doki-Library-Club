using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Lucy : Peanuts
{
    //the following need to be public so we can attach them to sprites
    public AudioManager theAudio;
    public TextMeshProUGUI LdialogueText, Lresponse1Text, Lresponse2Text;
    public GameObject Lr1p;
    public GameObject Lr2p;
    
    //no buttons because i'm using weird techniques
    public Dialogue genDialogue;
    private LucyDialogue myDialogue;
    private string game = "Math";

    void Start()
    {
        //genDialogue = new Dialogue();
        Lr1p.SetActive(true);
        Lr2p.SetActive(true);
        myDialogue = new LucyDialogue(Lr1p, Lr2p, LdialogueText, Lresponse1Text, Lresponse2Text);
    
        p_dialogueNum = PeanutsDB.LucyDialogueNum;
        loadAffection(PeanutsDB.LucyAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialoge {1}", getAffectionPoints(), p_dialogueNum));
        onDialogue(p_dialogueNum);

    }
    
    void Update()
    {
        PeanutsDB.LucyAffectionPts = getAffectionPoints();
        PeanutsDB.LucyDialogueNum = p_dialogueNum;
        //Debug.Log(p_responseNum.ToString());
    }

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
        Debug.Log("punch 2");
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
    private void toNextDialogue()
    {
        int d = getDialogueNum();
        switch(d){
            case 0:
                if (p_responseNum == 1){
                    p_dialogueNum=1;
                    updateAffection(-1);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 2;
                    updateAffection(5);
                }
                p_responseNum = 0;
                break;
            case 1:
                if (p_responseNum == 1){
                    p_dialogueNum = 4;
                    updateAffection(-2);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 3;
                    updateAffection(15);
                }
                p_responseNum = 0;

                break;
            case 2:
                //if r1, p_dialogueNum=3, else 4
                if (p_responseNum == 1){
                    p_dialogueNum = 5;
                    updateAffection(0);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 6;
                    updateAffection(15);
                }
                p_responseNum = 0;
                break;
            case 3: 
                //if r1, p_dialogueNum=5, else 6
                if (p_responseNum == 1){
                    p_dialogueNum = 7;
                    updateAffection(-10);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 2;
                    updateAffection(3);
                }
                p_responseNum = 0;
                break;
            case 4:
                if (p_responseNum == 1){
                    p_dialogueNum = 7;
                    updateAffection(0);
                } else if (p_responseNum == 2){
                    updateAffection(5);
                    p_dialogueNum = 8;
                }
                p_responseNum = 0;
                break;
            case 5:
                if (p_responseNum == 1){
                    p_dialogueNum = 10;
                    updateAffection(0);
                } else if (p_responseNum == 2){
                    updateAffection(5);
                    p_dialogueNum = 9;
                }
                p_responseNum = 0;
                break;
            case 6:
                if (p_responseNum == 1){
                    p_dialogueNum = 10;
                    updateAffection(-2);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 9;
                    updateAffection(8); 
                }
                p_responseNum = 0;
                break;
            case 7:
                p_dialogueNum = 15;
                break;
            case 8:
                if (p_responseNum == 1){
                    p_dialogueNum = 7;
                    updateAffection(-2);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 6;
                    updateAffection(8); 
                }
                p_responseNum = 0;
                break;
            case 9:
                if (p_responseNum == 1){
                    p_dialogueNum = 10;
                    updateAffection(-2);
                } else if (p_responseNum == 2){
                    
                    updateAffection(8); 
                    initiateMiniGame(game);
                    //this should depend on winning (16) & losing (17).
                    p_dialogueNum = 16;
                }
                p_responseNum = 0;
                break;
            case 10:
                if (p_responseNum == 1){
                    p_dialogueNum = 7;
                    updateAffection(-2);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 11;
                    updateAffection(8); 
                }
                p_responseNum = 0;
                break;
            case 11:
                if (p_responseNum == 1){
                    p_dialogueNum = 12;
                    updateAffection(-2);
                } else if (p_responseNum == 2){
                    
                    updateAffection(8); 
                    initiateMiniGame(game);
                    //this should depend on winning (16) & losing (17).
                    p_dialogueNum = 16;
                }
                p_responseNum = 0;
                break;
            case 12:
                if (p_responseNum == 1){
                    p_dialogueNum = 14;
                    updateAffection(-2);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 13;
                    updateAffection(8); 
                }
                p_responseNum = 0;
                break;
            case 13:
                if (p_responseNum == 1){
                    p_dialogueNum = 14;
                    updateAffection(-2);
                } else if (p_responseNum == 2){
                    
                    updateAffection(8); 
                    initiateMiniGame(game);
                    //this should depend on winning (16) & losing (17). //update affection points there or here?
                    p_dialogueNum = 16;
                }
                p_responseNum = 0;
                break;
            case 14:
                p_dialogueNum = 15;
                break;
            case 15:
                //froze out options
                break;
            case 16:
                //user won
                updateAffection(-10);
                //post game ... give options to talk?
                if (p_responseNum == 1){
                    p_dialogueNum = 14;
                    updateAffection(-5);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 18;
                    updateAffection(15); 
                }
                p_responseNum = 0;
                break;
            case 17:
                //user lost
                updateAffection(10);
                //post game... no options to talk cause lucy likes them?
                break;
            default:
                Debug.Log("uh oh - no dialogue match");
                break;
        }
        onDialogue(p_dialogueNum);
        Debug.Log(string.Format("current affection points: {0}", getAffectionPoints()));
    }

    public void onDialogue(int d)
    {
        //theAudio.loadSounds();
        //myDialogue.displayDialogue(d, Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        myDialogue.v_displayDialogue(d);
    }
    
}

