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
    //graphics
    //sfx
    //minigame

    private string game = "Math";
    private int getDialogueNum(){
        return dialogueNum;
    }

    public void hitResponse1()
    {
        responseNum = 1;
        Debug.Log("they hit it boss");

        // Run logic, then clear selection to avoid sticking
        toNextDialogue();
        StartCoroutine(DeselectButton());
    }

    // Button 2 OnClick
    public void hitResponse2()
    {
        responseNum = 2;

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
                if (responseNum == 1){
                    dialogueNum=1;
                    updateAffection(-1);
                } else if (responseNum == 2){
                    dialogueNum = 2;
                    updateAffection(5);
                }
                responseNum = 0;
                break;
            case 1:
                if (responseNum == 1){
                    dialogueNum = 4;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    dialogueNum = 3;
                    updateAffection(15);
                }
                responseNum = 0;

                break;
            case 2:
                //if r1, dialogueNum=3, else 4
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(0);
                } else if (responseNum == 2){
                    dialogueNum = 6;
                    updateAffection(15);
                }
                responseNum = 0;
                break;
            case 3: 
                //if r1, dialogueNum=5, else 6
                if (responseNum == 1){
                    dialogueNum = 7;
                    updateAffection(-10);
                } else if (responseNum == 2){
                    dialogueNum = 2;
                    updateAffection(3);
                }
                responseNum = 0;
                break;
            case 4:
                if (responseNum == 1){
                    dialogueNum = 7;
                    updateAffection(0);
                } else if (responseNum == 2){
                    updateAffection(5);
                    dialogueNum = 8;
                }
                responseNum = 0;
                break;
            case 5:
                if (responseNum == 1){
                    dialogueNum = 10;
                    updateAffection(0);
                } else if (responseNum == 2){
                    updateAffection(5);
                    dialogueNum = 9;
                }
                responseNum = 0;
                break;
            case 6:
                if (responseNum == 1){
                    dialogueNum = 10;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    dialogueNum = 9;
                    updateAffection(8); 
                }
                responseNum = 0;
                break;
            case 7:
                dialogueNum = 15;
                break;
            case 8:
                if (responseNum == 1){
                    dialogueNum = 7;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    dialogueNum = 6;
                    updateAffection(8); 
                }
                responseNum = 0;
                break;
            case 9:
                if (responseNum == 1){
                    dialogueNum = 10;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    
                    updateAffection(8); 
                    initiateMiniGame(game);
                    //dialogueNum = 8;
                }
                responseNum = 0;
                break;
            case 10:
                if (responseNum == 1){
                    dialogueNum = 7;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    dialogueNum = 11;
                    updateAffection(8); 
                }
                responseNum = 0;
                break;
            case 11:
                if (responseNum == 1){
                    dialogueNum = 12;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    
                    updateAffection(8); 
                    initiateMiniGame(game);
                    //dialogueNum = 8;
                }
                responseNum = 0;
                break;
            case 12:
                if (responseNum == 1){
                    dialogueNum = 14;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    dialogueNum = 13;
                    updateAffection(8); 
                }
                responseNum = 0;
                break;
            case 13:
                if (responseNum == 1){
                    dialogueNum = 14;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    
                    updateAffection(8); 
                    initiateMiniGame(game);
                    //dialogueNum = 8;
                }
                responseNum = 0;
                break;
            case 14:
                dialogueNum = 15;
                break;
            case 15:
                //post game
                //give user option to keep talking?
                break;
        }
        onDialogue(dialogueNum);
        Debug.Log(string.Format("current affection points: {0}", getAffectionPoints()));
    }

    //public AudioManager theAudio;

    public void onDialogue(int d){
        //theAudio.loadSounds();
        //myDialogue.displayDialogue(d, Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        myDialogue.displayDialogue(d);
    }


    private LucyDialogue myDialogue;
    public Dialogue genDialogue;
    
    public TextMeshProUGUI LdialogueText, Lresponse1Text, Lresponse2Text;
    public GameObject Lr1p;
    public GameObject Lr2p;

    //spriteRenderer

   
    void Start(){
        //genDialogue = new Dialogue();
        Lr1p.SetActive(true);
        Lr2p.SetActive(true);
        myDialogue = new LucyDialogue(Lr1p, Lr2p, LdialogueText, Lresponse1Text, Lresponse2Text);
    
        dialogueNum = PeanutsDB.LucyDialogueNum;
        loadAffection(PeanutsDB.LucyAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialoge {1}", getAffectionPoints(), dialogueNum));
        onDialogue(dialogueNum);

    }
    
    void Update(){
        PeanutsDB.LucyAffectionPts = getAffectionPoints();
        PeanutsDB.LucyDialogueNum = dialogueNum;

    }
    
}

