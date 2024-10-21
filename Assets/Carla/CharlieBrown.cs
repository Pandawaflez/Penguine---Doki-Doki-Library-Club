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
    private string game = "Pong";

    // AUDIO - ADDED BY OWEN 
    private DialogueSound dialogueSound;

    //buttons to reset the buttons ('unclick' them)
    public Button r1;
    public Button r2;
    //private int responseNum = 0;

    //button one calls onclick
    public void hitResponse1(){
        responseNum = 1;
        Debug.Log("they hit it boss");
        //StartCoroutine(holdUp(10));
        //unselect button for next screen
        r1.Select();
        toNextDialogue();
    }

    //button 2 calls onclick
    public void hitResponse2(){
        responseNum = 2;
        //holdUp(1);
        r2.Select();
        toNextDialogue();
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
                    dialogueNum = 5;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    dialogueNum = 2;
                    updateAffection(15);
                }
                responseNum = 0;

                break;
            case 2:
                //if r1, dialogueNum=3, else 4
                if (responseNum == 1){
                    dialogueNum = 3;
                    updateAffection(0);
                } else if (responseNum == 2){
                    dialogueNum = 4;
                    updateAffection(15);
                }
                responseNum = 0;
                break;
            case 3: 
                //if r1, dialogueNum=5, else 6
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(-10);
                } else if (responseNum == 2){
                    dialogueNum = 6;
                    updateAffection(3);
                }
                responseNum = 0;
                break;
            case 4:
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(0);
                } else if (responseNum == 2){
                    updateAffection(5);
                    initiateMiniGame(game);
                    //how to wait here?
                    //yield return null;
                    dialogueNum = 8;
                }
                responseNum = 0;
                break;
            case 5:
                //player stops talking to charlie...
                //holdUp(5); //useless?
                dialogueNum=7;
                break;
            case 6:
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    //dialogueNum = 8;
                    updateAffection(8);
                    initiateMiniGame(game);
                    dialogueNum=8;
                    //yield return null;
                }
                responseNum = 0;
                break;
            case 7:
                //stuck
                break;
            case 8:
                //post game
                //give user option to keep talking?
                break;
        }
        onDialogue(dialogueNum);
        Debug.Log(string.Format("current affection points: {0}", getAffectionPoints()));
    }

    public AudioManager theAudio;
    public void onDialogue(int d){
        //theAudio.loadSounds();
        //myDialogue.displayDialogue(d, Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        myDialogue.displayDialogue(d);
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


    private CharlieDialogue myDialogue;
    public Dialogue genDialogue;
    
    public TextMeshProUGUI CdialogueText, Cresponse1Text, Cresponse2Text;
    public GameObject Cr1p;
    public GameObject Cr2p;

    //spriteRenderer

   
    void Start(){
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

        dialogueNum = PeanutsDB.CharlieDialogueNum;
        loadAffection(PeanutsDB.CharlieAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialoge {1}", getAffectionPoints(), dialogueNum));
        onDialogue(dialogueNum);
        /*
        dialogueText.SetText(dialogue0);
        response1Text.SetText(d0response1);
        response2Text.SetText("my sweet sweet charlie prince...");
        */
    }
    
    void Update(){
        PeanutsDB.CharlieAffectionPts = getAffectionPoints();
        PeanutsDB.CharlieDialogueNum = dialogueNum;
    }
    
}
