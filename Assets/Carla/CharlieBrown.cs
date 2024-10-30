using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.EventSystem;

public class CharlieBrown : Peanuts
{   
    public AudioManager theAudio;
    public TextMeshProUGUI CdialogueText, Cresponse1Text, Cresponse2Text;
    public GameObject Cr1p;
    public GameObject Cr2p;
    //buttons to reset the buttons ('unclick' them)
    public Button r1;
    public Button r2;

    public Dialogue genDialogue;
    private CharlieDialogue myDialogue;
    private string game = "Pong";

    // AUDIO - ADDED BY OWEN 
    private DialogueSound dialogueSound;

        void Start()
    {
        //genDialogue = new Dialogue();
        myDialogue = new CharlieDialogue(Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        //theAudio = new AudioManager();
        /*
        CdialogueText = myDialogue.dialogueText;
        Cresponse1Text = myDialogue.response1Text;
        Cresponse2Text = myDialogue.response2Text;
        Cr1p = myDialogue.r1p;
        Cr2p = myDialogue.r2p;
        */

        // AUDIO - ADDED BY OWEN:
        // Load the audio clip from the Resources folder
        AudioClip peanutsTeacherClip = Resources.Load<AudioClip>("Owen/Peanuts/peanuts_teacher");
        if (peanutsTeacherClip != null)
                {
                    dialogueSound = new DialogueSound(
                        "peanuts_teacher", 
                        peanutsTeacherClip, 
                        "CharlieBrown", 
                        "Peanuts", 
                        AudioManager.Instance.GetComponent<AudioSource>()
                    );
                }
                else
                {
                    Debug.LogError("peanuts_teacher audio clip not found.");
                }
        // END OF OWEN'S AUDIO CODE

        p_dialogueNum = PeanutsDB.CharlieDialogueNum;
        loadAffection(PeanutsDB.CharlieAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialoge {1}", getAffectionPoints(), p_dialogueNum));
        onDialogue(p_dialogueNum);
    }
    
    void Update()
    {
        PeanutsDB.CharlieAffectionPts = getAffectionPoints();
        PeanutsDB.CharlieDialogueNum = p_dialogueNum;
    }

    //button one calls onclick
    public void hitResponse1()
    {
        p_responseNum = 1;
        Debug.Log("they hit it boss");
        //StartCoroutine(holdUp(10));
        //unselect button for next screen
        r1.Select();
        toNextDialogue();
    }

    //button 2 calls onclick
    public void hitResponse2()
    {
        p_responseNum = 2;
        r2.Select();
        toNextDialogue();
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
                    initiateMiniGame(game);
                    //how to wait here?
                    //yield return null;
                    p_dialogueNum = 8;
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
                    initiateMiniGame(game);
                    p_dialogueNum=8;
                    //yield return null;
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

    public void onDialogue(int d)
    {
        //theAudio.loadSounds();
        //myDialogue.displayDialogue(d, Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        myDialogue.v_displayDialogue(d);
        // AUDIO - ADDED BY OWEN
        if (dialogueSound != null)
        {
            // Play the sound for 3 seconds
            AudioManager.Instance.PlayForDuration(dialogueSound, 2f);
        } else {
            Debug.Log(string.Format("No song found for funciton onDialogue"));
        }
        // END OF OWEN CODE
    }
    
}
