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
{
    public AudioManager theAudio;
    
    public TextMeshProUGUI CdialogueText, Cresponse1Text, Cresponse2Text;
    public GameObject Cr1p;
    public GameObject Cr2p;

    public Dialogue genDialogue;
    private SnoopyDialogue myDialogue;

    private string game = "Minesweeper";

   
    void Start()
    {
        myDialogue = new SnoopyDialogue(Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        //theAudio = new AudioManager();
        p_dialogueNum = PeanutsDB.SnoopyDialogueNum;
        loadAffection(PeanutsDB.SnoopyAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialoge {1}", getAffectionPoints(), p_dialogueNum));
        onDialogue(p_dialogueNum);
    }
    
    void Update()
    {
        PeanutsDB.CharlieAffectionPts = getAffectionPoints();
        PeanutsDB.CharlieDialogueNum = p_dialogueNum;
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
                    p_dialogueNum = 5;
                    updateAffection(-2);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 2;
                    updateAffection(15);
                }
                p_responseNum = 0;

                break;
            case 2:
                //if r1, p_dialogueNum=3, else 4
                if (p_responseNum == 1){
                    p_dialogueNum = 3;
                    updateAffection(0);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 4;
                    updateAffection(15);
                }
                p_responseNum = 0;
                break;
            case 3: 
                //if r1, p_dialogueNum=5, else 6
                if (p_responseNum == 1){
                    p_dialogueNum = 5;
                    updateAffection(-10);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 6;
                    updateAffection(3);
                }
                p_responseNum = 0;
                break;
            case 4:
                if (p_responseNum == 1){
                    p_dialogueNum = 5;
                    updateAffection(0);
                } else if (p_responseNum == 2){
                    updateAffection(5);
                    initiateMiniGame("Pong");
                    //p_dialogueNum = 8;
                }
                p_responseNum = 0;
                break;
            case 5:
                //player stops talking to charlie...
                //holdUp(5); //useless?
                p_dialogueNum=7;
                break;
            case 6:
                if (p_responseNum == 1){
                    p_dialogueNum = 5;
                    updateAffection(-2);
                } else if (p_responseNum == 2){
                    //p_dialogueNum = 8;
                    updateAffection(8);
                    initiateMiniGame("Pong");
                }
                p_responseNum = 0;
                break;
            case 7:
                //stuck
                break;
            case 8:
                //post game
                //give user option to keep talking?
                break;
            default:
                Debug.Log("uh oh - no dialogue match");
                break;
        }
        onDialogue(p_dialogueNum);
        Debug.Log(string.Format("current affection points: {0}", getAffectionPoints()));
    }

    public void onDialogue(int d){
        //theAudio.loadSounds();
        //myDialogue.displayDialogue(d, Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        myDialogue.v_displayDialogue(d);
    }
    
}
